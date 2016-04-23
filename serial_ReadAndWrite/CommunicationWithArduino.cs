using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using serial_ReadAndWrite.Serial;

namespace serial_ReadAndWrite
{
    enum preDefined_messages_enum
    {
        msg_ACK = 10,
        msg_CMD_ACK = 11,
        msg_SPEC_DELAYTIME = 50,
        msg_NOT_ACK = 99,
        msg_CMD_NOT_ACK = 98,
        msg_ACTUALSTATE = 1

    }
    
    public enum commands : int
    {
        cmd_setBlack = 0, //teljes sötétség
        cmd_setWhite = 1, //teljes világosság
        cmd_setRGB = 2, //kívánt RGB beállítása
        cmd_SPECIAL_set_rgbDELAY = 3, //template indexek: 34 - cmd, 678 - delaytime
        cmd_goTo_Linear = 10,

        cmd_goTo_Linear_WithStep_2 = 11, //a kívánt RGB kombináció elérése N lépésben lineáris skálán haladva
        cmd_goTo_Linear_WithStep_5 = 12,
        cmd_goTo_Linear_WithStep_10 = 13,
        cmd_goTo_Linear_WithStep_15 = 14,
        cmd_goTo_Linear_WithStep_30 = 15,
        cmd_goTo_Linear_WithStep_50 = 16,
        cmd_goTo_Linear_WithStep_65 = 17,
        cmd_goTo_Linear_WithStep_80 = 18,
        cmd_goTo_Linear_WithStep_100 = 19,


        cmd_goTo_Sine_WithStep_2 = 21, //a kívánt RGB kombináció elérése N lépésben szinuszos skálán haladva
        cmd_goTo_Sine_WithStep_5 = 22,
        cmd_goTo_Sine_WithStep_10 = 23,
        cmd_goTo_Sine_WithStep_15 = 24,
        cmd_goTo_Sine_WithStep_30 = 25,
        cmd_goTo_Sine_WithStep_50 = 26,
        cmd_goTo_Sine_WithStep_65 = 27,
        cmd_goTo_Sine_WithStep_80 = 28,
        cmd_goTo_Sine_WithStep_100 = 29,

        cmd_goTo_Exp = 30,              //exponenciális teljes kivilágosodás, majd elsötétülés, majd visszatérés az eredeti értékhez
        cmd_goTo_Exp_WithStep_2 = 31, //a kívánt RGB kombináció elérése N lépésben exponenciális skálán haladva
        cmd_goTo_Exp_WithStep_5 = 32,
        cmd_goTo_Exp_WithStep_10 = 33,
        cmd_goTo_Exp_WithStep_15 = 34,
        cmd_goTo_Exp_WithStep_30 = 35,
        cmd_goTo_Exp_WithStep_50 = 36,
        cmd_goTo_Exp_WithStep_65 = 37,
        cmd_goTo_Exp_WithStep_80 = 38,
        cmd_goTo_Exp_WithStep_100 = 39,

        cmd_wave_AllInterVal = 50, // a teljes intervallumon végighaladás szinuszos hullámmal, majd visszatérés az eredeti értékhez
        cmd_wave_Step20_cyc1 = 51,//a kívánt RGB kombinációjú amplitudóval ingadozás szinuszosan N lépésben és M cikluson keresztül
        cmd_wave_Step40_cyc1 = 52,
        cmd_wave_Step60_cyc1 = 53,
        cmd_wave_Step20_cyc2 = 54,
        cmd_wave_Step40_cyc2 = 55,
        cmd_wave_Step60_cyc2 = 56,
        cmd_wave_Step20_cyc3 = 57,
        cmd_wave_Step40_cyc3 = 58,
        cmd_wave_Step60_cyc3 = 59,

        cmd_get_ActualRGB = 91, //aktuális RGB kombináció lekérdezése
        cmd_get_SPEC_rgbDelayTime = 92, //aktuális DELAY lekérdezése (a redLightValues mezőben küldve, a többi 0)
    }

