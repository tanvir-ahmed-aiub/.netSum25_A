using BLL.Services;
using PresentationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PresentationAPI.Controllers
{
    [RoutePrefix("api/auth")]
    public class AuthController : ApiController
    {
        [HttpPost]
        [Route("login")]
        public HttpResponseMessage Login(Login log) {
            var tk = AuthService.Authenticate(log.Username, log.Password);
            if (tk != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK,tk);
            }
            return Request.CreateResponse(HttpStatusCode.Unauthorized,"Username password invalid");
        }
    }
}
