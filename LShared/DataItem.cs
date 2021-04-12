using System;
using System.Collections.Generic;
using System.Text;

namespace LShared
{
    public class DataItem : ISerialisableData
    {
        public string Id { get; set; }
        private DataItem() { }
        public DataItem(string data)
        {
            Id = data;
        }
    }
}
