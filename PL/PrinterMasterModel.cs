using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockCraft.PL
{
    public class PrinterMasterModel
    {
        public int PrinterId { get; set; }

        public string PrinterIP { get; set; }
        public int? PrinterPort { get; set; }

        public string PrinterIPMC { get; set; }
        public int? PrinterPortMC { get; set; }

        public string ScannerIP { get; set; }
        public int? ScannerPort { get; set; }

        public string PLCIP { get; set; }
        public int? PLCPort { get; set; }

        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string LineCode { get; set; }
    }
}
