using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Threading;
using Capture;
using Capture.Hook;
using Capture.Hook.Common;
using Capture.Interface;

namespace EDCrew
{
    /// <summary>
    /// Renderer de overlay sobre Direct3D 11 vía la librería Capture. Es el
    /// único sitio que conoce Capture: no sabe nada de Form1, Log, Cursores ni
    /// WhatTo; solo recibe PromptLine. Reemplaza AttachProcess/CreatePrompt/
    /// DrawOverlayInGame de Form1.
    /// </summary>
    public class D3DOverlayRenderer : IOverlayRenderer
    {
        private const int altofuente = 20;

        private static readonly object LogLock = new object();
        private static readonly string LogFile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "overlay.log");

        private CaptureProcess _captureProcess;
        private int _processId;
        private Process _process;
        private Font _font;
        private readonly PanelImageBuilder _panelBuilder = new PanelImageBuilder();

        public bool IsReady
        {
            get { return _captureProcess != null; }
        }

        private static void Log(string message)
        {
            try
            {
                lock (LogLock)
                {
                    File.AppendAllText(LogFile, String.Format("{0:HH:mm:ss.fff} [{1}] {2}{3}", DateTime.Now, Thread.CurrentThread.ManagedThreadId, message, Environment.NewLine));
                }
            }
            catch (Exception)
            {
            }
        }

        public void Draw(IReadOnlyList<PromptLine> lines)
        {
            try
            {
                AttachProcess();

                if (_captureProcess == null) return;

                var elements = new List<IOverlayElement>();

                foreach (PromptLine line in lines)
                {
                    elements.AddRange(CreatePrompt(line.R, line.G, line.B, line.X, line.Y, line.Text));
                }

                _captureProcess.CaptureInterface.DrawOverlayInGame(new Overlay
                {
                    Elements = elements,
                    Hidden = false
                });

                Log("DrawOverlayInGame ok, elements=" + elements.Count);
            }
            catch (Exception ex)
            {
                Log("Draw error: " + ex);
            }
        }

        public void DrawPanel(IReadOnlyList<PromptLine> lines, int cursorRow)
        {
            try
            {
                AttachProcess();

                if (_captureProcess == null) return;

                using (Bitmap panel = _panelBuilder.Build(lines, cursorRow))
                {
                    ImageElement element = OverlayImage.CreateImageElement(panel, new Point(60, 60));
                    _captureProcess.CaptureInterface.DrawOverlayInGame(new Overlay
                    {
                        Elements = new List<IOverlayElement> { element },
                        Hidden = false
                    });
                }

                Log("DrawOverlayInGame ok, panel lines=" + lines.Count);
            }
            catch (Exception ex)
            {
                Log("DrawPanel error: " + ex);
            }
        }

        public void Clear()
        {
            try
            {
                if (_captureProcess != null)
                {
                    _captureProcess.CaptureInterface.DrawOverlayInGame(null);
                }
            }
            catch (Exception ex)
            {
                Log("Clear error: " + ex);
            }
        }

        public void Shutdown()
        {
            try
            {
                _captureProcess?.Dispose();
            }
            catch (Exception ex)
            {
                Log("Shutdown error: " + ex);
            }

            _captureProcess = null;
        }

        private void AttachProcess()
        {
            if (_font == null) _font = new System.Drawing.Font("Euro Caps", altofuente, FontStyle.Regular);

            string exeName = "EliteDangerous64";

            Process[] processes = Process.GetProcessesByName(exeName);
            foreach (Process process in processes)
            {
                if (process.MainWindowHandle == IntPtr.Zero)
                {
                    continue;
                }

                if (HookManager.IsHooked(process.Id))
                {
                    continue;
                }

                Direct3DVersion direct3DVersion = Direct3DVersion.Direct3D11;

                CaptureConfig cc = new CaptureConfig()
                {
                    Direct3DVersion = direct3DVersion,
                    ShowOverlay = true
                };

                _processId = process.Id;
                _process = process;

                var captureInterface = new CaptureInterface();
                captureInterface.RemoteMessage += new MessageReceivedEvent(CaptureInterface_RemoteMessage);
                _captureProcess = new CaptureProcess(process, cc, captureInterface);

                Log("Attached to EliteDangerous64 pid=" + process.Id);
                break;
            }

            if (_captureProcess == null)
            {
                Log("EliteDangerous64 window not found, nothing attached");
            }

            Thread.Sleep(10);
        }

        void CaptureInterface_RemoteMessage(MessageReceivedEventArgs message)
        {
            Log(String.Format("{0}: {1}", message.MessageType, message.Message));
        }

        private List<TextElement> CreatePrompt(byte r, byte g, byte b, int posx, int posy, string prompt)
        {
            var elements = new List<TextElement>();

            elements.Add(new TextElement(_font)
            {
                Location = new Point(posx, posy),
                Color = Color.FromArgb(r, g, b),
                AntiAliased = true,
                Text = prompt
            });

            return (elements);
        }
    }
}
