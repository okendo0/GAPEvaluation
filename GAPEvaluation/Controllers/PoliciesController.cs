using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GAPEvaluation.Domain.Models;
using GAPEvaluation.Models;

namespace GAPEvaluation.Controllers
{
    public class PoliciesController : Controller
    {
        private LocalDataContext db = new LocalDataContext();

        // GET: Policies
        public async Task<ActionResult> Index()
        {
            var policies = db.Policies.Include(p => p.Coverage);
            return View(await policies.ToListAsync());
        }

        // GET: Policies/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Policy policy = await db.Policies.FindAsync(id);
            if (policy == null)
            {
                return HttpNotFound();
            }
            return View(policy);
        }

        // GET: Policies/Create
        public ActionResult Create()
        {
            ViewBag.IdCoverage = new SelectList(db.Coverages, "IdCoverage", "Name");
            return View();
        }

        // POST: Policies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdPolicy,Name,Description,IdCoverage")] Policy policy)
        {
            if (ModelState.IsValid)
            {
                db.Policies.Add(policy);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IdCoverage = new SelectList(db.Coverages, "IdCoverage", "Name", policy.IdCoverage);
            return View(policy);
        }

        // GET: Policies/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Policy policy = await db.Policies.FindAsync(id);
            if (policy == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCoverage = new SelectList(db.Coverages, "IdCoverage", "Name", policy.IdCoverage);
            return View(policy);
        }

        // POST: Policies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdPolicy,Name,Description,IdCoverage")] Policy policy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(policy).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdCoverage = new SelectList(db.Coverages, "IdCoverage", "Name", policy.IdCoverage);
            return View(policy);
        }

        // GET: Policies/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Policy policy = await db.Policies.FindAsync(id);
            if (policy == null)
            {
                return HttpNotFound();
            }
            return View(policy);
        }

        // POST: Policies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Policy policy = await db.Policies.FindAsync(id);
            db.Policies.Remove(policy);
            await db.SaveChangesAsync();
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
