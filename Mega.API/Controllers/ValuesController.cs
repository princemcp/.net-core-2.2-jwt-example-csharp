using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Mega.API.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mega.API.Controllers
{
    [AppPermission]
    //[Authorize(Policy = "ViewDashboard")]
    [Route("api/[controller]")]
    public class ValuesController : BaseController
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {

            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                IEnumerable<Claim> claim = identity.Claims;

                var Role = claim.Where(x => x.Type == "Role").FirstOrDefault().Value;
                var Jti = claim.Where(x => x.Type == JwtRegisteredClaimNames.Jti).FirstOrDefault().Value;
                var Username = claim.Where(x => x.Type == "Username").FirstOrDefault().Value;

                string Sub = identity.Claims.Where(c => c.Type == "Username")
                             .Select(c => c.Value).SingleOrDefault();
            
                return new string[] { Role, Jti, Username };
            }
            catch (Exception ex)
            {
                return new string[] { ex.Message };
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
