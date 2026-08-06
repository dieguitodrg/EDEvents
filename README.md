# EDCrew (EDEvents) — Copiloto para Elite Dangerous

Aplicación **WinForms (.NET Framework 4.8, C#)** que actúa como acompañante/copiloto del juego **Elite Dangerous**. Intercepta el *Journal* del juego en tiempo real y ofrece al usuario información por sobreimpresión en pantalla y audio, permite controlar la nave con la voz, ejecutar macros, sirve dashboards web, consulta la API oficial de Frontier (CAPI) y controla hardware externo (joystick X52, Arduino, luces BLE).

---

## Funcionalidades principales

| Área | Descripción |
|------|-------------|
| **Journal en tiempo real** | Vigila `%USERPROFILE%\Saved Games\Frontier Developments\Elite Dangerous` con `FileSystemWatcher`, lee `*Journal*.log` y `Status.json` y procesa cada evento. |
| **Overlay en pantalla** | Inyecta un hook Direct3D 11 en `EliteDangerous64.exe` y dibuja texto estilo LCARS sobre el juego (nave, sistema, estado, misiones, combate, etc.). |
| **Audio (TTS)** | Anuncia eventos y responde por voz. Tres motores disponibles: System.Speech, Azure Neural (Cognitive Services) y Windows.Media.SpeechSynthesis. Colas de hilos independientes (NPC, respuestas, confirmaciones). |
| **Reconocimiento de voz** | Gramática en español (es-ES) construida desde `Gramatica.json`. Permite preguntar información y ejecutar comandos/macros hablando. |
| **Macros y control del juego** | Los comandos pueden pulsar teclas, encadenar pre/post comandos, aplicar condiciones (`Status.LightsOn == false`) y agruparse por categoría/subsistema. |
| **Servidor web** | HTTP en el puerto **8484**. Sirve dashboards LCARS (`default`, `combate`, `comerciantes`, `factorinterestelar`, `inventario`, `mensajes`) con plantillas `${Propiedad}` y un endpoint `/docommand` para ejecutar comandos desde el navegador. Incluye un panel de control táctil (`panelcontrol.html`). |
| **CAPI de Frontier** | OAuth2 con flujo PKCE contra `auth.frontierstore.net`; consulta *profile*, *market* y *shipyard* en `companion.orerve.net`. |
| **Scraping Inara** | Localización de comerciantes de materiales, factores interestelares, conflictos y órdenes mediante scraping de Inara a través de proxy Tor (TorSharp) + CsQuery. |
| **Hardware externo** | Joystick **Logitech/Saitek X52** (MFD y LEDs vía DirectOutput), **Arduino** (caja de botones por puerto serie) y **lámpara BLE RGB** (GATT). |
| **Datos del juego** | Control de inventario de materiales (`Categorias.json`, niveles y máximos), exobiología (`ExoMastery.json`), cuerpos escaneados por comandante (`DictionaryScanned.<CMDR>.json`), méritos PowerPlay, progreso de colonización y contadores de combate. |

---

## Arquitectura

Flujo de datos principal:

```
  Elite Dangerous
    │  (escribe archivos)
    ▼
  %USERPROFILE%\Saved Games\...\Elite Dangerous
  ├── Journal.*.log  ──┐
  └── Status.json   ───┤
                        ▼
             FileSystemWatcher (Form1.cs)
                        │
                        ▼
         Form1.ProcessFile()  ← deserializa cada evento (Newtonsoft.Json /
                                 System.Text.Json) y hace switch sobre @event
                        │
        ┌───────────────┼───────────────────────────┐
        ▼               ▼                           ▼
  Overlay D3D11   Voz (TTS)                Actualización de estado
  (Capture)       (3 motores + colas)      (sistema, nave, inventario,
                                           misiones, combate, méritos...)
        │               │                           │
        ▼               ▼                           ▼
  ┌─────────────────────────────────────────────────────────┐
  │  Comandos de voz / HTML (/docommand) / Arduino          │
  │         │                                               │
  │         ▼                                               │
  │   EjecutarComando() → pulsación de teclas / métodos     │
  └─────────────────────────────────────────────────────────┘

  Salidas adicionales:
  ├── Servidor web (HttpServer, puerto 8484) → dashboards LCARS
  ├── CAPI Frontier (OAuth2 + companion.orerve.net)
  ├── Scraping Inara (TorSharp + CsQuery)
  └── Hardware: X52 (DirectOutput), Arduino (serie), BLE (luces)
```

---

## Estructura del proyecto

> Clase principal **`Form1.cs`** (~4.700 líneas): lógica de negocio casi completa en una sola clase monolítica (journal, voz, overlay, web, hardware, scraping).

| Ruta | Propósito |
|------|-----------|
| `Program.cs` | Punto de entrada. Ejecuta `Form1` (la ventana `ArduinoControls` está comentada). |
| `Form1.cs` / `.Designer.cs` | Ventana principal y toda la lógica del copiloto. |
| `ArduinoControls.cs` / `.Designer.cs` | Formulario que muestra/mapea los comandos asignados a botones Arduino. |
| `HttpServer.cs` | Servidor HTTP embebido (HttpListener, puerto 8484) con plantillas `${...}` y endpoint `/docommand`. |
| `Gramatica.json` | **Definición de comandos** de voz/macros (ver sección Configuración). |
| `Comandos.cs` | Modelo `Comandos` y `SubComando` para `Gramatica.json`. |
| `Categorias.json` | Categorías y niveles de materiales (crudo, manufacturado, codificado) para el control de inventario. |
| `mercancias.json` | Listado de mercancías y valores (para reconocimiento de voz de cotizaciones). |
| `ClaseInventario.cs` | `CategoriasInventario`: cantidad/nivel/máximo/suma por material. |
| `Status.cs` | Modelo de `Status.json` del juego (flags, pips, combustible, destino, estado legal…). |
| `JournalLegacy.cs` | Modelo plano "legacy" de eventos del journal (modelo generalista usado en el `switch` de `ProcessFile`). |
| `Pipeline/` | **Nuevo despachador de eventos** (estrategia estrangulador): `ICopilotOutput` (fachada de salida log/voz), `IJournalHandler`/`JournalHandler<T>` (handlers tipados) y `JournalEventDispatcher` (registro por nombre de evento). Los handlers viven en `Pipeline/Handlers/` y se registran en el constructor de `Form1`. |
| `EDEvents.Tests/` | **Proyecto de tests xUnit** (target `net48`) con dobles de `ICopilotOutput`. Tests: `dotnet test EDEvents.Tests\EDEvents.Tests.csproj`. |
| `Journal/` | **254 clases tipadas por evento** que heredan de `JournalBase`, cubriendo el catálogo completo de eventos documentado en [elite-journal.readthedocs.io](https://elite-journal.readthedocs.io/en/latest/). Organizadas en `Crew/`, `FleetCarriers/`, `Odyssey/`, `PowerPlay/`, `Shipyard/`, `Startup/`, `Travel/` y la raíz. |
| `docs/eventos.md` | **Catálogo de eventos** (evento → sección → clase C# → usado en el switch → handler de pipeline). Generado con `tools/GenerateEventosDoc.ps1`. |
| `tools/` | Scripts de generación: `GenerateJournalClasses.ps1` (genera `Journal<Evento>.cs` desde samples vía json2csharp y los registra en el csproj), `ExtractJournalSamples.ps1` (extrae samples reales de los journals del usuario) y `GenerateEventosDoc.ps1`. Muestras en `tools/JournalSamples/`. |
| `Journal/JournalBase/JournalBase.cs` | Base de eventos + `Reader.ReadJson()` que instancia la clase tipada por reflexión. |
| `Speech/ISpeechEngine.cs` | Interfaz y 3 motores TTS (`SystemSpeechEngine`, `NeuralSpeechEngine` Azure, `ModernSpeechEngine` Windows.Media) + `SpeechEngineFactory`. |
| `CAPI/CAPI.cs` | Cliente de la Companion API de Frontier (profile/market/shipyard). |
| `CAPI/OAuth2.cs` | Flujo OAuth2 con PKCE contra Frontier (carga/guarda token en `access-token.json`). |
| `DirectOutputCSharpWrapper/` | Wrapper P/Invoke de la SDK DirectOutput (X52/Logitech): `DirectOutput.cs`, `DllHelper.cs`, `X52Pro.cs` (enums de LEDs y strings). |
| `SaitekInfo.cs` | Modelo `Info` del X52 (colores LEDs + líneas de texto) usado por `DisplayPage()`. |
| `BleLightController.cs` | Control de lámpara BLE RGB (GATT, servicio `ffd5`) con modos de transición de color. |
| `ExoMastery.cs` | Modelo de ruta de exobiología (sistema, cuerpo, distancia, valor, completado). |
| `StarTypeColor.cs` | Mapa clase espectral → color (para representar estrellas). |
| `ModulesInfo.cs` | Modelo `Module` (slot, item, potencia, prioridad). |
| `Order.cs` / `StationListItem.cs` | Modelos de órdenes y estaciones para listas de UI. |
| `DictionaryScanned.<CMDR>.json` | Cuerpos ya escaneados por comandante (persistido por la app). |
| `*.html`, `*.css`, `*.js`, `*.woff*`, `*.ttf` | Dashboards web y assets (LCARS, jQuery, three.js). |
| `Direct3DHook-master/` | Proyecto de terceros (EasyHook + SharpDX) que hace el hook Direct3D y dibuja el overlay; proyecto `Capture` es referencia del principal. |
| `lib/` | DLLs de SharpDX/EasyHook copiadas a la salida de build. |
| `App.config` | `AppName`, `ClientID` (CAPI Frontier) y configuración de facción. |

---

## Tecnologías y dependencias

- **.NET Framework 4.8** / WinForms (C#).
- **Newtonsoft.Json** (principal) con fallback a **System.Text.Json** (7.0.2) en varias lecturas.
- **System.Speech** (reconocimiento y síntesis, voz es-ES).
- **Microsoft.CognitiveServices.Speech** 1.47.0 (motor neural Azure).
- **Windows.Media.SpeechSynthesis** (motor moderno WinRT, vía paquete UWP).
- **SharpDX + EasyHook** (hook Direct3D 11 para el overlay en juego).
- **CsQuery** (scraping HTML de Inara).
- **TorSharp** (proxy Tor para no ser bloqueado por Inara).
- **System.IO.Ports** (Arduino por serie).
- **Windows.Devices.Bluetooth** (luces BLE).

---

## Configuración

### `App.config`
```xml
<add key="AppName" value="Personal Journal DRG" />
<add key="ClientID" value="..." />   <!-- registrar app en https://user.frontierstore.net/developer -->
<add key="FactionURL" value="https://inara.cz/elite/minorfaction-conflicts/35226/" />
<add key="FactionName" value="Union Cosmos" />
```

### `Gramatica.json` (comandos)
Cada comando define:
- `command`: frase hablada / texto.
- `control`: array de bytes para el Arduino (indica asignación a botones).
- `precommands` / `postcommands`: comandos encadenados antes/después.
- `conditionsource` / `conditionvalue`: condición previa (p. ej. `Status.LightsOn` / `false`) para decidir "Encender/Apagar".
- `category`: categoría de navegación de la UI.
- `subsystem`: subsistema al que apunta (combate).
- `method`: método a invocar por reflexión.
- `subcommands`: expansión de plantilla `{0}` (p. ej. subsistemas de la nave).
- `code`: código corto (p. ej. `HIPE`, `ENCEFARO`) usado por el panel web (`/docommand?command=<code>`).

> ⚠️ El fichero contiene acentos en encoding no-UTF8 (`Navegaci��n`); al editarlo con otras herramientas puede corromperse. Mantener la codificación actual o normalizarlo a UTF-8 con cuidado.

### Servidor web
- Puerto fijo **8484** (`HttpServer.cs`).
- Las páginas HTML usan plantillas `${Propiedad}` resueltas con el indexer de reflexión de `Form1` (`this[propertyName]`).
- Rutas especiales que disparan scraping: `factorinterestelar`, `comerciantes`.
- Endpoint de control: `http://localhost:8484/docommand?command=<code|frase>&argument=<n>`.

---

## Integraciones de hardware

### Arduino (caja de botones)
- Puerto serie (9600 baud), seleccionable en la UI (`cbArduinoCOM`).
- Trama de **8 bytes** por comando; `control[0] == 1` marca los comandos asignados a botones.
- `ArduinoControls.cs` dibuja una matriz 32×32 con los comandos mapeados.

### X52 / Logitech (MFD)
- Wrapper P/Invoke de DirectOutput (`DirectOutputCSharpWrapper`).
- `DisplayPage()` pinta páginas en el MFD (estado, pips, contacto escaneado…) y colores de LEDs según estado del juego (contacto buscado/facción objetivo).

### Luces BLE
- `BleLightController` conecta por BLE GATT (servicio `ffd5`), escribe colores RGB + blanco cálido y admite modos `Jump`, `Gradient` y `FadeToBlack`.
- `SendColorAsync(r, g, b, warmWhite, progress)`.

---

## Build y ejecución

**Requisitos:** Visual Studio con soporte de .NET Framework 4.8 y paquetes NuGet (restaurar `packages.config` / `.csproj`). Es un proyecto estilo VS2019 (`.csproj` no SDK).

1. Abrir `EDEventsTest.sln`.
2. Restaurar paquetes NuGet.
3. Compilar (proyecto principal `EDCrew48`). Compila además el proyecto `Capture` (Direct3DHook).

**Rutas máquina-específicas a tener en cuenta (hardcodeadas):**
- Referencia a `EasyHook.dll` en `D:\proyectos\Direct3DHook-master\bin\EasyHook.dll` (`.csproj`).
- Referencia a `Windows.winmd` del SDK de Windows 10 en `Program Files (x86)\Windows Kits\10\UnionMetadata`.
- El journal se localiza en `%USERPROFILE%\Saved Games\Frontier Developments\Elite Dangerous`.

**El juego debe estar lanzado con la ventana principal visible** para que el hook Direct3D pueda inyectarse (`AttachProcess` busca `EliteDangerous64`).

> **Evento de postcompilación eliminado (referencia futura):** el `PostBuildEvent` del `EDCrew48.csproj` solía lanzar
> `XCOPY "C:\Users\diegu\source\repos\EDEventsTest\EDCrew48\bin\Debug\*.*" "H:\EDCrew" /D /I /E /Y`
> copiando la salida de build a la carpeta de producción `H:\EDCrew`. Se retiró el 2026-08-06 por contener una ruta absoluta máquina-específica (`C:\Users\diegu\source\repos\EDEventsTest\...`). Si se necesita de nuevo, regenerarlo relativo al directorio del proyecto, p. ej.:
> `XCOPY "$(TargetDir)*.*" "H:\EDCrew" /D /I /E /Y`.

---

## Notas y advertencias

- **Monolito**: casi toda la lógica vive en `Form1.cs`. Antes de tocar funcionalidad, revisar `ProcessFile()` (procesado de journal), `EjecutarComando()` (comandos) y `SetDisplay()`/`DisplayPage()` (salidas).
- **Modelo dual del journal**: los eventos se leen como `JournalLegacy` (plano) para el `switch` principal; las clases tipadas de `Journal/` se despachan vía `Pipeline/JournalEventDispatcher` (`Reader.ReadJson()` + handler registrado). Migración en curso: 6 handlers en `Pipeline/Handlers/` (`LoadGame`, `PowerplayCollect`, `CollectCargo`, `EjectCargo`, `DockingGranted`, `StartJump`) con sus cases retirados del switch. Los tests de `EDEvents.Tests/Journal/JournalModelTests.cs` verifican que `Reader.ReadJson` resuelve la clase tipada para las 171 muestras, y `EDEvents.Tests/Pipeline/` cubre los handlers.
- **Encoding**: varios ficheros (JSON de datos, `Gramatica.json`, `Form1.cs`) usan literales no-UTF8; el código contiene muchos `Console.WriteLine` y código comentado heredado.
- **Límites de la app**: comandos específicos de la facción del autor ("Union Cosmos", scraping de Inara) y personalizados por comandante (`DictionaryScanned.<CMDR>.json`).
