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
    public class RiskTypesController : Controller
    {
        private LocalDataContext db = new LocalDataContext();

        // GET: RiskTypes
        public async Task<ActionResult> Index()
        {
            return View(await db.RiskTypes.ToListAsync());
        }

        // GET: RiskTypes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RiskType riskType = await db.RiskTypes.FindAsync(id);
            if (riskType == null)
            {
                return HttpNotFound();
            }
            return View(riskType);
        }

        // GET: RiskTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RiskTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdRiskType,Name")] RiskType riskType)
        {
            if (ModelState.IsValid)
            {
                db.RiskTypes.Add(riskType);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(riskType);
        }

        // GET: RiskTypes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RiskType riskType = await db.RiskTypes.FindAsync(id);
            if (riskType == null)
            {
                return HttpNotFound();
            }
            return View(riskType);
        }

        // POST: RiskTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdRiskType,Name")] RiskType riskType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(riskType).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(riskType);
        }

        // GET: RiskTypes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RiskType riskType = await db.RiskTypes.FindAsync(id);
            if (riskType == null)
            {
                return HttpNotFound();
            }
            return View(riskType);
        }

        // POST: RiskTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            RiskType riskType = await db.RiskTypes.FindAsync(id);
            db.RiskTypes.Remove(riskType);
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
