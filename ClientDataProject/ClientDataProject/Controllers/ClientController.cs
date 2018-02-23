using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClientDataProject.Models;

namespace ClientDataProject.Controllers
{
    public class ClientController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Client/
        public ActionResult Index()
        {
            return View(db.ClientDBs.ToList().FindAll(x=>x.cancelled==true));
        }
        
         public ActionResult ViewAllClients()
        {
            return View(db.ClientDBs.ToList());
        }
        // GET: /Client/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientDB clientdb = db.ClientDBs.Find(id);
            if (clientdb == null)
            {
                return HttpNotFound();
            }
            return View(clientdb);
        }

        // GET: /Client/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Client/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ClientID,Name,Surname,Gender,Email,contact,DateTimeStamp,cancelled")] ClientDB clientdb)
        {
            if (ModelState.IsValid)
            {
                db.ClientDBs.Add(clientdb);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clientdb);
        }

        // GET: /Client/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientDB clientdb = db.ClientDBs.Find(id);
            if (clientdb == null)
            {
                return HttpNotFound();
            }
            return View(clientdb);
        }

        // POST: /Client/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ClientID,Name,Surname,Gender,Email,contact,DateTimeStamp,cancelled")] ClientDB clientdb)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clientdb).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clientdb);
        }
          

        // GET: /Client/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            ClientDB clientdb = db.ClientDBs.Single(x=>x.ClientID==id);
            if (clientdb == null)
            {
                return HttpNotFound();
            }
            return View(clientdb);
        }

        // POST: /Client/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClientDB clientdb = db.ClientDBs.Single(x => x.ClientID == id);
            clientdb.cancelled = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
