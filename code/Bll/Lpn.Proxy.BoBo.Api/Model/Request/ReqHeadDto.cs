using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Lpn.Proxy.BoBo.Api.Model.Request
{
    public class ReqHeadDto
    { 
        public string partner { get; set; }
        public string key { get; set; }
        public string mdkey { get; set; } 
    }
}
