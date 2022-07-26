using API.dbo_api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class AccountController : ApiController
    {
        [Route("Account/Index")]

        public List<Emp_tbl> Getname()
        {
            dummyEntities db = new dummyEntities();
            var res = db.Emp_tbl.ToList();
            return res;
        }
        [HttpPost]
        [Route("Account/Create")]
        public HttpResponseMessage Create(Emp_tbl b)
        {
            HttpResponseMessage ap = new HttpResponseMessage();
            dummyEntities db = new dummyEntities();
            db.Emp_tbl.Add(b);
            db.SaveChanges();
            return ap;
        }
        [HttpGet]
        [Route("Account/GetEdit")]
        public Emp_tbl Edit(int id)
        {
            dummyEntities db = new dummyEntities();
            var res = db.Emp_tbl.Where(a => a.Emp_Id == id).FirstOrDefault();
            return res;
        }
        [HttpPut]
        [Route("Account/PostEdit")]
        public HttpResponseMessage Edit(Emp_tbl d)
        {
            HttpResponseMessage ap = new HttpResponseMessage();
            dummyEntities db = new dummyEntities();
            db.Entry(d).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return ap;
        }
        [HttpGet]
        [Route("Account/Delete")]
        public HttpResponseMessage Delete(int id)
        {
            HttpResponseMessage ap = new HttpResponseMessage();
            dummyEntities db = new dummyEntities();
            var Dt = db.Emp_tbl.Where(x => x.Emp_Id == id).FirstOrDefault();
            db.Emp_tbl.Remove(Dt);
            db.SaveChanges();
            return ap;
        }
    }
}
