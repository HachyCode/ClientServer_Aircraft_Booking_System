using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace LShared
{
    public class DataItemSerialisation
    {
        public static string GetSerialisedDataItem(DataItem dataItem)
        {
            XmlSerializer serialiser = new XmlSerializer(dataItem.GetType());

            using (StringWriter sw = new StringWriter())
            {
                serialiser.Serialize(sw, dataItem);
                return sw.ToString();
            }
        }

        public static DataItem GetDataItem(string serialisedData)
        {
            XmlSerializer deserialiser = new XmlSerializer(typeof(DataItem));

            using (TextReader tr = new StringReader(serialisedData))
            {
                return (DataItem)deserialiser.Deserialize(tr);
            }
        }
    }
}
