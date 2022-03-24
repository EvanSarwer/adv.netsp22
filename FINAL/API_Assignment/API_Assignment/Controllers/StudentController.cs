using API_Assignment.Models.Database;
using API_Assignment.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace API_Assignment.Controllers
{
    [EnableCors("*","*","*")]
    public class StudentController : ApiController
    {
        [Route("api/get/Students")]
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            AssignEntities db = new AssignEntities();
            var data = db.Students.ToList();

            var students = new List<StudentEM>();

            foreach ( var s in data)
            {
                var dept = (from d in db.Departments where d.Id == s.Dept_Id select d).FirstOrDefault();
                students.Add(new StudentEM() 
                {
                    Id = s.Id,
                    Name = s.Name,
                    Dept_Name = dept.Name,
                });

            }

            return Request.CreateResponse(HttpStatusCode.OK, students);
        }
        [Route("api/get/Student/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            AssignEntities db = new AssignEntities();
            var data = (from a in db.Students where a.Id == id select a).FirstOrDefault();
            if(data != null)
            {
                var dept = (from d in db.Departments where d.Id == data.Dept_Id select d).FirstOrDefault();

                var student = new StudentEM()
                {
                    Id = data.Id,
                    Name = data.Name,
                    Dept_Name = dept.Name
                };

                return Request.CreateResponse(HttpStatusCode.OK, student);
            }
            return Request.CreateResponse(HttpStatusCode.OK, "Student Not Found");

        }
        [Route("api/create/student")]
        [HttpPost]
        public HttpResponseMessage Create(StudentEM data)
        {
            if (ModelState.IsValid)
            {
                AssignEntities db = new AssignEntities();
                var student = new Student()
                {
                    Name = data.Name,
                    Dept_Id = data.Dept_Id
                };
                db.Students.Add(student);
                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, "Student Created");
            }
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/delete/student/{id}")]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            AssignEntities db = new AssignEntities();
            var data = (from d in db.Students where d.Id == id select d).FirstOrDefault();
            if(data != null)
            {
                db.Students.Remove(data);
                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, "Student Deleted Successfully");
            }
            return Request.CreateResponse(HttpStatusCode.OK, "Student Not Found");

        }
        [Route("api/update/student")]
        [HttpPost]
        public HttpResponseMessage Update(StudentEM data)
        {
            if (ModelState.IsValid)
            {
                AssignEntities db = new AssignEntities();
                var stu = (from s in db.Students where s.Id == data.Id select s).FirstOrDefault();

                db.Entry(stu).CurrentValues.SetValues(data);
                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, "Update Student");
            }
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }






    }
}
