using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CodeCampInitiative.Data.Data;
using CodeCampInitiative.Data.Entities;

namespace CodeCampInitiative.Web.Controllers
{
    public class CodeCampsController : ApiController
    {
        private CodeCampDbContext db = new CodeCampDbContext();

        // GET: api/CodeCamps
        public IQueryable<CodeCamp> GetCodeCamps()
        {
            return db.CodeCamps;
        }

        // GET: api/CodeCamps/5
        [ResponseType(typeof(CodeCamp))]
        public IHttpActionResult GetCodeCamp(int id)
        {
            CodeCamp codeCamp = db.CodeCamps.Find(id);
            if (codeCamp == null)
            {
                return NotFound();
            }

            return Ok(codeCamp);
        }

        // PUT: api/CodeCamps/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCodeCamp(int id, CodeCamp codeCamp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != codeCamp.Id)
            {
                return BadRequest();
            }

            db.Entry(codeCamp).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CodeCampExists(id))
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

        // POST: api/CodeCamps
        [ResponseType(typeof(CodeCamp))]
        public IHttpActionResult PostCodeCamp(CodeCamp codeCamp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CodeCamps.Add(codeCamp);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = codeCamp.Id }, codeCamp);
        }

        // DELETE: api/CodeCamps/5
        [ResponseType(typeof(CodeCamp))]
        public IHttpActionResult DeleteCodeCamp(int id)
        {
            CodeCamp codeCamp = db.CodeCamps.Find(id);
            if (codeCamp == null)
            {
                return NotFound();
            }

            db.CodeCamps.Remove(codeCamp);
            db.SaveChanges();

            return Ok(codeCamp);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CodeCampExists(int id)
        {
            return db.CodeCamps.Count(e => e.Id == id) > 0;
        }
    }
}