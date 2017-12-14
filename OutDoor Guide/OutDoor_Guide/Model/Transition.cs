using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace OutDoor_Guide.Model
{
    public class Transition
    {
        public Transition() { }

        [PrimaryKey,AutoIncrement]
        public int idtransition { get; set; }
        public String source { get; set; }
        public String destination { get; set; }
        public String sync { get; set; }
        public String columns { get; set; }

    }
}
