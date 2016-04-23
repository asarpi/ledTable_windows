using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace serial_ReadAndWrite
{
    class SerialParser
    {

        public static string Parser(string Msg)
        {
            if (Msg.Contains("ACK"))
            {
                return "ACK";
                Console.WriteLine("muhaha");
            }
            else
                return "";
                
        }
    }
}
