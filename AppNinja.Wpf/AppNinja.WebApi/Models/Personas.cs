using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace AppNinja.WebApi.Models
{
    public class Personas
    {
        public string IdPersona { get; set; }

        public async Task<List<Personas>> Listado()
        {
            List<Personas> listaPersonas = new List<Personas>();
            listaPersonas.Add(new Personas { IdPersona = "1000" });
            listaPersonas.Add(new Personas { IdPersona = "1001" });
            listaPersonas.Add(new Personas { IdPersona = "1002" });
            listaPersonas.Add(new Personas { IdPersona = "1003" });
            listaPersonas.Add(new Personas { IdPersona = "1004" });

            return listaPersonas;
        }
    }
}