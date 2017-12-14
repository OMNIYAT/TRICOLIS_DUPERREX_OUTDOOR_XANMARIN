using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutDoor_Guide.Model
{
    public class Plans
    {
        public Plans() { }

        public Plans(int id,string pi,int pcaid, int pcid, DateTime pd,double ppt, double pvt,string aides,string tt)
        {
            this.planid = id;
            this.planinstruction = pi;
            this.plancamionid = pcaid;
            this.planchauffeurid = pcid;
            this.plandate = pd;
            this.plansommeremboursement = 0;
            this.planpoidstotal = ppt;
            this.planvolumetotal = pvt;
            this.planchargemax = 0;
            this.aides = aides;
            this.remorque = 0;
            this.type_tournees = tt;
            this.planprepuser = 0;
        }
        
        [PrimaryKey, AutoIncrement]
        public int planid { get; set; }
        public string planinstruction { get; set; }
        public int plancamionid { get; set; }
        public int planchauffeurid { get; set; }
        public DateTime plandate { get; set; }
        public double plansommeremboursement { get; set; }
        public double plansommevaleurtotal { get; set; }
        public double planpoidstotal { get; set; }
        public double planvolumetotal { get; set; }
        public DateTime plandatebouclage { get; set; }
        public DateTime plandateaquitement { get; set; }
        public int planchargemax { get; set; }
        public int plancamionidprog { get; set;}
        public string planbouclage { get; set; }
        public int accessplan { get; set; }
        public string camioncode { get; set; }
        public string aides { get; set; }
        public int remorque { get; set; }
        public string type_tournees { get; set; }
        public int planprepuser { get; set; }
        public string sync { get; set; }
        public string columns { get; set; }
    }
}
