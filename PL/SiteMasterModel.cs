using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockCraft.PL
{
    public class SiteMasterModel
    {
        public string SiteCode { get; set; }
        public string SiteName { get; set; }
        public string SiteAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string CreatedBy { get; set; }
        public string Result { get; set; }
    }
}