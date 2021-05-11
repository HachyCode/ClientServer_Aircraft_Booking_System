using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    class DataManagmentServer
    {
        public static char[] dataChar;
        public static string data = null;
        public static string message = "error";
        public static char dataSeperation = '¶';
        public static string DataLayout(string dataReseved)
        {
            dataChar = dataReseved.ToCharArray();

            //CFC = Client Flight Chousen
            if (dataChar[0] == 'C' && dataChar[1] == 'F' && dataChar[2] == 'C')
            {
                return ManagingCFC();
            }
            //SHT = Send Hash table
            else if (dataChar[0] == 'S' && dataChar[1] == 'H' && dataChar[2] == 'T')
            {
                return SendHashTable();
            }

            return message;
        }

        public static string ManagingCFC()
        {
            //Normaly, should use foreach loop, but it was giving a folty data
            for (int i = 3; i < dataChar.Length; i++)
            {


                if (dataChar[i] == dataSeperation)
                {
                    
                }
            }
            return data;

            //FID = flight info data
            return "FID" +  ServerModel.FindInput(Int16.Parse(data));
        }

        public static string SendHashTable()
        {
            string hashtable = Hashing.SendHashTable();
            return hashtable;
        }
    }
}
