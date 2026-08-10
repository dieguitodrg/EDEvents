using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EDCrew.Pipeline
{
    /// <summary>
    /// Convierte un evento del journal (JSON) en una clase C# tipada
    /// (`Journal<Evento> : JournalBase`) usando la API de json2csharp.com
    /// y guarda el resultado como un fichero .cs. Independiente de Form1.
    /// </summary>
    public class EventCSharpService
    {
        public async Task<string> EventCSharp(string className, string eventJson)
        {
            using (var client = new HttpClient())
            {
                JsonToCsharpInput input = new JsonToCsharpInput()
                {
                    input = eventJson,
                    operationid = "jsontocsharp",
                    settings = new JsonToCsharpSettings()
                    {
                        UsePascalCase = "false",
                        UseFields = "false",
                        AlwaysUseNullables = "false",
                        UseJsonAttributes = "false",
                        NullValueHandlingIgnore = "false",
                        UseJsonPropertyName = "false",
                        ImmutableClasses = "false",
                        RecordTypes = "false",
                        NoSettersForCollections = "false"
                    }
                };

                var myContent = JsonConvert.SerializeObject(input);

                var buffer = Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                HttpResponseMessage httpresponse = await client.PostAsync($"https://json2csharp.com/api/Default", byteContent);

                String result = "";

                try
                {
                    httpresponse.EnsureSuccessStatusCode();

                    result = await httpresponse.Content.ReadAsStringAsync();

                    result = result.Replace("\"// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);\\r\\n    ", "").Replace("\\r\\n", "\r\n");
                    result = result.Replace("public class Root", "public class Journal" + className + " : JournalBase");
                    result = result.Remove(result.Length - 1);
                    result = result.Replace("public DateTime timestamp { get; set; }", "");
                    result = result.Replace("public string @event { get; set; }", "");
                    String foldername = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Classes";

                    Directory.CreateDirectory(foldername);

                    String filename = $"{foldername}\\{className}.{Guid.NewGuid().ToString()}.cs";

                    File.WriteAllText(filename, @"using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCrew
{

    //" + eventJson + "\r\n" + result + @"
}");

                }
                catch (Exception ex)
                {

                }

                return result;
            }
        }
    }
}
