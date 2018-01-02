using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace OutDoor_Guide.Model
{
    public class OtDetail_Sat
    {
        public OtDetail_Sat()
        {

        }
        [PrimaryKey,AutoIncrement]
        public int id { get; set; }
        public int serviceid { get; set; }
        public String auteuraction { get; set; }
        public String datechangementstatut { get; set; }
        public int statut { get; set; }
        public String qui { get; set; }
        public int sendstatus { get; set; }
        public String reasoncode { get; set; }
        public String reaso { get; set; }
        public String sync { get; set; }
        public String columns { get; set; }

    }
}
