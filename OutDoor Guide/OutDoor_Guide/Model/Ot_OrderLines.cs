using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace OutDoor_Guide.Model
{
    public class Ot_OrderLines
    {
        public Ot_OrderLines()
        {

        }

        [PrimaryKey, AutoIncrement]
        public int orderlineid { get; set; }
        public int linenumber { get; set; }
        public int articlenumber { get; set; }
        public String description { get; set; }
        public int quantity { get; set; }
        public double weight { get; set; }
        public double volume { get; set; }
        public double unitprice { get; set; }
        public String price { get; set; }
        public String currency { get; set; }
        public int otid { get; set; }
        public int groupline {get;set;}
        public String img { get; set; }
        public int productnumber { get; set; }
        public String sync { get; set; }
        public String columns { get; set; }
    }
}
