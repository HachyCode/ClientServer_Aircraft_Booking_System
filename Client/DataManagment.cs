using System;
using System.Collections.Generic;
using System.Text;

namespace Client
{
    class DataManagment
    {
        public static char[] dataChar;
        public static string data = null;
        public static string message = "error";
        public static char dataSeperation = '¶';
        public static string DataLayout(string dataReseved)
        {
            dataChar = dataReseved.ToCharArray();

            //HTD = Hash Table Data 
            if (dataChar[0] == 'H' && dataChar[1] == 'T' && dataChar[2] == 'D')
            {
                return ManagingHTD();
            }

            return message;
        }

        public static string ManagingHTD()
        {
            //Normaly, should use foreach loop, but it was giving a folty data
            for (int i = 3; i < dataChar.Length; i++)
            {
                //Console.WriteLine($"dataChar[element]: {dataChar[i]} / element: {i}");
                if(dataChar[i] == dataSeperation)
                {
                    data = data + "\n";
                }
                else
                {
                    data = data + dataChar[i];
                }
            }
            return data;
        }
    }
}
