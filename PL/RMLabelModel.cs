using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockCraft.PL
{
    public class RMLabelModel
    {
        public string CustomerPartNo { get; set; }   // e.g. 0401EAA05621N

        // Vendor Code - Max 16 Characters
        public string VendorCode { get; set; }

        public string CustomerInitial { get; set; } // e.g. CA34412

        // Mfg Date / Batch No / Lot No - Max 6 Characters (DDMMYY)
        public string MfgDateBatchLotNo { get; set; }  // e.g. 181024

        // Mfg Shift - Max 1 Character (A, B, C, D)
        public string MfgShift { get; set; }

        public string PrinterName { get; set; } // I=A, II=B, III=C, GEN=D

        // Part Serial Number - Reset every shift
        public string PartSerialNumber { get; set; }

        public int NumberOfPrint { get; set; }

       

    }
    
}
