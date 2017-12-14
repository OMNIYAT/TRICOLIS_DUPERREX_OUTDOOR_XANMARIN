using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutDoor_Guide.Model
{
    public class Produits
    {
        public Produits()
        {

        }
        public String produit { get; set; }
        public String designation { get; set; }
        public int produitid { get; set; }
        public int produit_id { get; set; }
        public int scanneorders { get; set; }
        public int scannepackages { get; set; }
        public int sendstatus { get; set; }
        public int calculpoid { get; set; }
        public String sync { get; set; }
        public String columns { get; set; }
    }
}
