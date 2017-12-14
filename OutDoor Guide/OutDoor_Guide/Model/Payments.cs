using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutDoor_Guide.Model
{
    public class Payments
    {
        public Payments()
        {

        }

        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public int otid { get; set; }
        public int detailid { get; set; }
        public String currency { get; set; }
        public double gross { get; set; }
        public int flag { get; set; }
        public String type { get; set; }
        public String sync { get; set; }
        public String columns { get; set; }

    }
}
