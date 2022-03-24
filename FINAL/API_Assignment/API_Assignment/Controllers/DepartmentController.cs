using API_Assignment.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using API_Assignment.Models.Entities;

namespace API_Assignment.Controllers
{
    [EnableCors("*", "*", "*")]
    public class DepartmentController : ApiController
    {
        [Route("api/get/departments")]
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            AssignEntities db = new AssignEntities();
            var dep = db.Departments.ToList();
            List<DepartmentEM> depts = new List<DepartmentEM>();
            foreach( var d in dep)
            {
                DepartmentEM dept = new DepartmentEM();
                dept.Id = d.Id;
                dept.Name = d.Name;

                depts.Add(dept);
            }


            return Request.CreateResponse(HttpStatusCode.OK, depts);
        }

        [Route("api/get/department/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            AssignEntities db = new AssignEntities();
            var de = (from d in db.Departments where d.Id == id select d).FirstOrDefault();
            var stu = (from s in db.Students where s.Dept_Id == id select s).ToList();

            DepartmentEM dept = new DepartmentEM();
            dept.Id = de.Id;
            dept.Name = de.Name;
            var studentss = new List<StudentEM>();
            foreach (var s in stu)
            {
                if (s != null)
                {
                    var student = new StudentEM()
                    {
                        Id = s.Id,
                        Name = s.Name
                    };
                    
                    studentss.Add(student);
                }
                    
            }
            dept.Students = studentss;

            return Request.CreateResponse(HttpStatusCode.OK, dept);
            
            //return Request.CreateResponse(HttpStatusCode.OK, dept);

        }
        [Route("api/create/department")]
        [HttpPost]
        public HttpResponseMessage create(DepartmentEM dept)
        {
            if (ModelState.IsValid)
            {
                AssignEntities db = new AssignEntities();
                var d = new Department()
                {
                    Name = dept.Name
                };
                db.Departments.Add(d);
                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, "Department Created");
            }

            return Request.CreateResponse(HttpStatusCode.OK, dept);

        }
        [Route("api/update/department/{id}")]
        [HttpGet]
        public HttpResponseMessage UpdateInfo(int id)
        {
            AssignEntities db = new AssignEntities();
            var de = (from d in db.Departments where d.Id == id select d).FirstOrDefault();

            DepartmentEM dept = new DepartmentEM();
            dept.Id = de.Id;
            dept.Name = de.Name;

            return Request.CreateResponse(HttpStatusCode.OK, dept);

        }
        [Route("api/update/department")]
        [HttpPost]
        public HttpResponseMessage Update(DepartmentEM dept)
        {
            if (ModelState.IsValid)
            {
                AssignEntities db = new AssignEntities();
                var data = (from a in db.Departments where a.Id == dept.Id select a).FirstOrDefault();
               
                db.Entry(data).CurrentValues.SetValues(dept);
                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, "Update Department");
            }

            return Request.CreateResponse(HttpStatusCode.OK, dept);

        }
        [Route("api/delete/department/{id}")]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            AssignEntities db = new AssignEntities();
            var data = (from a in db.Departments where a.Id == id select a).FirstOrDefault();

            if(data != null)
            {
                db.Departments.Remove(data);
                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, "Delete Department");
            }
            return Request.CreateResponse(HttpStatusCode.OK, "Can not Delete Department");

        }

    }
}
