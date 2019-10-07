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
    public class CoveragesController : Controller
    {
        private LocalDataContext db = new LocalDataContext();

        // GET: Coverages
        public async Task<ActionResult> Index()
        {
            return View(await db.Coverages.ToListAsync());
        }

        // GET: Coverages/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coverage coverage = await db.Coverages.FindAsync(id);
            if (coverage == null)
            {
                return HttpNotFound();
            }
            return View(coverage);
        }

        // GET: Coverages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Coverages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdCoverage,Name,CoveragePct")] Coverage coverage)
        {
            if (ModelState.IsValid)
            {
                db.Coverages.Add(coverage);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(coverage);
        }

        // GET: Coverages/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coverage coverage = await db.Coverages.FindAsync(id);
            if (coverage == null)
            {
                return HttpNotFound();
            }
            return View(coverage);
        }

        // POST: Coverages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdCoverage,Name,CoveragePct")] Coverage coverage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coverage).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(coverage);
        }

        // GET: Coverages/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coverage coverage = await db.Coverages.FindAsync(id);
            if (coverage == null)
            {
                return HttpNotFound();
            }
            return View(coverage);
        }

        // POST: Coverages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Coverage coverage = await db.Coverages.FindAsync(id);
            db.Coverages.Remove(coverage);
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
