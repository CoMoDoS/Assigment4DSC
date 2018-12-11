using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfService1.models
{
    public class Package
    {
        public int id { get; set; }
        public int id_sender { get; set; }
        public int id_reciver { get; set; }
        public string name { get; set; }
        public string sendercity { get; set; }
        public string destinationCity { get; set; }

        public string description { get; set; }
        public bool tracking { get; set; }
        public string route { get; set; }
    }
}