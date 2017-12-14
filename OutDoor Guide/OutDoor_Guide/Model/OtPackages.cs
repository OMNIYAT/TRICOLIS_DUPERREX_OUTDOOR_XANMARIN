using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace OutDoor_Guide.Model
{
    public class OtPackages
    {
        public OtPackages()
        {

        }

        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public double weight { get; set; }
        public double volume { get; set; }
        public String ddc { get; set; }
        public String datelivraison { get; set; }
        public String dateexpedition { get; set; }
        public int scanned { get; set; }
        public int otid { get; set; }
        public String datereception { get; set; }
        public String packagenumber { get; set; }
        public String statut { get; set; }
        public int idemplacement { get; set; }
        public String img { get; set; }
        public int optional { get; set; }
        public String sync { get; set; }
        public String columns { get; set; }
    }
}
