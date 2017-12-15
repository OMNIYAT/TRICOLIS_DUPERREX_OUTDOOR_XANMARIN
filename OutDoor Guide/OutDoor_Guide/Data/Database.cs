using OutDoor_Guide.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutDoor_Guide.Data
{
    public class Database
    {
        readonly SQLiteAsyncConnection database;

        public Database(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<User>().Wait();
            database.CreateTableAsync<Plans>().Wait();
            database.CreateTableAsync<Communications>().Wait();
            database.CreateTableAsync<Controls>().Wait();
            database.CreateTableAsync<Frais>().Wait();
            database.CreateTableAsync<Ot>().Wait();
            database.CreateTableAsync<OtDetail>().Wait();
            database.CreateTableAsync<OtDetailOrderLines>().Wait();
            database.CreateTableAsync<OtDetailPackageLines>().Wait();
            database.CreateTableAsync<OtDetailSat>().Wait();
            database.CreateTableAsync<OtOrderLines>().Wait();
            database.CreateTableAsync<OtPackages>().Wait();
            database.CreateTableAsync<PackageHistorique>().Wait();
            database.CreateTableAsync<Payments>().Wait();
            database.CreateTableAsync<Periodes>().Wait();
            database.CreateTableAsync<Produits>().Wait();
            database.CreateTableAsync<Ressource>().Wait();
            database.CreateTableAsync<TblList>().Wait();
            database.CreateTableAsync<TblReclamations>().Wait();
            database.CreateTableAsync<TblTlist>().Wait();
            database.CreateTableAsync<Transition>().Wait();
            database.CreateTableAsync<TransitionEtat>().Wait();
            database.CreateTableAsync<TrcPlanCaracteristiques>().Wait();
            database.CreateTableAsync<TypeFrais>().Wait();
        }

        

        public void sampleData()
        {
            User user = new User(1,"Alex","1144",124);
            database.InsertOrReplaceAsync(user);

            Plans p = new Plans(1,"neuchatel getaz",138,124,new DateTime(2017,11,14),2315.89306640625,12.054499626,"MANU","TAXI MEUBLES");
            Plans p1 = new Plans(3143130, "Lausanne 10h", 138, 124, new DateTime(2017,11,12), 2315.89306640625, 12.054499626, "MANU", "TAXI MEUBLES");
            database.InsertOrReplaceAsync(p);
            database.InsertOrReplaceAsync(p1);

            Periodes pe = new Periodes();
            pe.periodeid = new DateTime();
            pe.periodeplanid = 3143130;
            pe.periodeotid = 0;
            database.InsertOrReplaceAsync(pe);

            Ot o = new Ot();
            o.otid = 3143130;
            o.otnobl = "002-TR3678422";
            o.otpOids = 77.276;
            o.otpVolume = 0.151;
            o.otmontrembours = 0;
            o.otmontobligatoire = 0;
            o.otmontmontage = 0;
            o.otnoteinterne = "Info. : appeler le 079532 12 54    M. Farinha[Sep]camion : [Sep]étage : rez[Sep]";
            o.otdatelivraison = new DateTime();
            o.otdatemontage = new DateTime();
            o.otetat = 32;
            o.otperiodesnecessaires = 2;
            o.otperiodesnonattributess = 0;
            o.otlieuchargement = "* TRIAL * TRIAL";
            o.otdestinnom = "Duperrex Frères SA";
            o.otaddress1 = "Route d'Apples 6, 1144 Ballens, Suisse";
            o.ottel1 = "079 622 26 19";
            o.otdestnp = "1144";
            o.otdestville = "Ballens";
            o._currency = "CHF";
            o.otdatelivdemande = new DateTime();
            o.tohour = new DateTime();
            database.InsertOrReplaceAsync(o);
        }

        public async Task DeleteFrais(List<int> delIds)
        {
            String ids = string.Join(",", delIds.ToArray());
            var query = database.Table<Frais>().Where(f => delIds.Contains(f.idfrais));
            await query.ToListAsync().ContinueWith(async (t) =>
            {
                foreach (var temp in t.Result)
                {
                    await database.DeleteAsync(temp);
                }
            });
            
        }

        #region User
        /// <summary>
        /// Get users list
        /// </summary>
        /// <returns></returns>
        public Task<List<User>> GetUsersAsync()
        {
            return database.Table<User>().ToListAsync();
        }

        /// <summary>
        /// Authenticate user
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Task<List<User>> GetUser(String username, String password)
        {
            //return database.QueryAsync<User>("SELECT * FROM [User] WHERE [login] = ? and [pwd] = ?", username, password);
            return database.QueryAsync<User>("SELECT * FROM [users]");
        }

        /// <summary>
        /// Get uesr by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<User> GetUserAsync(int id)
        {
            return database.Table<User>().Where(i => i.userid == id).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Save user to database
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Task<int> SaveUserAsync(User user)
        {
            if (user.userid != 0)
            {
                return database.UpdateAsync(user);
            }
            else
            {
                return database.InsertAsync(user);
            }
        }

        /// <summary>
        /// Delete user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Task<int> DeleteUserAsync(User user)
        {
            return database.DeleteAsync(user);
        }
        #endregion


        #region Plan

        /// <summary>
        /// Get plans of given RessourceID
        /// </summary>
        /// <param name="ResId"></param>
        /// <returns></returns>
        public Task<List<Plans>> GetMyPlans(int ResId)
        {
            //HeightRequest
            return database.QueryAsync<Plans>("SELECT * FROM [Plans] where [planchauffeurid] = ?", ResId);
        }

        /// <summary>
        /// Get Plan by ID
        /// </summary>
        /// <param name="resid"></param>
        /// <returns></returns>
        public Task<List<Plans>> GetPlanById(int pid)
        {
            return database.QueryAsync<Plans>("Select * from [Plans] where planid = ?", pid);
        }
        #endregion

        /// <summary>
        /// Get Delivery From By Plan ID
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public Task<List<DeliveryFormModel>> GetDeliveryFromByPlanID(int pid)
        {
            return database.QueryAsync<DeliveryFormModel>("SELECT  OT.otdestinnom, OT.otdestville, ot.otdestnp, MIN(periodes.periodeid) as Periode, count(OT.otid) as COUNT, SUM(OT.otetat) as SUM, CASE WHEN Cast(julianday(MIN(periodes.periodeID)) - julianday(min(OT.otdatelivdemande)) as Integer) = 0 THEN min(ot.otdatelivdemande) ELSE null end as [FROM], CASE WHEN Cast(julianday(MIN(periodes.periodeID)) - MAX(ot.tohour) as integer) = 0 THEN max(OT.tohour) ELSE NULL end as [To] from OT INNER join periodes on OT.otid = periodes.periodeOTID where OT.otid <> 1 and periodes.periodeplanid =? group by OT.otdestinnom, OT.otdestville, OT.otdestnp order by periode", pid);
        }

        /// <summary>
        /// Get Folder Service By OTID
        /// </summary>
        /// <param name="otid"></param>
        /// <returns></returns>
        public Task<List<OtDetail>> GetFolderServiceByOtID(int otid)
        {
            return database.QueryAsync<OtDetail>("select otdetail.produit, otdetail.hasattachment, otdetail.etat, produits.calculpoid, otdetail.detailid, otdetail.otid from otdetail inner join produits on otdetail.produit = produits.produit where (otdetail.otid in (?)) and(produits.calculpoid >= -1)", otid);
        }

        /// <summary>
        /// Get OT by id
        /// </summary>
        /// <param name="otid"></param>
        /// <returns></returns>
        public Task<List<Ot>> GetOTById(int otid)
        {
            return database.QueryAsync<Ot>("select * from ot where otid = ?", otid);
        }

        /// <summary>
        /// Get all frais type
        /// </summary>
        /// <returns></returns>
        public Task<List<TypeFrais>> GetAllFraisType()
        {
            return database.QueryAsync<TypeFrais>("select * from TypeFrais");
        }

        /// <summary>
        /// Get Frais by Plan ID
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public Task<List<Frais>> GetFraisByPID(int pid)
        {
            return database.QueryAsync<Frais>("select idfrais, typefrais, montantfrais, devise from [frais] where chauffeurid=?", pid);
        }

        public async Task SaveFrais(Frais f)
        {
            try
            {
                Frais lastItem = await database.Table<Frais>().OrderByDescending(u => u.idfrais).FirstOrDefaultAsync();
                if (lastItem != null)
                {
                    f.idfrais = lastItem.idfrais + 1;
                }
                else
                {
                    f.idfrais = 1;
                }
                
                await database.InsertOrReplaceAsync(f);
            }catch(Exception e)
            {
                var z = 0;
            }
        }


    }
}
