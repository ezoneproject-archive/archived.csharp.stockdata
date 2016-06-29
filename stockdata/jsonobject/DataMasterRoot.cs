using Newtonsoft.Json;
using stockdata.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stockdata.jsonobject
{
    public class DataMasterCache
    {
        private static DataMasterRoot _dataMaster = null;
        public static DataMasterRoot DataMaster
        {
            get
            {
                if (_dataMaster == null)
                {
                    HttpRestClient client = new HttpRestClient("master");
                    if (!client.doWork())
                    {
                        return null;
                    }

                    try
                    {
                        _dataMaster = JsonConvert.DeserializeObject<DataMasterRoot>(client.getString());
                    }
                    catch (JsonReaderException)
                    {
                        Console.WriteLine("JsonFormat Error!");
                        _dataMaster = null;
                    }
                }

                return _dataMaster;
            }
            private set
            {
                _dataMaster = value;
            }
        }
    }

    public class DataMasterRoot
    {
        public List<MasterList> masterList { get; set; }
        public Metadata _metadata { get; set; }
        public ErrorInfo _errorInfo { get; set; }
    }

    public class MasterList
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<TimeList> timeList { get; set; }
        public List<DataHeader> dataHeader { get; set; }
    }

    public class TimeList
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class DataHeader
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}
