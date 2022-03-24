using EmptyWebApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmptyWebApi.Controllers
{
    public class PersonController : ApiController
    {
        // GET: api/Person
        public HttpResponseMessage Get()     
        {

            var persons = new List<Person>();
            persons.Add(new Person() {Id=1,Name="Ashik" });
            persons.Add(new Person() {Id=2,Name="Evan" });
            persons.Add(new Person() {Id=3,Name="Fahim" });
            var data = JsonConvert.SerializeObject(persons);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        // GET: api/Person/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Person
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Person/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Person/5
        public void Delete(int id)
        {
        }
    }
}
