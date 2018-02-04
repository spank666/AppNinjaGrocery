using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace AppNinja.WebApi.Models
{
    public class MyAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated(); // 
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            if (context.UserName == "admin" && context.Password == "admin")
            {
                var props = new AuthenticationProperties(new Dictionary<string, string>
                {
                    {
                        "error", "false"
                    }/*,
                    {
                        "age", "20"
                    },
                    {
                    "gender", "Male"
                    }*/
                });
                identity.AddClaim(new Claim(ClaimTypes.Role, "admin"));
                identity.AddClaim(new Claim("username", "admin1"));
                identity.AddClaim(new Claim(ClaimTypes.Name, "Victor Sanchez"));
                //context.Validated(identity);
                var ticket = new AuthenticationTicket(identity, props);
                context.Validated(ticket);
            }
            else if (context.UserName == "user" && context.Password == "user")
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, "user"));
                identity.AddClaim(new Claim("username", "user"));
                identity.AddClaim(new Claim(ClaimTypes.Name, "Aaron Vazquez"));
                context.Validated(identity);
            }
            else
            {
                //context.SetError("invalid_grant", "Usuario incorrecto");
                context.SetError("true");
                return;
            }
        }
        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }
    }
}