using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
namespace OutDoor_Guide.Model
{
    public class OtDetail
    {
        public OtDetail()
        {

        }
        [PrimaryKey,AutoIncrement]
        public int detailid { get; set; }
        public int otid { get; set; }
        public int qte { get; set; }
        public double pu { get; set; }
        public int tva { get; set; }
        public String date { get; set; }
        public int colisage { get; set; }
        public int commande { get; set; }
        public String client { get; set; }
        public String produit { get; set; }
        public String vendeur { get; set; }
        public String prestation { get; set; }
        public double produitpoids { get; set; }
        public double produitvolume { get; set; }
        public int produitscolis  { get; set; }
        public int produitperiodes { get; set; }
        public int etat { get; set; }
        public String datereception { get; set; }
        public String datechargement { get; set; }
        public String dateretourliv { get; set; }
        public String datereexpedition { get; set; }
        public String idsub { get; set; }
        public String codebarre { get; set; }
        public int qterecu { get; set; }
        public int faid { get; set; }
        public double remise { get; set; }
        public double prix { get; set; }
        public int faidtemp { get; set; }
        public double valeuraencaisse { get; set; }
        public double valeurmarchandise { get; set; }
        public String refcmdclient { get; set; }
        public String payment_status { get; set; }
        public double coutprestation { get; set; }
        public String description { get; set; }
        public int processid { get; set; }
        public int hasattachment { get; set; }
        public int servicenumber { get; set; }
        public String servicetype { get; set; }
        public String devcode { get; set; }
        public String devtext { get; set; }
        public String sync { get; set; }
        public String columns { get; set; }
        public int calculpoid { get; set; }
    }
}
