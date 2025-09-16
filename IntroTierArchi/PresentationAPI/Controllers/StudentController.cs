using BLL.DTOs;
using BLL.Services;
using PresentationAPI.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PresentationAPI.Controllers
{
    [RoutePrefix("api/student")]
    public class StudentController : ApiController
    {
        [EnableCors("*","*","*")]
        [Admin]
        [HttpGet]
        [Route("all")]

        public HttpResponseMessage Get() {
            var data = StudentService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpPost]
        [Route("create")]
        public HttpResponseMessage Create(StudentDTO s) {
            var data = StudentService.Create(s);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
