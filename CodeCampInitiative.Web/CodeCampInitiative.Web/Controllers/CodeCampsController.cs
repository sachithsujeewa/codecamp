using CodeCampInitiative.Data.Interfaces;
using CodeCampInitiative.Data.Models;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace CodeCampInitiative.Web.Controllers
{
    public class CodeCampsController : ApiController
    {
        private readonly ICodeCampService _codeCampService;

        public CodeCampsController(ICodeCampService codeCampService)
        {
            _codeCampService = codeCampService;
        }

        // GET: api/CodeCamps
        public async Task<IHttpActionResult> GetCodeCamps()
        {
            try
            {
                return Ok(await _codeCampService.GetCodeCamps());
            }
            catch (Exception exception)
            {
                //TODO logging and remove the whole exception
                return InternalServerError(exception);
            }

        }

        // GET: api/CodeCamps/moniker
        [Route("{moniker}")]
        public async Task<IHttpActionResult> GetCodeCamp(string moniker)
        {
            try
            {
                return Ok(await _codeCampService.GetCodeCamp(moniker));
            }
            catch (Exception exception)
            {
                //TODO logging and remove the whole exception
                return InternalServerError(exception);
            }
        }

        // POST: api/CodeCamps
        public async Task<IHttpActionResult> PostCodeCamp(CodeCampModel codeCampModel)
        {
            try
            {
                return Ok(await _codeCampService.AddNewCodeCamp(codeCampModel));
            }
            catch (Exception exception)
            {
                //TODO logging and remove the whole exception
                return InternalServerError(exception);
            }
        }

        // PUT: api/CodeCamps/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutCodeCamp(int id, CodeCamp codeCamp)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != codeCamp.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(codeCamp).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CodeCampExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}



        //// DELETE: api/CodeCamps/5
        //[ResponseType(typeof(CodeCamp))]
        //public IHttpActionResult DeleteCodeCamp(int id)
        //{
        //    CodeCamp codeCamp = db.CodeCamps.Find(id);
        //    if (codeCamp == null)
        //    {
        //        return NotFound();
        //    }

        //    db.CodeCamps.Remove(codeCamp);
        //    db.SaveChanges();

        //    return Ok(codeCamp);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool CodeCampExists(int id)
        //{
        //    return db.CodeCamps.Count(e => e.Id == id) > 0;
        //}
    }
}