using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace net_template_web_api.Models
{
    public class ServiceResponse<TData>
    {
        public TData? data { get; set; }
        public bool success { get; set; } = true;
        public string message { get; set; } = string.Empty; // == "" ?
    }
}