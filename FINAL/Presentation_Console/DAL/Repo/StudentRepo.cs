using DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class StudentRepo
    {


        public static Student Get(int id)
        {
            AssignEntities db = new AssignEntities();
            var stu = (from s in db.Students where s.Id == id select s).FirstOrDefault();
            return stu;
        }



    }
}
