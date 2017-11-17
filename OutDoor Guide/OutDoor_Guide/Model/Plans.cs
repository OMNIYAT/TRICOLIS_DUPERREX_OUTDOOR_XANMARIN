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
            this.PlanID = id;
            this.PlanInstruction = pi;
            this.PlanCamionID = pcaid;
            this.PlanChauffeurID = pcid;
            this.PlanDate = pd;
            this.PlanSommeRemboursement = 0;
            this.PlanPoidsTotal = ppt;
            this.PlanVolumeTotal = pvt;
            this.PlanChargeMax = 0;
            this.AIDES = aides;
            this.Remorque = 0;
            this.Type_tournees = tt;
            this.PlanPrepUser = 0;
        }

        [PrimaryKey, AutoIncrement]
        public int PlanID { get; set; }
        public string PlanInstruction { get; set; }
        public int PlanCamionID { get; set; }
        public int PlanChauffeurID { get; set; }
        public DateTime PlanDate { get; set; }
        public double PlanSommeRemboursement { get; set; }
        public double PlanSommeValeurTotal { get; set; }
        public double PlanPoidsTotal { get; set; }
        public double PlanVolumeTotal { get; set; }
        public DateTime PlanDateBouclage { get; set; }
        public DateTime PlanDateAquitement { get; set; }
        public int PlanChargeMax { get; set; }
        public int PlanCamionIDProg { get; set;}
        public string PlanBouclage { get; set; }
        public int AccessPlan { get; set; }
        public string CamionCode { get; set; }
        public string AIDES { get; set; }
        public int Remorque { get; set; }
        public string Type_tournees { get; set; }
        public int PlanPrepUser { get; set; }
        public string sync { get; set; }
        public string columns { get; set; }
    }
}
