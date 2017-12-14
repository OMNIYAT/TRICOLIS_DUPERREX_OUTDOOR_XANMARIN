using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutDoor_Guide.Model
{
    public class TblReclamations
    {
        public TblReclamations()
        {

        }

        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public int otid { get; set; }
        public int planid { get; set; }
        public int periode { get; set; }
        public String creadate { get; set; }
        public String prestation { get; set; }
        public int prestation_complete { get; set; }
        public String cause { get; set; }
        public String etat { get; set; }
        public String tel_client { get; set; }
        public String mobuser { get; set; }
        public String sync { get; set; }
        public String columns { get; set; }

    }
}
