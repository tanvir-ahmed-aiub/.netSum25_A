using APICRUDEF.DTOs;
using APICRUDEF.EF;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APICRUDEF.Controllers
{
    [RoutePrefix("api/student")]
    public class StudentController : ApiController
    {


        public static Mapper GetMapper() {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Student,StudentDTO>().ReverseMap();
                cfg.CreateMap<Student,StudentDepartDTO>().ReverseMap();
                cfg.CreateMap<Department,DepartmentDTO>().ReverseMap();
                cfg.CreateMap<Department,DepartmentStudentDTO>().ReverseMap();
            });
            return new Mapper(config);
        }

        Sum25_AEntities db = new Sum25_AEntities();
        [HttpGet]
        [Route("all")]
        public HttpResponseMessage GetAll() {
            try
            {
                var data = GetMapper().Map<List<StudentDTO>>( db.Students.ToList());
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex) { 
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            
        }
        [HttpGet]
        [Route("all/dept")]
        public HttpResponseMessage GetAllwithDept()
        {
            try
            {
                var data = GetMapper().Map<List<StudentDepartDTO>>(db.Students.ToList());
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);

            }
        }

        [HttpPost]
        [Route("create")]
        public HttpResponseMessage Create(StudentDTO s) {
            try { 
                var data = GetMapper().Map<Student>(s);
                db.Students.Add(data);
                if (db.SaveChanges() > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.Created, data);
                }
                else {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Error Occured in Creation of Student");
                }
                
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);

            }
        }
    }
}
