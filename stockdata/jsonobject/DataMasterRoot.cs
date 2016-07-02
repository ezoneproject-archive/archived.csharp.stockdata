using Newtonsoft.Json;
using stockdata.utils;
using System;
using System.Collections.Generic;

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
                    // 값이 없을 경우 서버에서 받아와서 초기화
                    // 한 번 값을 가져오면 프로그램 재시작까지 캐시한다.
                    HttpRestClient client = new HttpRestClient("master");
                    if (!client.doWorkDialog())
                        return null;

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

        /// <summary>
        /// 데이터 이름으로 마스터 get
        /// </summary>
        /// <param name="dataMasterName"></param>
        /// <returns>null</returns>
        public static MasterList getDataMasterByName(string dataMasterName)
        {
            if (DataMaster == null)
                return null;
            foreach (MasterList item in DataMaster.masterList)
            {
                if (item.name.Equals(dataMasterName))
                    return item;
            }
            return null;
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
