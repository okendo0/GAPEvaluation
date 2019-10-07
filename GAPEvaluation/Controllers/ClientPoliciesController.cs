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
    public class ClientPoliciesController : Controller
    {
        private LocalDataContext db = new LocalDataContext();

        // GET: ClientPolicies
        public async Task<ActionResult> Index()
        {
            var clientPolicies = db.ClientPolicies.Include(c => c.Client).Include(c => c.Policy).Include(c => c.RiskType);
            return View(await clientPolicies.ToListAsync());
        }

        // GET: ClientPolicies/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientPolicy clientPolicy = await db.ClientPolicies.FindAsync(id);
            if (clientPolicy == null)
            {
                return HttpNotFound();
            }
            return View(clientPolicy);
        }

        // GET: ClientPolicies/Create
        public ActionResult Create()
        {
            ViewBag.IdClient = new SelectList(db.Clients, "IdClient", "IdNumber");
            ViewBag.IdPolicy = new SelectList(db.Policies, "IdPolicy", "Name");
            ViewBag.IdRiskType = new SelectList(db.RiskTypes, "IdRiskType", "Name");
            return View();
        }

        // POST: ClientPolicies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdClientPolicy,IdClient,IdPolicy,IdRiskType,CoveragePct")] ClientPolicy clientPolicy)
        {
            if (ModelState.IsValid)
            {
                db.ClientPolicies.Add(clientPolicy);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IdClient = new SelectList(db.Clients, "IdClient", "IdNumber", clientPolicy.IdClient);
            ViewBag.IdPolicy = new SelectList(db.Policies, "IdPolicy", "Name", clientPolicy.IdPolicy);
            ViewBag.IdRiskType = new SelectList(db.RiskTypes, "IdRiskType", "Name", clientPolicy.IdRiskType);
            return View(clientPolicy);
        }

        // GET: ClientPolicies/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientPolicy clientPolicy = await db.ClientPolicies.FindAsync(id);
            if (clientPolicy == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdClient = new SelectList(db.Clients, "IdClient", "IdNumber", clientPolicy.IdClient);
            ViewBag.IdPolicy = new SelectList(db.Policies, "IdPolicy", "Name", clientPolicy.IdPolicy);
            ViewBag.IdRiskType = new SelectList(db.RiskTypes, "IdRiskType", "Name", clientPolicy.IdRiskType);
            return View(clientPolicy);
        }

        // POST: ClientPolicies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdClientPolicy,IdClient,IdPolicy,IdRiskType,CoveragePct")] ClientPolicy clientPolicy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clientPolicy).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdClient = new SelectList(db.Clients, "IdClient", "IdNumber", clientPolicy.IdClient);
            ViewBag.IdPolicy = new SelectList(db.Policies, "IdPolicy", "Name", clientPolicy.IdPolicy);
            ViewBag.IdRiskType = new SelectList(db.RiskTypes, "IdRiskType", "Name", clientPolicy.IdRiskType);
            return View(clientPolicy);
        }

        // GET: ClientPolicies/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientPolicy clientPolicy = await db.ClientPolicies.FindAsync(id);
            if (clientPolicy == null)
            {
                return HttpNotFound();
            }
            return View(clientPolicy);
        }

        // POST: ClientPolicies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ClientPolicy clientPolicy = await db.ClientPolicies.FindAsync(id);
            db.ClientPolicies.Remove(clientPolicy);
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
