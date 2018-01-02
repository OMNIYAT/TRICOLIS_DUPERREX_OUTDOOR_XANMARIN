using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutDoor_Guide.Model.Results
{
    public class FolderServiceResult
    {
        public FolderServiceResult()
        {

        }

        public String produit { get; set; }
        public int hasattachment { get; set; }
        public int etat { get; set; }
        public int calculpoid { get; set; }
        public double detailid { get; set; }
        public int otid { get; set; }
        public String attchimg { get
            {
                if(hasattachment == 0)
                {
                    return "noattach.png";
                }
                return "pin.png";
            }
        }
    }
}
