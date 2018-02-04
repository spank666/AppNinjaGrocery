using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//Importo la base de datos (Entity Framework)
using AppNinja.Data;
//Task asyncronos
using System.Threading.Tasks;
//List Async y Entity Framework
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data;
using System.Data.SqlClient;

namespace AppNinja.Service.Service
{
    public class UsersService : IUsersService
    {
        private GROCERY_DB_Entities db = new GROCERY_DB_Entities();

        public async Task<List<USERS>> GetUsersAsync()
        {
            return await db.USERS.ToListAsync();
        }

        public int GetLogin()
        {
            ObjectParameter UserId = new ObjectParameter("UserId", typeof(int));
            ObjectParameter User = new ObjectParameter("User", typeof(string));
            ObjectParameter HasError = new ObjectParameter("User", typeof(bool));
            db.SP_USERS_LOGIN("spank1", "spank666", UserId, User);
            return Convert.ToInt32(UserId.Value);
        }

        public async Task<List<SP_USERS_QUERY_Result>> GetUsersListAsync(int Id)
        {
            //return db.SP_USERS_QUERY(1).ToList().Single();
            //return db.SP_USERS_QUERY(1).ToList();
            /*System.Data.SqlClient.SqlParameter[] p = new System.Data.SqlClient.SqlParameter[1];
            p[0] = new System.Data.SqlClient.SqlParameter("InsertedById", 1);
            p[0].DbType = DbType.Int32;*/
            SqlParameter p = new SqlParameter("@InsertedById", SqlDbType.Int);
            p.Value = Id;

            return await db.Database.SqlQuery<SP_USERS_QUERY_Result>("SP_USERS_QUERY @InsertedById", p).ToListAsync();
        }
    }
}