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
        }

        public void sampleData()
        {
            User user = new User(1,"Alex","1144",124);
            database.InsertOrReplaceAsync(user);

            Plans p = new Plans(1,"neuchatel getaz",138,124,new DateTime(2017,11,14),2315.89306640625,12.054499626,"MANU","TAXI MEUBLES");
            Plans p1 = new Plans(2,"Lausanne 10h", 138, 124, new DateTime(2017,11,12), 2315.89306640625, 12.054499626, "MANU", "TAXI MEUBLES");
            database.InsertOrReplaceAsync(p);
            database.InsertOrReplaceAsync(p1);

        }

        #region User

        public Task<List<User>> GetUsersAsync()
        {
            return database.Table<User>().ToListAsync();
        }

        public Task<List<User>> GetUser(String username, String password)
        {
            return database.QueryAsync<User>("SELECT * FROM [User] WHERE [Login] = ? and [Pwd] = ?", username, password);
        }

        public Task<User> GetUserAsync(int id)
        {
            return database.Table<User>().Where(i => i.UserID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveUserAsync(User user)
        {
            if (user.UserID != 0)
            {
                return database.UpdateAsync(user);
            }
            else
            {
                return database.InsertAsync(user);
            }
        }

        public Task<int> DeleteUserAsync(User user)
        {
            return database.DeleteAsync(user);
        }
        #endregion


        #region Plan

        public Task<List<Plans>> GetMyPlans(int ResId)
        {
            //HeightRequest
            return database.QueryAsync<Plans>("SELECT * FROM [Plans] where [PlanChauffeurID] = ?", ResId);
        }
        #endregion
    }
}
