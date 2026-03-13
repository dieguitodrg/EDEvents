using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Windows.Devices.Bluetooth;
using Windows.Devices.Bluetooth.GenericAttributeProfile;
using Windows.Devices.Enumeration;
//using System.Speech.Synthesis;
using Windows.Security.Cryptography;

//using Windows.Web.Http;

namespace EDCrew
{

    public enum TransitionMode
    {
        Jump,        // cambio brusco
        Gradient,    // interpolación suave
        FadeToBlack  // fade a negro y luego al siguiente
    }


    public class BleLightController : IDisposable
    {
        private string _deviceName;
        private string _serviceFilter;
        private BluetoothLEDevice _device;
        private GattCharacteristic _writeCharacteristic;

        private CancellationTokenSource _cts;
        public bool Connected { get; set; }

        private System.Threading.Timer _keepAliveTimer;
        //private byte[] _lastColor = null;

        private (byte r, byte g, byte b, byte progress) _lastColor = (0, 0, 0, 100);

        public BleLightController(string deviceName, string serviceFilter = "ffd5")
        {
            _deviceName = deviceName;
            _serviceFilter = serviceFilter.ToLower();
        }

        public CancellationToken StartAnimation()
        {
            _cts?.Cancel();

            
            _cts = new CancellationTokenSource();

            return _cts.Token;
        }

        /// <summary>
        /// Conecta al dispositivo BLE y localiza la característica de escritura.
        /// </summary>
        public async Task ConnectAsync()
        {
            this.Connected = false;

            try
            {
                var selector = BluetoothLEDevice.GetDeviceSelector();
                var devices = await DeviceInformation.FindAllAsync(selector);

                var deviceInfo = devices.FirstOrDefault(d => d.Name == _deviceName);
                if (deviceInfo == null) throw new Exception($"Dispositivo {_deviceName} no encontrado.");

                _device = await BluetoothLEDevice.FromIdAsync(deviceInfo.Id);
                if (_device == null) throw new Exception("No se pudo abrir el dispositivo BLE.");

                var servicesResult = await _device.GetGattServicesAsync();
                if (servicesResult.Status != GattCommunicationStatus.Success)
                    throw new Exception("Servicios GATT no disponibles.");

                var service = servicesResult.Services
                    .FirstOrDefault(s => s.Uuid.ToString().ToLower().Contains(_serviceFilter));
                if (service == null) throw new Exception($"Servicio con filtro {_serviceFilter} no encontrado.");

                var charsResult = await service.GetCharacteristicsAsync();
                if (charsResult.Status != GattCommunicationStatus.Success)
                    throw new Exception("Características no disponibles.");

                _writeCharacteristic = charsResult.Characteristics.FirstOrDefault(c =>
                    c.CharacteristicProperties.HasFlag(GattCharacteristicProperties.WriteWithoutResponse) ||
                    c.CharacteristicProperties.HasFlag(GattCharacteristicProperties.Write));

                if (_writeCharacteristic == null)
                    throw new Exception("No hay característica con permisos de escritura.");
                this.Connected = true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                
            }

            
        }

        /// <summary>
        /// Envía un color al dispositivo conectado.
        /// </summary>
        public async Task SendColorAsync(byte r, byte g, byte b, byte warmWhite, int progress)
        {
            try
            {

                if (!Connected)
                {
                    await ConnectAsync();
                }

                if (!Connected)
                {
                    return;
                }

                if (_writeCharacteristic == null)
                    throw new InvalidOperationException("No conectado. Llama primero a ConnectAsync().");

                if (progress < 3) progress = 3;

                byte scaledR = (byte)((r * progress) / 100);
                byte scaledG = (byte)((g * progress) / 100);
                byte scaledB = (byte)((b * progress) / 100);
                byte scaledW = (byte)((warmWhite * progress) / 100);

                byte[] frame = new byte[] { 0x56, scaledR, scaledG, scaledB, scaledW, 0xF0, 0xAA };

                if (warmWhite != 0)
                {
                    frame[1] = 0;
                    frame[2] = 0;
                    frame[3] = 0;
                    frame[4] = (byte)((progress * 255) / 100);
                    frame[5] = 0x0F;
                }

                var buffer = CryptographicBuffer.CreateFromByteArray(frame);

                var writeOption = _writeCharacteristic.CharacteristicProperties.HasFlag(GattCharacteristicProperties.WriteWithoutResponse)
                    ? GattWriteOption.WriteWithoutResponse
                    : GattWriteOption.WriteWithResponse;

                var status = await _writeCharacteristic.WriteValueWithResultAsync(buffer, writeOption);
                if (status.Status != GattCommunicationStatus.Success)
                    throw new Exception($"Fallo al escribir: {status.ProtocolError ?? 0}");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            _lastColor = (r, g, b, (byte)progress);


        }

        public async Task RunSequenceLoopAsync(
    (byte r, byte g, byte b, byte progress, int time, int transitionTime)[] steps,
    CancellationToken token)
        {
            try
            {
                var first = steps[0];
                await QuickFadeAsync(_lastColor, first, 150, token);

                int count = steps.Length;


                while (!token.IsCancellationRequested) // ciclo infinito
                {
                    for (int i = 0; i < count; i++)
                    {
                        if (token.IsCancellationRequested) return;

                        var current = steps[i];
                        var next = steps[(i + 1) % count]; // operador mod → circular

                        // 1. Mostrar color actual
                        await SendColorAsync(current.r, current.g, current.b, 0, current.progress);
                        await Task.Delay(current.time);

                        // 2. Transición al siguiente (incluido el primero al final)
                        if (current.transitionTime > 0)
                        {
                            await FadeToAsync(current, next, current.transitionTime, token);
                        }
                    }
                }
            }
            catch (TaskCanceledException)
            { // Cancelación limpia: no hacemos nada }
            }

            }
            

        private async Task FadeToAsync(
    (byte r, byte g, byte b, byte progress, int time, int transitionTime) from,
    (byte r, byte g, byte b, byte progress, int time, int transitionTime) to,
    int duration, CancellationToken token)
        {
            const int steps = 50;
            int delay = duration / steps;

            for (int i = 0; i <= steps; i++)
            {
                float t = (float)i / steps;

                byte r = (byte)(from.r + (to.r - from.r) * t);
                byte g = (byte)(from.g + (to.g - from.g) * t);
                byte b = (byte)(from.b + (to.b - from.b) * t);
                byte p = (byte)(from.progress + (to.progress - from.progress) * t);

                await SendColorAsync(r, g, b, 0, p);
                await Task.Delay(delay, token);
            }
        }


        private async Task QuickFadeAsync(
            (byte r, byte g, byte b, byte progress) from,
            (byte r, byte g, byte b, byte progress, int time, int transitionTime) to,
            int duration,
            CancellationToken token)
        {
            const int steps = 20; // pocos pasos → rápido pero suave
            int delay = duration / steps;

            for (int i = 0; i <= steps; i++)
            {
                token.ThrowIfCancellationRequested();

                float t = (float)i / steps;

                byte r = (byte)(from.r + (to.r - from.r) * t);
                byte g = (byte)(from.g + (to.g - from.g) * t);
                byte b = (byte)(from.b + (to.b - from.b) * t);
                byte p = (byte)(from.progress + (to.progress - from.progress) * t);

                await SendColorAsync(r, g, b, 0, p);
                await Task.Delay(delay, token);
            }
        }



        

        public void Dispose()
        {
            _device?.Dispose();
        }
    }


}

