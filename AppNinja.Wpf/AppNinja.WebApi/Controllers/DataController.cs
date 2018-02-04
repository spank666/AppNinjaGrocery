using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;

using AppNinja.WebApi.Models;

namespace AppNinja.WebApi.Controllers
{
    public class DataController : ApiController
    {
        [AllowAnonymous]
        [HttpGet]
        [Route("api/data/forall")]
        public IHttpActionResult Get()
        {
            return Ok("La hora es: " + DateTime.Now.ToString());
        }

        [System.Web.Http.Authorize]
        [HttpGet]
        [Route("api/data/authenticate")]
        public IHttpActionResult GetForAuthenticate()
        {
            var identity = (ClaimsIdentity)User.Identity;
            return Ok("Bienvenid@ " + identity.Name);
        }

        [System.Web.Http.Authorize(Roles = "admin")]
        [HttpGet]
        [Route("api/data/authorize")]
        public IHttpActionResult GetForAdmin()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var roles = identity.Claims
                        .Where(c => c.Type == ClaimTypes.Role)
                        .Select(c => c.Value);
            return Ok("Hola " + identity.Name + " Rol: " + string.Join(",", roles.ToList()));
        }

        [System.Web.Http.Authorize(Roles = "admin")]
        [Route("api/remesa")]
        public IHttpActionResult GetRemesas()
        {
            List<Remesa> listaRemesas = new List<Remesa>();
            listaRemesas.Add(new Remesa { IdRemesa = "1000", Monto = 75000.00 });
            listaRemesas.Add(new Remesa { IdRemesa = "1001", Monto = 5000.00 });
            listaRemesas.Add(new Remesa { IdRemesa = "1002", Monto = 600.00 });
            listaRemesas.Add(new Remesa { IdRemesa = "1003", Monto = 2500.00 });
            return Ok(listaRemesas);
        }

        [Route("api/remesas")]
        public async Task<IHttpActionResult> GetPersonaAsync()
        {
            Personas per = new Personas();
            var result = await per.Listado();
            return Ok(result);
        }
    }
}
