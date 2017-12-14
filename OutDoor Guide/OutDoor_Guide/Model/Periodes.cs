using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace OutDoor_Guide.Model
{
    public class Periodes
    {
        public Periodes() { }

        public DateTime periodeid { get; set; }
        public int periodeplanid { get; set; }
        public int periodeotid { get; set; }
        public String periodecommunicationimportante { get; set; }
        public String periode { get; set; }
        public double periodeotpoids { get; set; }
        public double periodeotvolume { get; set; }
        public double periodeotrem { get; set; }
        public String periodeotdesc { get; set; }
        public String receptionsms { get; set; }
        public String receptionemail { get; set; }
        public String datereception { get; set; }
        public int tpsmontage { get; set; }
        public String periodesaved { get; set; }
        public int idcontrol { get; set; }
        public String sync { get; set; }
        public String columns { get; set; }

    }
}
