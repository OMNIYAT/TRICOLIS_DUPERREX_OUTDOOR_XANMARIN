using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace OutDoor_Guide.Model
{
    public class Frais
    {
        public Frais() { }

        [PrimaryKey, AutoIncrement]
        public int idfrais { get; set; }
        public int chauffeurid { get; set; }
        public String fraisdate { get; set; }
        public String typefrais { get; set; }
        public double montantfrais { get; set; }
        public double restearembourse { get; set; }
        public String devise { get; set; }
        public String sync { get; set; }
        public String columns { get; set; }

    }
}
