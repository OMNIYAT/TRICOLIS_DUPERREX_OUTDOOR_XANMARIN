using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
namespace OutDoor_Guide.Model
{
    public class Ressource
    {
        public Ressource() { }

        [PrimaryKey,AutoIncrement]
        public int ressourceid { get; set; }
        public String ressourcecode { get; set; }
        public String ressourcenom { get; set; }
        public int ressourcefamilleid { get; set; }
        public int fournisseurid { get; set; }
        public String ressourcetel { get; set; }
        public String sync { get; set; }
        public String columns { get; set; }


    }
}
