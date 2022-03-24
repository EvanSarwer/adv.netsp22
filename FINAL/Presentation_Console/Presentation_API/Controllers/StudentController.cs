using BLL.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Presentation_API.Controllers
{
    public class StudentController : ApiController
    {

        [Route("api/get/student/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var stu = StudentService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, stu);
        }

    }
}
