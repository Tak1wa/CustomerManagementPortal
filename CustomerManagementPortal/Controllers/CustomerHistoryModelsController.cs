using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CustomerManagementPortal.Models;
using CustomerManagementPortal.Services;

namespace CustomerManagementPortal.Controllers
{
    [Authorize]
    public class CustomerHistoryModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CustomerHistoryModels
        public ActionResult Index(int id)
        {
            var service = new CustomerServices();
            var customerWithHistory = service.GetCustomerWithHistory(id);
            return View(customerWithHistory);
        }

        // GET: CustomerHistoryModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerHistoryModel customerHistoryModel = db.CustomerHistoryModels.Find(id);
            if (customerHistoryModel == null)
            {
                return HttpNotFound();
            }
            return View(customerHistoryModel);
        }

        // GET: CustomerHistoryModels/Create
        public ActionResult Create(int id)
        {
            return View(new CustomerHistoryModel { CustomerId = id, VisitDate = DateTime.Now });
        }

        // POST: CustomerHistoryModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerHistoryModelId,VisitDate,Content,Comment,CustomerId")] CustomerHistoryModel customerHistoryModel)
        {
            if (ModelState.IsValid)
            {
                db.CustomerHistoryModels.Add(customerHistoryModel);
                db.SaveChanges();
                return RedirectToAction("Index", new { id = customerHistoryModel.CustomerId });
            }

            return View(customerHistoryModel);
        }

        // GET: CustomerHistoryModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerHistoryModel customerHistoryModel = db.CustomerHistoryModels.Find(id);
            if (customerHistoryModel == null)
            {
                return HttpNotFound();
            }
            return View(customerHistoryModel);
        }

        // POST: CustomerHistoryModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerHistoryModelId,VisitDate,Content,Comment,CustomerId")] CustomerHistoryModel customerHistoryModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerHistoryModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { id = customerHistoryModel.CustomerId });
            }
            return View(customerHistoryModel);
        }

        // GET: CustomerHistoryModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerHistoryModel customerHistoryModel = db.CustomerHistoryModels.Find(id);
            if (customerHistoryModel == null)
            {
                return HttpNotFound();
            }
            return View(customerHistoryModel);
        }

        // POST: CustomerHistoryModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomerHistoryModel customerHistoryModel = db.CustomerHistoryModels.Find(id);
            db.CustomerHistoryModels.Remove(customerHistoryModel);
            db.SaveChanges();
            return RedirectToAction("Index", new { id = customerHistoryModel.CustomerId });
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