    struct message_struct_t
    {
        public int message;
        public int redLightValue;
        public int greenLightValue;
        public int blueLightValue;
    }
    struct command_struct_t
    {
        public commands command;
        public int redLightValue;
        public int greenLightValue;
        public int blueLightValue;
    }
    class CommunicationWithArduino : SerialPortManager
    {
        private message_struct_t msg;
        private command_struct_t cmd;
        private LinkedList<string> msgList; // = new LinkedList<string>();
        private string msg_string = null;
        

        #region private methods

        private int decode_2chars(char c_0, char c_1)
        {
            return (Convert.ToInt16(c_0) - 48) * 10 + Convert.ToInt16(c_1) - 48;
        }

        private int decode_3chars(char c_0, char c_1, char c_2)
        {
            return (Convert.ToInt16(c_0) - 48) * 100 + (Convert.ToInt16(c_1) - 48) * 10 + Convert.ToInt16(c_2) - 48;
        }

        private string encode_num(int num, byte num_of_outputChars)
        {
            if (num_of_outputChars == 2)
            {
                if (num < 10)
                    return "0" + Convert.ToString(num);
                else if (num >= 100)
                    return "99";
                else
                    return Convert.ToString(num);
            }
            else if (num_of_outputChars == 3)
            {
                if (num < 10)
                    return "00" + Convert.ToString(num);
                else if (num < 100)
                    return "0" + Convert.ToString(num);
                else if (num >= 1000)
                    return "999";
                else
                    return Convert.ToString(num);
            }
            else
                return Convert.ToString(num);    
        }
        #endregion

        public CommunicationWithArduino() : base()
        {
            msgList = new LinkedList<string>();
        }
        public void send(String message)
        {
            SendMessage(message);
        }

        public void parserMsg(string message)
        {
            //ha az üzenet utolsó karaktere soremelés
            if (Convert.ToInt16(message[message.Length - 1]) == 10)
            {   
                //hozzáadjuk az utolsó üzenetdarabkát a listához, majd összevonjuk, és eltároljuk egy string-be
                msgList.AddLast(message);
                msg_string = null;
                foreach (string message_piece in msgList)
                {
                    msg_string += message_piece;
                    msgList = new LinkedList<string>();
                }
                //megnézzük, hogy megfelel-e az üzenet a protokoll szabványának
                if (msg_string.Length == 22 &&
                    msg_string[0].Equals('0') && msg_string[1].Equals('1') &&
                    msg_string[2].Equals('_') &&
                    msg_string[msg_string.Length - 4].Equals('1') && msg_string[msg_string.Length - 3].Equals('0'))
                {
                    // 01_34_678_012_456_89
                    msg.message = decode_2chars(msg_string[3], msg_string[4]);
                    msg.redLightValue = decode_3chars(msg_string[6], msg_string[7], msg_string[8]);
                    msg.greenLightValue= decode_3chars(msg_string[10], msg_string[11], msg_string[12]);
                    msg.blueLightValue = decode_3chars(msg_string[14], msg_string[15], msg_string[16]);
                } 
            }
            else
            {
                msgList.AddLast(message);
            }
        }

        public void sendCmd(command_struct_t command_struct)
        {
            string msg_string = "01_" +
                encode_num(command_struct.command.GetHashCode(), 2) + "_" +
                encode_num(command_struct.redLightValue, 3) + "_" +
                encode_num(command_struct.greenLightValue, 3) + "_" +
                encode_num(command_struct.blueLightValue, 3) + "_10";
            send(msg_string);
        }
        public void sendCmd(commands command, int red, int green, int blue)
        {
            command_struct_t command_struct;
            command_struct.command = command;
            command_struct.redLightValue = red;
            command_struct.greenLightValue = green;
            command_struct.blueLightValue = blue;
            sendCmd(command_struct);
        }

