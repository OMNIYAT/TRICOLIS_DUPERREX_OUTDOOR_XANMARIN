using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutDoor_Guide.Model
{
    public class OtDetailOrderLines
    {
        public OtDetailOrderLines() { }

        public int itemid { get; set; }
        public String type { get; set; }
        public int linenumber { get; set; }
        public String itemnumber { get; set; }
        public String description { get; set; }
        public int quantityordered { get; set; }
        public String quantitytype { get; set; }
        public double totalnumberofpackages { get; set; }
        public double totalweight { get; set; }
        public int detailid { get; set; }
        public int orderlineid { get; set; }
        public String codestock { get; set; }
        public String dateentree { get; set; }
        public String from { get; set; }
        public String to { get; set; }
        public String dateoperation { get; set; }
        public String sync { get; set; }
        public String columns { get; set; }
    }
}
