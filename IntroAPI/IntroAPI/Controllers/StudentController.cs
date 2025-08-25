using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IntroAPI.Controllers
{
    //api/student
    public class StudentController : ApiController
    {
        public HttpResponseMessage Get() {
            return Request.CreateResponse(HttpStatusCode.OK,"Hello from GET");
        }
        public HttpResponseMessage Get(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, "Hello from GET "+id);
        }
        public HttpResponseMessage Post()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "Hello from Post");
        }
        public HttpResponseMessage Delete()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "Hello from Delete");
        }
    }
}
