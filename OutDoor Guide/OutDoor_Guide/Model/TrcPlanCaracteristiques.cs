using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace OutDoor_Guide.Model
{
    public class TrcPlanCaracteristiques
    {
        public TrcPlanCaracteristiques()
        {

        }
        
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public int planid { get; set; }
        public int pleingarage { get; set; }
        public int pleinexterieur { get; set; }
        public double litres { get; set; }
        public double chf { get; set; }
        public double kmarrive { get; set; }
        public double kmdepart { get; set; }
        public double kmparcourus { get; set; }
        public double liquide { get; set; }
        public double cc { get; set; }
        public double cheque { get; set; }
        public String heuredepart { get; set; }
        public String heurearrive { get; set; }
        public String decompte { get; set; }
        public String pressionpneuapres { get; set; }
        public String pressionpneuavant { get; set; }
        public String sync { get; set; }
        public String columns { get; set; }

    }
}
