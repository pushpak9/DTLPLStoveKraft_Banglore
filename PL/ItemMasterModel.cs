using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace StockCraft.PL
{
    public class ItemMasterModel
    {
        public int ItemId { get; set; }

        public string Model { get; set; }
        public string Wattage { get; set; }
        public string ProductID { get; set; }
        public string Voltage { get; set; }
        public string Degree { get; set; }

    }
}