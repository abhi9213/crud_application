using crud_application.db_context;
using crud_application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace crud_application.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            mvcdatabaseEntities eobj = new mvcdatabaseEntities();
            var res = eobj.emptables.ToList();
            List<mymodelClass1> lobj = new List<mymodelClass1>();
            foreach (var item in res)
            {
                lobj.Add(new mymodelClass1
                {
                    id = item.id,
                    name = item.name,
                    email = item.email,
                    dept = item.dept,
                    sal = item.sal,
                    zip = item.zip,
                    mobile = item.mobile
                });
            }

            return View(lobj);
        }
        [HttpGet]
        public ActionResult dataadd()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }[HttpPost]
        public ActionResult dataadd(mymodelClass1 mobj)
        {
            mvcdatabaseEntities eobj = new mvcdatabaseEntities();
            emptable tobj = new emptable();
            tobj.id = mobj.id;
            tobj.name = mobj.name;
            tobj.email = mobj.email;
            tobj.sal = mobj.sal;
            tobj.dept = mobj.dept;
            tobj.zip = mobj.zip;
            tobj.mobile = mobj.mobile;

            if(mobj.id==0)
            {
                eobj.emptables.Add(tobj);
                eobj.SaveChanges();
            }
            else
            {
                eobj.Entry(tobj).State = System.Data.Entity.EntityState.Modified;
                eobj.SaveChanges();
            }          
                return RedirectToAction("Index");
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult delete(int id)
        {
            mvcdatabaseEntities eobj = new mvcdatabaseEntities();
            var deleteitem=eobj.emptables.Where(m => m.id == id).First();
            eobj.emptables.Remove(deleteitem);
            eobj.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult edit(int id)
        {
            mvcdatabaseEntities eobj = new mvcdatabaseEntities();
            var edititem = eobj.emptables.Where(m => m.id == id).First();
            mymodelClass1 mobj = new mymodelClass1();
            mobj.id = edititem.id;
            mobj.name = edititem.name;   
            mobj.mobile = edititem.mobile;
            mobj.zip = edititem.zip;
            mobj.email = edititem.email;
            mobj.sal = edititem.sal;
            mobj.zip = edititem.zip;
            return View("dataadd",mobj);
        }
    }
}