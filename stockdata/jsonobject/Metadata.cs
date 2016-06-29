using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stockdata.jsonobject
{
    public class Metadata
    {
        public int statusCode { get; set; }
        public string ServerName { get; set; }
        public string ClientAddr { get; set; }
        public string RequestMethod { get; set; }
        public string RequestPath { get; set; }
        public string RequestId { get; set; }
    }

    public class ErrorInfo
    {
        public string Type { get; set; }
        public string Message { get; set; }
    }
}
