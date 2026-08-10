using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Security.Cryptography;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using CsQuery;
using System.Runtime.Remoting.Messaging;
using CsQuery.Implementation;
using System.Windows.Forms;
using Windows.Media.Playback;
using System.Reflection;
using System.Windows.Forms.VisualStyles;

namespace EDCrew
{

    public interface StringReplacer
    {
        string GetWebString(string value);
    }

    public interface IWebServerHost : StringReplacer
    {
        string StarSystem { get; }
        List<StationListItem> Comerciantes { get; set; }
        List<StationListItem> FactoresInterestelar { get; set; }
        void IrASistema(PromptType t, int opcion);
        void IrABase(PromptType t, int opcion);
        void Invoke(String method, string argument);
    }

    public class HttpServer
    {
        public IWebServerHost host { get; set; }
        public InaraService inara { get; set; }
        public int Port = 8484;

        private HttpListener _listener;

        public void Start()
        {
            _listener = new HttpListener();
            _listener.Prefixes.Add("http://+:" + Port.ToString() + "/");
            _listener.Start();
            Receive();
        }

        public void Stop()
        {
            _listener.Stop();
        }

        private void Receive()
        {
            _listener.BeginGetContext(new AsyncCallback(ListenerCallback), _listener);
        }



        private async void ListenerCallback(IAsyncResult result)
        {
            if (_listener.IsListening)
            {
                var context = _listener.EndGetContext(result);
                var request = context.Request;

                // do something with the request
                Console.WriteLine($"{request.Url}");

                var response = context.Response;
                response.StatusCode = (int)HttpStatusCode.OK;

                

                String sresponse = "";
                byte[] bresponse;

                
                String localpath = request.Url.LocalPath.ToLower().Replace("/assets/", "");

                if (request.Url.LocalPath.ToLower().Contains("/docommand"))
                {
                    String command = "";
                    int opcion = 0;
                    String argument = "";
                    try
                    {
                        command = request.QueryString["command"];
                    } catch(Exception ex)
                    {

                    }

                    
                    try
                    {
                        opcion = int.Parse(request.QueryString["argument"]);
                    }
                    catch (Exception ex)
                    {

                    }

                    try
                    {
                        argument = request.QueryString["argument"];
                    }
                    catch (Exception ex)
                    {

                    }


                    switch (command.ToLower())
                    {
                        case "irasistemacomerciantes":
                            {
                                host.IrASistema(PromptType.MaterialTrader, opcion); break;
                            }
                        case "irabasecomerciantes":
                            {
                                host.IrABase(PromptType.MaterialTrader, opcion); break;
                            }
                        default: {
                                host.Invoke(command, argument); break;
                            }
                    }


                    localpath = "";
                }

                if (localpath == "") localpath = "default";

                response.ContentType = "";

                if (localpath.EndsWith(".css"))
                {
                    response.ContentType = "text/css";
                };

                if (localpath.EndsWith(".js"))
                {
                    response.ContentType = "text/javascript";
                }

                if (localpath.EndsWith(".woff"))
                {
                    response.ContentType = "font/woff";
                }

                if (localpath.EndsWith(".woff2"))
                {
                    response.ContentType = "font/woff2";
                }

                if (localpath.EndsWith(".ttf"))
                {
                    response.ContentType = "font/ttf";
                }


                if (response.ContentType == "") response.ContentType = "text/html";

                bresponse = null;
                
                try
                {

                    string filename = localpath.Replace("assets/", "").Replace("/", "");

                    if (filename == "") filename = "default";

                    if (!localpath.Contains(".woff") && !localpath.Contains(".ttf"))
                    {
                        if (localpath.Contains("factorinterestelar"))
                        {
                            host.FactoresInterestelar = await inara.FactorInterestelar(host.StarSystem);
                        }

                        if (localpath.Contains("comerciantes"))
                        {
                            host.Comerciantes = await inara.MaterialTrader(host.StarSystem);
                        }
                        sresponse = System.IO.File.ReadAllText(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\" +filename);
                        
                        if (sresponse == null) sresponse = "";

                        if (host != null) sresponse = host.GetWebString(sresponse);

                        bresponse = Encoding.UTF8.GetBytes(sresponse);
                    }
                    else
                    {
                        bresponse = System.IO.File.ReadAllBytes(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\" + filename);
                    }
                    
                }
                catch(Exception ex)
                {
                    sresponse = "";
                }

                try
                {
                    response.OutputStream.Write(bresponse, 0, bresponse.Length);
                    response.OutputStream.Close();
                }
                catch (Exception ex)
                {

                }


                Receive();
            }
        }
    }
}
