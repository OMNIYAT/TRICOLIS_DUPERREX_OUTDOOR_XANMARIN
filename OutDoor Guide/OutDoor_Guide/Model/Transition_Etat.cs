using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace OutDoor_Guide.Model
{
    public class Transition_Etat
    {
        public Transition_Etat() { }

        [PrimaryKey, AutoIncrement]
        public int idte { get; set; }
        public int etat_source { get; set; }
        public int etat_destination { get; set; }
        public int idfamilleetat { get; set; }
        public String nomformulaire { get; set; }
        public String alerte { get; set; }
        public String sync { get; set; }
        public String columns { get; set; }
    }
}
