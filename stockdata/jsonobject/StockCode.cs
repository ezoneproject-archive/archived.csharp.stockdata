using System.Collections.Generic;

namespace stockdata.jsonobject
{
    public class StockCode
    {
        public List<StockCodeItem> dataList { get; set; }
        public Metadata _metadata { get; set; }
    }

    public class StockCodeItem
    {
        public string stockCode { get; set; }
        public string stockName { get; set; }
        public string cateName { get; set; }
    }

}
