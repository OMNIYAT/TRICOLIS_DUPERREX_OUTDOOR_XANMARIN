using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace OutDoor_Guide.Model
{
    public class TypeFrais
    {
        public TypeFrais() { }
        [PrimaryKey, AutoIncrement]
        public int idtypefrais { get; set; }
        public String typefrais { get; set; }
        public String sync { get; set; }
        public String columns { get; set; }
    }
}
