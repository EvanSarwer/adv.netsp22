using API_Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Script.Serialization;

namespace API_Assignment.Controllers
{
    [EnableCors("*","*","*")]
    public class PersonController : ApiController
    {
        [Route("api/get/persons")]
        [HttpGet]
        public HttpResponseMessage get()
        {
            
            List<Person> persons = new List<Person>();
            for(int i= 0; i < 10; i++)
            {
                var p = new Person()
                {
                    Id = i+1,
                    Name = "Person "+ (i+1)
                };
                persons.Add(p);
            }
            //var data = new JavaScriptSerializer().Serialize(persons);
            return Request.CreateResponse(HttpStatusCode.OK, persons);

        }
        [Route("api/get/person/{id}")]
        public Person get(int id)
        {
            List<Person> persons = new List<Person>();
            for (int i = 0; i < 10; i++)
            {
                var p = new Person()
                {
                    Id = i + 1,
                    Name = "Person " + (i + 1)
                };
                persons.Add(p);
            }

            return persons.FirstOrDefault(x => x.Id == id);

        }


    }
}
