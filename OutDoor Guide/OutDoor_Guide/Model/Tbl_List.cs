using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace OutDoor_Guide.Model
{
    public class Tbl_List
    {
        public Tbl_List() { }
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public String name { get; set; }
        public String code { get; set; }
        public int filter { get; set; }
        public int listid { get; set; }
        public int isdefault { get; set; }
        public String sync { get; set; }
        public String columns { get; set; }
    }
}
