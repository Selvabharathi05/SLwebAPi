using SLwebAPi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using HelperLibrary;
using RouteAttribute = System.Web.Http.RouteAttribute;
using DAL;

namespace SLwebAPi.Controllers
{
    public class StudentController : ApiController
    {
        schoolsmethod s = null;
        public StudentController()
        {
            s = new schoolsmethod();

        }
        List<studentmodel> s2 = new List<studentmodel>();
        [Route("Getallstudents")]
        public IEnumerable<studentmodel> Get()
        {
            List<Student> m = s.getstudents();
            foreach (var item in m)
            {
                studentmodel s1 = new studentmodel();
                s1.Roll_no = item.Roll_no;
                s1.StudentName = item.StudentName;
                s1.Age = Convert.ToInt32(item.Age);
                s1.Class = (int)item.Class;
                s2.Add(s1);
            }
            return s2;

        }

        // GET: api/student/5
        [Route("Findstudent/{id}")]
        public studentmodel Get(int id)
        {
            studentmodel m = new studentmodel();
            Student t = s.findstudent(id);
            m.Roll_no = t.Roll_no;
            m.StudentName = t.StudentName;
            m.Age = (int)t.Age;
            m.Class = (int)t.Class;
            return m;
        }

        // POST: api/student
        [Route("Addstudent")]
        public HttpResponseMessage Post([FromBody] studentmodel value)
        {
            Student s1 = new Student();
            s1.Roll_no = value.Roll_no;
            s1.StudentName = value.StudentName;
            s1.Age = Convert.ToInt32(value.Age);
            s1.Class = (int)value.Class;
            bool k = s.addstudent(s1);
            if (k)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable);

            }

        }
        [Route("Updatestudent/{id}")]
        // PUT: api/student/5
        public HttpResponseMessage Put(int id, [FromBody] studentmodel value)
        {
            Student s1 = new Student();
            s1.Roll_no = value.Roll_no;
            s1.StudentName = value.StudentName;
            s1.Age = Convert.ToInt32(value.Age);
            s1.Class = (int)value.Class;
            bool k = s.updatestudent(id, s1);
            if (k)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable);

            }
        }

        // DELETE: api/student/5
        [Route("deletestudent/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            bool k = s.deletestudent(id);
            if (k)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable);

            }
        }

    }
}