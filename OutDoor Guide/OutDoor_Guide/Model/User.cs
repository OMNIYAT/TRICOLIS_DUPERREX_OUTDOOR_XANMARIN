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
            this.UserID = id;
            this.Login = v1;
            this.Pwd = v2;
            this.RessourceID = r;
        }

        public User() { }

        [PrimaryKey, AutoIncrement]
        public int UserID { get; set; }
        public string Login { get; set; }
        public string Pwd { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public int MagasinID { get; set; }
        public int IdRole { get; set; }
        public int Initialise { get; set; }
        public int RessourceID { get; set; }
        public int ApplicationID { get; set; }
        public string ApplicationVersion { get; set; }
        public DateTime DerniereConnexion { get; set; }
        public int WithSync { get; set; }
        public string Sync { get; set; }
        public string Columns { get; set; }

        public static implicit operator User(List<User> v)
        {
            throw new NotImplementedException();
        }
    }
}
