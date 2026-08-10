using System;
using System.IO.Ports;

namespace EDCrew
{
    /// <summary>
    /// Conexión serie con la caja de botones Arduino. Independiente de Form1:
    /// enumera puertos COM, abre/cierra la conexión (9600 baud) y envía
    /// tramas de 8 bytes por comando.
    /// </summary>
    public class ArduinoService : IDisposable
    {
        private readonly SerialPort _serialPort;

        public ArduinoService()
        {
            _serialPort = new SerialPort();
            _serialPort.DataReceived += SerialPort_DataReceived;
        }

        public bool IsOpen
        {
            get { return _serialPort.IsOpen; }
        }

        public string[] GetPortNames()
        {
            return SerialPort.GetPortNames();
        }

        public void Open(string portName, int baudRate = 9600)
        {
            if (_serialPort.IsOpen) _serialPort.Close();

            _serialPort.PortName = portName;
            _serialPort.BaudRate = baudRate;
            _serialPort.Open();
        }

        public void Close()
        {
            if (_serialPort.IsOpen) _serialPort.Close();
        }

        public void SendCommand(byte[] command)
        {
            if (_serialPort.IsOpen)
                _serialPort.Write(command, 0, 8);
        }

        public event EventHandler DataReceived;

        void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            DataReceived?.Invoke(this, e);
        }

        public void Dispose()
        {
            Close();
            _serialPort.Dispose();
        }
    }
}
