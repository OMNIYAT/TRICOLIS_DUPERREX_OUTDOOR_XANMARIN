using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace OutDoor_Guide.Model
{
    public class PackageHistorique
    {
        public PackageHistorique()
        {

        }

        public int idpackagehistorique { get; set; }
        public int id { get; set; }
        public String auteuraction { get; set; }
        public String datechangementstatut { get; set; }
        public int statut { get; set; }
        public String qui { get; set; }
        public int sendstatus { get; set; }
        public String sync { get; set; }
        public String columns { get; set; }
    }
}
