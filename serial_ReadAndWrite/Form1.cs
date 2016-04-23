using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using serial_ReadAndWrite.Serial;
using System.IO;
using System.Drawing;
using System.Threading;
namespace serial_ReadAndWrite
{
    public partial class Form1 : Form
    {
        //SerialPortManager _spManager;
        CommunicationWithArduino arduino;
        message_struct_t msg;
        command_struct_t cmd;
        // COLOR managger változói
        Color color;
        
        public Form1()
        {
            InitializeComponent();
            init_extension();
            init_color_managger();
        }
        private void init_color_managger()
        {
            cmd.command = 0;
            cmd.redLightValue = 0;
            cmd.greenLightValue = 0;
            cmd.blueLightValue = 0;
        }

        private void init_extension()
        {
            arduino = new CommunicationWithArduino(); 
            txtBox_BoardName.Text = "Arduino Nano with ATmega328";
            txtBox_ConnectedPort.Text = arduino._currentSerialSettings.PortName;
            txtBox_ConnectionBaudRate.Text = Convert.ToString(arduino._currentSerialSettings.BaudRate);

            arduino.NewSerialDataRecieved += new EventHandler<SerialDataEventArgs>(arduino_NewSerialDataRecieved);
            this.FormClosing += new FormClosingEventHandler(MainForm_FormClosing);

        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Console.WriteLine("Muhaha");
        }

        void arduino_NewSerialDataRecieved(object sender, SerialDataEventArgs e)
        {
            if (this.InvokeRequired)
            {
                // Deadlock elkerülése végett
                this.BeginInvoke(new EventHandler<SerialDataEventArgs>(arduino_NewSerialDataRecieved), new object[] { sender, e });
                return;
            }

            int maxTextLength = 1000;
            if (msgBox.TextLength > maxTextLength)
                msgBox.Text = msgBox.Text.Remove(0, msgBox.TextLength - maxTextLength);

            string str = Encoding.ASCII.GetString(e.Data);
            msgBox.AppendText(str);
            arduino.parserMsg(str);
        //    textBox1.Text = SerialParser.Parser(str);
            msgBox.ScrollToCaret();
            txtBox_ConnectionState.Text = "kapcsolódva";   

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            arduino.StartListening();
        }

        private void disconnectButton_Click(object sender, EventArgs e)
        {
            if (!arduino.StopListening())
                txtBox_ConnectionState.Text = "sikertelen szétkapcs.";
            else
                txtBox_ConnectionState.Text = "szétkapcsolva";
        }

        private void sendMsg_button_Click(object sender, EventArgs e)
        {
            try {
                arduino.send(sendMsg_TextBox.Text);
            }
            catch (InvalidOperationException) {
                msgBox.AppendText("Üzenet küldése sikertelen. Nincs nyitva a port!\n");
                msgBox.ScrollToCaret();
            }
        }

        private void button_setColor_Click(object sender, EventArgs e)
        {
            colorDialog.ShowDialog();
            color = colorDialog.Color;
            cmd.redLightValue = color.R;
            cmd.greenLightValue = color.G;
            cmd.blueLightValue = color.B;
        }


        private void button_sendColor_Click(object sender, EventArgs e)
        {
            string color_transition = comboBox_transition.SelectedItem.ToString();
            string color_transitionStepNum = comboBox_transStepNum.SelectedItem.ToString();
            cmd.command = arduino.create_goTo_msg_from_selectedComboBoxItem(color_transition, color_transitionStepNum);
            arduino.sendCmd(cmd);
        }

        private void button_sendWave_Click(object sender, EventArgs e)
        {
            string wave_stepNum = comboBox_wave_stepNum.SelectedItem.ToString();
            string wave_cycNum = comboBox_wave_cycNum.SelectedItem.ToString();
            cmd.redLightValue = Convert.ToInt32(textBox_wave_R.Text);
            cmd.greenLightValue = Convert.ToInt32(textBox_wave_G.Text);
            cmd.blueLightValue = Convert.ToInt32(textBox_wave_B.Text);
            cmd.command = arduino.create_wave_msg_from_comboBoxItem(wave_stepNum, wave_cycNum);
            arduino.sendCmd(cmd);

        }

        private void button_fullWave_Click(object sender, EventArgs e)
        {
            cmd.command = commands.cmd_wave_AllInterVal;
            cmd.redLightValue = 0;
            cmd.greenLightValue = 0;
            cmd.blueLightValue = 0;
            arduino.sendCmd(cmd);

        }

        private void button_start_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Start beta");
            Console.WriteLine(" a: {0}", ProfileManager.a);
            ProfileManager.a = "b";
            ProfileManager profiles = new ProfileManager();
            Console.WriteLine("create thread");
            Console.WriteLine(" a: {0}", ProfileManager.a);
            ProfileManager.a = "b";
            Thread oThread = new Thread(new ThreadStart(profiles.beta));
            Console.WriteLine("thread start");
            Console.WriteLine(" a: {0}", ProfileManager.a);
            ProfileManager.a = "b";
            oThread.Start();
            Console.WriteLine("while thread is not alive");
            Console.WriteLine(" a: {0}", ProfileManager.a);
            ProfileManager.a = "b";
            while (!oThread.IsAlive) ;
            Console.WriteLine("Thread Sleep");
            Console.WriteLine(" a: {0}", ProfileManager.a);
            ProfileManager.a = "b";
            Thread.Sleep(2);
            Console.WriteLine("abort");
            Console.WriteLine(" a: {0}", ProfileManager.a);
            ProfileManager.a = "b";
            oThread.Abort();
            Console.WriteLine("muhaha");
            Console.WriteLine(" a: {0}", ProfileManager.a);
            ProfileManager.a = "b";



        }
    }
}
