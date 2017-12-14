using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutDoor_Guide.Model
{
    public class Communications
    {
        public Communications()
        {

        }
       
        [PrimaryKey, AutoIncrement]
        public int comid { get; set; }
        public int otid { get; set; }
        public String otnobl { get; set; }
        public String comtype { get; set; }
        public String comdate { get; set; }
        public String commessage { get; set; }
        public String Commoyen { get; set; }
        public int comvalidation { get; set; }
        public int ressourceid { get; set; }
        public String ressource { get; set; }
        public int comtransmis { get; set; }
        public String np { get; set; }
        public String textetemplate { get; set; }
        public String sync { get; set; }
        public String columns { get; set; }


    }
}
