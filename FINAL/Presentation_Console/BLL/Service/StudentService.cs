using BLL.Entities;
using DAL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class StudentService
    {
        public static StudentModel Get(int id)
        {
            var stu = StudentRepo.Get(id);
            var student = new StudentModel();
            //student.Id = stu.Id;
            student.Name = stu.Name;
            student.Dept_Id = stu.Dept_Id;
            return student;
        }

    }
}
