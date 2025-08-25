using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IntroAPI.Controllers
{
    [RoutePrefix("api/course")]
    public class CourseController : ApiController
    {
        [HttpGet]
        [Route("all")]
        public HttpResponseMessage GetAllCourse() { 
            return Request.CreateResponse(HttpStatusCode.OK,"All Course");
        }
        [HttpGet]
        [Route("details/{c_id}")]
        public HttpResponseMessage GetById(int c_id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, "Course "+c_id);
        }
    }
}
