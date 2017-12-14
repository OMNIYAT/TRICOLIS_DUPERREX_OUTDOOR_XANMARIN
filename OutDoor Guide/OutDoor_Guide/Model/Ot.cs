using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace OutDoor_Guide.Model
{
    public class Ot
    {
        public Ot() { }

        [PrimaryKey, AutoIncrement]
        public int otid { get; set; }
        public String otnobl { get; set; }
        public double otpOids { get; set; }
        public double otpVolume { get; set; }
        public double otmontrembours { get; set; }
        public double otmontobligatoire { get; set; }
        public double otmontmontage { get; set; }
        public String otnoteinterne { get; set; }
        public DateTime otdatelivraison { get; set; }
        public DateTime otdatemontage { get; set; }
        public int otetat { get; set; }
        public int otperiodesnecessaires { get; set; }
        public int otperiodesnonattributess { get; set; }
        public String otlieuchargement { get; set; }
        public String otdestinnom { get; set; }
        public String otdestprenom { get; set; }
        public String otaddress1 { get; set; }
        public String otaddress2 { get; set; }
        public String ottel1 { get; set; }
        public String ottel2 { get; set; }
        public String otdestemail { get; set; }
        public String otdestnp { get; set; }
        public String otdestville { get; set; }
        public String otdestquartier { get; set; }
        public int userid { get; set; }
        public String codestock { get;  set; }
        public String adresseuite { get; set; }
        public String _currency { get; set; }
        public String shipmenttype { get; set; }
        public DateTime otdatelivdemande { get; set; }
        public DateTime tohour { get; set; }
        public String sync { get; set; }
        public String columns { get; set; }

        
    }
}
