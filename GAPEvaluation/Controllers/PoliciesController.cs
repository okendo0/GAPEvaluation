﻿namespace GAPEvaluation.Controllers
{
    using System.Data.Entity;
    using System.Net;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using Common.Repository;
    using Domain.Models;
    using Models;

    public class PoliciesController : Controller
    {
        private LocalDataContext db = new LocalDataContext();
        PolicyRepository policyRepository = new PolicyRepository();

        // GET: Policies
        public async Task<ActionResult> Index()
        {
            return View(await db.Policies.ToListAsync());
            //return View(await policyRepository.GetPolicies());
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
            return View();
        }

        // POST: Policies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdPolicy,Name,Description")] Policy policy)
        {
            if (ModelState.IsValid)
            {
                db.Policies.Add(policy);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

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
            return View(policy);
        }

        // POST: Policies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdPolicy,Name,Description")] Policy policy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(policy).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
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
