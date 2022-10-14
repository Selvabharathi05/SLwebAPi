using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace HelperLibrary
{

    public class schoolsmethod
    {
        SchoolEntities context = null;
        public schoolsmethod()
        {
            context = new SchoolEntities();
        }
        public bool addstudent(Student p)
        {
            try
            {
                context.Students.Add(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }


        }
        public bool updatestudent(int id, Student p)
        {
            try
            {
                List<Student> k1 = context.Students.ToList();
                Student k = k1.Find(p1 => p1.Roll_no == id);
                k.Roll_no = p.Roll_no;
                k.StudentName = p.StudentName;
                k.Age = p.Age;
                k.Class = p.Class;
                context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public Student findstudent(int id)
        {
            List<Student> k1 = context.Students.ToList();
            Student k = k1.Find(p => p.Roll_no == id);
            return k;

        }
        public List<Student> getstudents()
        {
            return context.Students.ToList();
        }
        public bool deletestudent(int id)
        {
            try
            {
                List<Student> k1 = context.Students.ToList();
                Student k = k1.Find(p => p.Roll_no == id);
                context.Students.Remove(k);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }

}
