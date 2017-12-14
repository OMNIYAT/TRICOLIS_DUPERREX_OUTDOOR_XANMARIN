using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace OutDoor_Guide.Model
{
    public class Controls
    {
        public Controls() { }

        [PrimaryKey, AutoIncrement]
        public int idcontrols { get; set; }
        public String nomcontrols { get; set; }
        public String libellecontrols { get; set; }
        public String type { get; set; }
        public String defaut { get; set; }
        public String required { get; set; }
        public String message { get; set; }
        public String descriptionposition { get; set; }
        public int positionx { get; set; }
        public int positiony { get; set; }
        public int idte { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public int sanslabel { get; set; }
        public String sync { get; set; }
        public String columns { get; set; }
            
    }
}
