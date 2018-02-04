using AppNinja.Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AppNinja.WebApi.Controllers
{
    public class UsersController : ApiController
    {
        private IUsersService usersService = new UsersService();

        public async Task<IHttpActionResult> Get()
        {
            return Ok(await usersService.GetUsersAsync());
        }
        [Route("api/users/login")]
        public IHttpActionResult GetLogin()
        {
            return Ok(usersService.GetLogin());
        }
        //[Route("api/users/userlist")]
        //public IHttpActionResult GetUserList()
        public async Task<IHttpActionResult> GetUserList(int Id)
        {
            return Ok(await usersService.GetUsersListAsync(Id));
        }

        [Route("api/users/otro")]
        public async Task<IHttpActionResult> GetOtro()
        {
            return Ok(await usersService.GetOtro());
        }
    }
}
