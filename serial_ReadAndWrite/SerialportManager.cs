using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Reflection;
using System.ComponentModel;
using System.Threading;
using System.IO;

namespace serial_ReadAndWrite.Serial
{
    public class SerialDataEventArgs : EventArgs
    {
        public byte[] Data;
        public SerialDataEventArgs(byte[] dataInByteArray)
        {
            Data = dataInByteArray;
        }
    }
    public class SerialPortManager: IDisposable
    {
        #region __init__
        private SerialPort _serialPort = new SerialPort("COM3", 9600);
        public SerialSettings _currentSerialSettings = new SerialSettings();
        private string _latestRecieved = String.Empty;
        public event EventHandler<SerialDataEventArgs> NewSerialDataRecieved;
        public SerialSettings CurrentSerialSettings
        {
            get { return _currentSerialSettings; }
            set { _currentSerialSettings = value; }
        }


        public SerialPortManager()
        {
            //létező serial portok keresése
            _currentSerialSettings.PortNameCollection = SerialPort.GetPortNames();
            Console.WriteLine("talált COM portok:");
            foreach (string name in _currentSerialSettings.PortNameCollection)
            {
                Console.WriteLine(name);
            }

            _currentSerialSettings.PortName = _currentSerialSettings.PortNameCollection[0];
            _currentSerialSettings.BaudRate = 9600;
            _currentSerialSettings.DataBits = 8;
            _currentSerialSettings.Parity = Parity.None;
            _currentSerialSettings.StopBits = StopBits.One;

            //beállítjuk a talált COM portot
            _serialPort.PortName = _currentSerialSettings.PortName;
            

            /*Console.WriteLine("the following parameters are set:\n\tport: {0}\n\tBaud: {1}\n\tDatabits: {2}\n\tParity: {3}\n\tStopBits: {4}", _currentSerialSettings.PortName,
                _currentSerialSettings.BaudRate, _currentSerialSettings.DataBits, _currentSerialSettings.Parity, _currentSerialSettings.StopBits);
                */
            //Thread event generálása
          //  _currentSerialSettings.PropertyChanged += new PropertyChangedEventHandler(_currentSerialSettings_PropertyChanged);
        }

        ~SerialPortManager()
        {
            Dispose(false);
        }

        #endregion
        #region Handlers
        //függvény a beállítások változásának kezelésére
        /*
        void _currentSerialSettings_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //ha a serial port megváltozott, akkor talán új baud rate is kell
            if (e.PropertyName.Equals("PortName"))
                UpdateBaudRateCollection();
                
        }*/
        /// <summary>
        /// Handler az érkezett üzenetek elkapására
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        void _serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int dataLength = _serialPort.BytesToRead;
            byte[] data = new byte[dataLength];
            int nbrDataRead = _serialPort.Read(data, 0, dataLength);
            if (nbrDataRead == 0)
                return;

            if (NewSerialDataRecieved != null)
                NewSerialDataRecieved(this, new SerialDataEventArgs(data));
        }

        #endregion

        #region Methods

        /// <summary>
        /// Csatlakozás a Serial porthoz az előre definiált paraméterek szerint
        /// </summary>
        public bool StartListening()
        {
            //ha még nyitva volt a port, akkor bezárjuk, és újranyitjuk
            if (_serialPort != null && _serialPort.IsOpen)
                _serialPort.Close();
            
            //új üzenet handlerének beállítása
            _serialPort.DataReceived += new SerialDataReceivedEventHandler(_serialPort_DataReceived);
            //port nyitára
            _serialPort.Open();
            //reset jel küldése (magától a c# nem teszi meg)
            _serialPort.DtrEnable = true;
            return (_serialPort != null && _serialPort.IsOpen);
            
        }

        /// <summary>
        /// Serial port bezárása
        /// </summary>
        public bool StopListening()
        {
            _serialPort.Close();
            return (_serialPort != null && !_serialPort.IsOpen);
        }
        /// <summary>
        /// Msg küldése
        /// </summary>
        /// <param name="msg">string</param>
        public void SendMessage(string msg)
        {
                _serialPort.Write(msg);
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _serialPort.DataReceived -= new SerialDataReceivedEventHandler(_serialPort_DataReceived);
            }
           if (_serialPort != null)
            {
                if (_serialPort.IsOpen)
                    _serialPort.Close();

                _serialPort.Dispose();
            }
        }
        /// <summary>
        /// függvény a BAUD rate collection update-jére
        /// </summary>
        private void UpdateBaudRateCollection()
        {
            _serialPort = new SerialPort(_currentSerialSettings.PortName);
            _serialPort.Open();
            object p = _serialPort.BaseStream.GetType().GetField("commProp",
                BindingFlags.Instance |
                BindingFlags.NonPublic).GetValue(_serialPort.BaseStream);
            Int32 dwSettableBaud = (Int32)p.GetType().GetField("dwSettableBaud",
                BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public).GetValue(p);

            _serialPort.Close();
            _currentSerialSettings.UpdateBaudRateCollection(dwSettableBaud);

        }

        #endregion

    }

}
