using OutDoor_Guide.Helpers;
using OutDoor_Guide.Model;
using OutDoor_Guide.Model.Results;
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
            database.CreateTableAsync<OtDetail_OrderLines>().Wait();
            database.CreateTableAsync<OtDetail_PackageLines>().Wait();
            database.CreateTableAsync<OtDetail_Sat>().Wait();
            database.CreateTableAsync<Ot_OrderLines>().Wait();
            database.CreateTableAsync<Ot_Packages>().Wait();
            database.CreateTableAsync<PackageHistorique>().Wait();
            database.CreateTableAsync<Payments>().Wait();
            database.CreateTableAsync<Periodes>().Wait();
            database.CreateTableAsync<Produits>().Wait();
            database.CreateTableAsync<Ressource>().Wait();
            database.CreateTableAsync<Tbl_List>().Wait();
            database.CreateTableAsync<Tbl_Reclamations>().Wait();
            database.CreateTableAsync<Tbl_Tlist>().Wait();
            database.CreateTableAsync<Transition>().Wait();
            database.CreateTableAsync<Transition_Etat>().Wait();
            database.CreateTableAsync<Trc_Plan_Caracteristiques>().Wait();
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

        public Task<List<Trc_Plan_Caracteristiques>> GetInfosByPID(int planID)
        {
            return database.QueryAsync<Trc_Plan_Caracteristiques>("select * from [Trc_Plan_Caracteristiques] where planid=?", planID);
        }

        /// <summary>
        /// Save info
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public async Task SaveInfo(Trc_Plan_Caracteristiques info)
        {
            try
            {
                Trc_Plan_Caracteristiques lastItem = await database.Table<Trc_Plan_Caracteristiques>().OrderByDescending(u => u.id).FirstOrDefaultAsync();
                if (lastItem != null)
                {
                    info.id = lastItem.id + 1;
                }
                else
                {
                    info.id = 1;
                }

                await database.InsertOrReplaceAsync(info);
            }
            catch (Exception e)
            {
                var z = 0;
            }
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

        public async Task DeleteInfos(List<int> delIds)
        {
            String ids = string.Join(",", delIds.ToArray());
            var query = database.Table<Trc_Plan_Caracteristiques>().Where(f => delIds.Contains(f.id));
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
            return database.QueryAsync<DeliveryFormModel>("SELECT OT.otid, OT.otdestinnom, OT.otdestville, ot.otdestnp, MIN(periodes.periodeid) as Periode, count(OT.otid) as COUNT, SUM(OT.otetat) as SUM, CASE WHEN Cast(julianday(MIN(periodes.periodeID)) - julianday(min(OT.otdatelivdemande)) as Integer) = 0 THEN min(ot.otdatelivdemande) ELSE null end as [FROM], CASE WHEN Cast(julianday(MIN(periodes.periodeID)) - MAX(ot.tohour) as integer) = 0 THEN max(OT.tohour) ELSE NULL end as [To] from OT INNER join periodes on OT.otid = periodes.periodeOTID where OT.otid <> 1 and periodes.periodeplanid =? group by OT.otdestinnom, OT.otdestville, OT.otdestnp order by periode", pid);
        }

        /// <summary>
        /// Get Folder Service By OTID
        /// </summary>
        /// <param name="otid"></param>
        /// <returns></returns>
        public Task<List<FolderServiceResult>> GetFolderServiceByOtID(int otid)
        {
            return database.QueryAsync<FolderServiceResult>("select otdetail.produit, otdetail.hasattachment, otdetail.etat, produits.calculpoid, otdetail.detailid, otdetail.otid from otdetail inner join produits on otdetail.produit = produits.produit where (otdetail.otid in (?)) and(produits.calculpoid >= -1)", otid);
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

        public Task<List<Ot>> GetOTByID(int otid)
        {
            return database.QueryAsync<Ot>("select * from ot where otid=?", otid);
        }

        /// <summary>
        /// Save Frais
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Get Montage page result
        /// </summary>
        /// <param name="did"></param>
        /// <returns></returns>
        public Task<List<MontageResult>> getMontageResult(double did)
        {
            return database.QueryAsync<MontageResult>("select do.itemnumber, do.[description]  from otdetail_orderlines do inner join otdetail d on d.detailid = do.detailid where d.detailid = ?", did);
        }

        /// <summary>
        /// Get Livraison Scan Result
        /// </summary>
        /// <param name="did"></param>
        /// <param name="qry"></param>
        /// <returns></returns>
        public Task<List<LivraisonResult>> getLivraisonScanResult(double did,String qry)
        {
            return database.QueryAsync<LivraisonResult>("select distinct p.packagenumber, p.statut from ot_packages p inner join otdetail_packagelines dp on dp.packageid = p.id inner join otdetail d on d.detailid = dp.serviceid inner join produits pr on pr.produit = d.produit where (( pr.calculpoid = 1 and Cast(p.statut as integer) = 32) or (pr.calculpoid = -1 and Cast(p.statut as integer) = 31) and d.detailid = ?) and p.packagenumber like '%"+qry+"%' ", did);
        }

        /// <summary>
        /// Get Livraison NonScan Result
        /// </summary>
        /// <param name="did"></param>
        /// <param name="qry"></param>
        /// <returns></returns>
        public Task<List<LivraisonResult>> getLivraisonNonScanResult(double did, String qry)
        {
            return database.QueryAsync<LivraisonResult>("select distinct p.packagenumber, p.statut from ot_packages p inner join otdetail_packagelines dp on dp.packageid = p.id inner join otdetail d on d.detailid = dp.serviceid inner join produits pr on pr.produit = d.produit where (( pr.calculpoid = 1 and Cast(p.statut as integer) <> 32) or (pr.calculpoid = -1 and Cast(p.statut as integer) <> 31) and d.detailid = ?) and p.packagenumber like '%" + qry + "%' ", did);
        }

        /// <summary>
        /// Get Non Scan Load Form Result
        /// </summary>
        /// <param name="did"></param>
        /// <param name="qry"></param>
        /// <returns></returns>
        public Task<List<LoadFormResult>> getNonScanLoadFormResult(int cal, double pid, String qry)
        {
            if (cal == -1)
            {
                return database.QueryAsync<LoadFormResult>("select packagenumber, OT.otdestinnom, statut, MIN(periodes.periodeid) as Periode from ot_packages inner join OT on ot_packages.otid = OT.otid inner join periodes on ot.otid = periodes.periodeotid where ( statut in ('19','30','47','29')) and periodeplanid=? and ot_packages.id in ( select packageid from otdetail_packagelines  inner join otdetail on otdetail_packagelines.serviceid = otdetail.detailid inner join produits on otdetail.produit = produits.produit and produits.calculpoid=-1 ) and packagenumber like '%" + qry + "%' group by packagenumber, statut, ot.otdestinnom order by Periode", pid);
            }
            else
            {
                return database.QueryAsync<LoadFormResult>("select packagenumber, OT.otdestinnom, statut, MIN(periodes.periodeid) as Periode from ot_packages inner join OT on ot_packages.otid = OT.otid inner join periodes on ot.otid = periodes.periodeotid where ( statut like '19%' OR statut like '29%' ) and periodeplanid=? and ot_packages.id in ( select packageid from otdetail_packagelines  inner join otdetail on otdetail_packagelines.serviceid = otdetail.detailid inner join produits on otdetail.produit = produits.produit and produits.calculpoid=1 ) and packagenumber like '%"+qry+"%' group by packagenumber, statut, ot.otdestinnom order by Periode", pid);
            }
        }

        /// <summary>
        /// Get Scan Load Form Result
        /// </summary>
        /// <param name="did"></param>
        /// <param name="qry"></param>
        /// <returns></returns>
        public Task<List<LoadFormResult>> getScanLoadFormResult(double pid, String qry)
        {
            return database.QueryAsync<LoadFormResult>("select p.packagenumber, OT.otdestinnom, p.statut from ot_packages p inner join OT on p.otid = OT.otid where (p.statut=31 OR (p.statut = 29 and p.otid in (select periodeotid from periodes where (periodeplanid=?))) ) and p.packagenumber like '%"+qry+"%'", pid);
        }

        /*
         * select packagenumber, OT.otdestinnom, statut, MIN(periodes.periodeid) as Periode
        from ot_packages
        inner join OT on ot_packages.otid = OT.otid
        inner join periodes on ot.otid = periodes.periodeotid
        */
        public Task<List<PickerModel>> getCauses()
        {
            return database.QueryAsync<PickerModel>("select name as text from tbl_list where listid in (select id from tbl_tlist where name = 'Deviation' )");
        }
        
    }
}
