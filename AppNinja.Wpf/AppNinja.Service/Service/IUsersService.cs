using AppNinja.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace AppNinja.Service.Service
{
    public interface IUsersService
    {
        Task<List<USERS>> GetUsersAsync();
        int GetLogin();
        //List<SP_USERS_QUERY_Result> GetUsersListAsync();
        Task<List<SP_USERS_QUERY_Result>> GetUsersListAsync(int Id);

        Task<int> GetOtro();
    }
}