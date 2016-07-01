using System.Collections.Generic;

namespace stockdata.jsonobject
{
    public class DataRoot
    {
        public List<DataList> dataList { get; set; }
        public Metadata _metadata { get; set; }
        public ErrorInfo _errorInfo { get; set; }
    }

    public class DataList
    {
        public int masterId { get; set; }
        public string gsDate { get; set; }
        public string gsTime { get; set; }
        public string stockCode { get; set; }
        public string stockName { get; set; }
        public int itemKey { get; set; }
        public string itemName { get; set; }
        public string data { get; set; }
    }
}
