using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutDoor_Guide.Model
{
    public class User
    {
        public User(int id,string v1, string v2,int r)
        {
            this.userid = id;
            this.login = v1;
            this.pwd = v2;
            this.ressourceid = r;
        }

        public User() { }

        [PrimaryKey, AutoIncrement]
        public int userid { get; set; }
        public string login { get; set; }
        public string pwd { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public int magasinid { get; set; }
        public int idRole { get; set; }
        public int initialise { get; set; }
        public int ressourceid { get; set; }
        public int applicationid { get; set; }
        public string applicationversion { get; set; }
        public DateTime derniereconnexion { get; set; }
        public int withSync { get; set; }
        public string sync { get; set; }
        public string columns { get; set; }

        public static implicit operator User(List<User> v)
        {
            throw new NotImplementedException();
        }
    }
}