        public commands create_goTo_msg_from_selectedComboBoxItem(string transitionName, string stepNum )
        {
            int step = Convert.ToInt16(stepNum);
            int msg_num = 0;
            commands command = 0;

            switch (transitionName)
            {
                case "lineáris":
                    switch (step)
                    {
                        case 2: command = commands.cmd_goTo_Linear_WithStep_2; break;
                        case 5: command = commands.cmd_goTo_Linear_WithStep_5; break;
                        case 10: command = commands.cmd_goTo_Linear_WithStep_10; break;
                        case 15: command = commands.cmd_goTo_Linear_WithStep_15; break;
                        case 30: command = commands.cmd_goTo_Linear_WithStep_30; break;
                        case 50: command = commands.cmd_goTo_Linear_WithStep_50; break;
                        case 65: command = commands.cmd_goTo_Linear_WithStep_65; break;
                        case 80: command = commands.cmd_goTo_Linear_WithStep_80; break;
                        case 100: command = commands.cmd_goTo_Linear_WithStep_100; break;
                        default:
                            msg_num = commands.cmd_goTo_Linear_WithStep_10.GetHashCode();
                            break;
                    }
                    break;
                case "szinuszos":
                    switch(step)
                    {
                        case 2: command = commands.cmd_goTo_Sine_WithStep_2; break;
                        case 5: command = commands.cmd_goTo_Sine_WithStep_5; break;
                        case 10: command = commands.cmd_goTo_Sine_WithStep_10; break;
                        case 15: command = commands.cmd_goTo_Sine_WithStep_15; break;
                        case 30: command = commands.cmd_goTo_Sine_WithStep_30; break;
                        case 50: command = commands.cmd_goTo_Sine_WithStep_50; break;
                        case 65: command = commands.cmd_goTo_Sine_WithStep_65; break;
                        case 80: command = commands.cmd_goTo_Sine_WithStep_80; break;
                        case 100: command = commands.cmd_goTo_Sine_WithStep_100; break;
                        default:
                            command = commands.cmd_goTo_Sine_WithStep_30;
                            break;
                    }
                    break;
                
                case "exponenciális":
                    switch(step)
                    {
                        case 2: command = commands.cmd_goTo_Exp_WithStep_2; break;
                        case 5: command = commands.cmd_goTo_Exp_WithStep_5; break;
                        case 10: command = commands.cmd_goTo_Exp_WithStep_10; break;
                        case 15: command = commands.cmd_goTo_Exp_WithStep_15; break;
                        case 30: command = commands.cmd_goTo_Exp_WithStep_30; break;
                        case 50: command = commands.cmd_goTo_Exp_WithStep_50; break;
                        case 65: command = commands.cmd_goTo_Exp_WithStep_65; break;
                        case 80: command = commands.cmd_goTo_Exp_WithStep_80; break;
                        case 100: command = commands.cmd_goTo_Exp_WithStep_100; break;
                        default:
                            command = commands.cmd_goTo_Exp_WithStep_30;
                            break;
                    }
                    break;
                default:
                    command = commands.cmd_setBlack;
                    break;
            }

            return command;
        }

        public commands create_wave_msg_from_comboBoxItem(string step_string, string cyc_string)
        {
            switch(cyc_string)
            {
                case "1": 
                    switch(step_string)
                    {
                        case "20": return commands.cmd_wave_Step20_cyc1;
                        case "40": return commands.cmd_wave_Step20_cyc1;
                        case "60": return commands.cmd_wave_Step20_cyc1;
                    }
                    break;
                case "2":
                    switch(step_string)
                    {
                        case "20": return commands.cmd_wave_Step20_cyc2;
                        case "40": return commands.cmd_wave_Step20_cyc2;
                        case "60": return commands.cmd_wave_Step20_cyc2;
                    }
                    break;
                case "3":
                    switch(step_string)
                    {
                        case "20": return commands.cmd_wave_Step20_cyc3;
                        case "40": return commands.cmd_wave_Step20_cyc3;
                        case "60": return commands.cmd_wave_Step20_cyc3;
                    }
                    break;
            }
            return commands.cmd_wave_AllInterVal;
        }


    }
}
