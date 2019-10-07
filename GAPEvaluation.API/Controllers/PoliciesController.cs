namespace GAPEvaluation.API.Controllers
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.Description;
    using GAPEvaluation.Domain.Models;

    public class PoliciesController : ApiController
    {
        private Domain.Models.DataContext db = new Domain.Models.DataContext();

        // GET: api/Policies
        public IQueryable<Policy> GetPolicies()
        {
            return db.Policies;
        }

        // GET: api/Policies/5
        [ResponseType(typeof(Policy))]
        public async Task<IHttpActionResult> GetPolicy(int id)
        {
            Policy policy = await db.Policies.FindAsync(id);
            if (policy == null)
            {
                return NotFound();
            }

            return Ok(policy);
        }

        // PUT: api/Policies/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPolicy(int id, Policy policy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != policy.IdPolicy)
            {
                return BadRequest();
            }

            db.Entry(policy).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PolicyExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Policies
        [ResponseType(typeof(Policy))]
        public async Task<IHttpActionResult> PostPolicy(Policy policy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Policies.Add(policy);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = policy.IdPolicy }, policy);
        }

        // DELETE: api/Policies/5
        [ResponseType(typeof(Policy))]
        public async Task<IHttpActionResult> DeletePolicy(int id)
        {
            Policy policy = await db.Policies.FindAsync(id);
            if (policy == null)
            {
                return NotFound();
            }

            db.Policies.Remove(policy);
            await db.SaveChangesAsync();

            return Ok(policy);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PolicyExists(int id)
        {
            return db.Policies.Count(e => e.IdPolicy == id) > 0;
        }
    }
}