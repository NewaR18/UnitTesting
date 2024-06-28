using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUnitTesting.Models
{
    internal class ResponseResult
    {
        public Realdata[] data { get; set; }
        public int statusCode { get; set; }
        public string statusText { get; set; }
        public object message { get; set; }
    }
}
