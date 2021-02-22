using JWTASAuthorization.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JWTASAuthorization.Controllers
{
    public class AuthenticationController : ApiController
    {
        private readonly ITokenManager tokenManager;
        public AuthenticationController(ITokenManager tokenManager)
        {
            this.tokenManager = tokenManager;
        }

        [HttpGet]
        public IHttpActionResult Authenticate(string user,string pw)
        {
            if (tokenManager.Authenticate(user,pw))
            {
                return Ok(tokenManager.NewToken());
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
