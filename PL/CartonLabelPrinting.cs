using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockCraft.PL
{
    public class CartonLabelPrinting
    {
        public int CartonLabelPrintingID { get; set; }
        public String Machine { get; set; }
        public String Department { get; set; }
        public String GradeName { get; set; }
        public String DrawnSizeName { get; set;}
        public String BaseSizeName { get; set;}
        public String ConditionName { get; set; }
        public String ProductName { get; set; }
        public String Speed { get; set; }
        public String SpoolWeight { get; set; }
        public String SpoolCode { get; set; }
        public String CustCode { get; set; }
        public String ToleranceName { get; set; }
        public String HIN { get; set; }
        public String LOT { get; set; }
        public DateTime DATE { get; set; }
        public String SerialNo { get; set; }
        public String CreatedBy { get; set; }

        public String NETWT { get; set; }
        public String CreatedOn { get; set;}
        public String MCWeightBox { get; set;}
        public string Shift  { get; set; }
        public string CustName { get;set;}
        public string fromDate { get; set; }
        public string toDate { get; set; }

    }
}
