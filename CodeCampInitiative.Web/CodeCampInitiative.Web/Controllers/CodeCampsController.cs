using CodeCampInitiative.Data.Interfaces;
using CodeCampInitiative.Data.Models;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace CodeCampInitiative.Web.Controllers
{
    [RoutePrefix("api/codeCamps")]
    public class CodeCampsController : ApiController
    {
        private readonly ICodeCampService _codeCampService;

        public CodeCampsController(ICodeCampService codeCampService)
        {
            _codeCampService = codeCampService;
        }

        // GET: api/CodeCamps
        public async Task<IHttpActionResult> GetCodeCamps(bool includeSessions = false)
        {
            try
            {
                return Ok(await _codeCampService.GetCodeCamps(includeSessions));
            }
            catch (Exception exception)
            {
                //TODO logging and remove the whole exception
                return InternalServerError(exception);
            }

        }

        // GET: api/CodeCamps/moniker
        [Route("{moniker}", Name = "GetCodeCamp")]
        public async Task<IHttpActionResult> GetCodeCamp(string moniker)
        {
            try
            {
                var camp = await _codeCampService.GetCodeCamp(moniker);
                return camp == null ? (IHttpActionResult)NotFound() : Ok(camp);
            }
            catch (Exception exception)
            {
                //TODO logging and remove the whole exception
                return InternalServerError(exception);
            }
        }

        // POST: api/CodeCamps
        /// <summary>
        /// Posts the code camp.
        /// </summary>
        /// <param name="codeCampModel">The code camp model.</param>
        /// <returns>created code camp model</returns>
        public async Task<IHttpActionResult> PostCodeCamp(CodeCampModel codeCampModel)
        {
            try
            {
                if (await _codeCampService.GetCodeCamp(codeCampModel.Moniker) != null)
                {
                    ModelState.AddModelError("Moniker", "Moniker should be unique");
                }

                if (ModelState.IsValid)
                {
                    var createdModel = await _codeCampService.AddNewCodeCamp(codeCampModel);
                    return CreatedAtRoute("GetCodeCamp", new { moniker = createdModel.Moniker }, createdModel);
                }
            }
            catch (Exception exception)
            {
                //TODO logging and remove the whole exception
                return InternalServerError(exception);
            }

            return BadRequest(ModelState);
        }


        /// <summary>Puts the code camp.</summary>
        /// <param name="moniker">The moniker.</param>
        /// <param name="codeCampModel">The code camp model.</param>
        /// <returns>updated code camp model</returns>
        [Route("{moniker}")]
        public async Task<IHttpActionResult> PutCodeCamp(string moniker, CodeCampModel codeCampModel)
        {
            try
            {
                if (await _codeCampService.GetCodeCamp(moniker) == null)
                {
                    return NotFound();
                }

                // if moniker changed then new moniker unique check
                if (!string.Equals(moniker, codeCampModel.Moniker) && await _codeCampService.GetCodeCamp(codeCampModel.Moniker) != null)
                {
                    ModelState.AddModelError("Moniker", "Moniker should be unique");
                }

                if (ModelState.IsValid)
                {
                    var createdModel = await _codeCampService.UpdateCodeCamp(moniker, codeCampModel);
                    return CreatedAtRoute("GetCodeCamp", new { moniker = createdModel.Moniker }, createdModel);
                }
            }
            catch (Exception exception)
            {
                //TODO logging and remove the whole exception
                return InternalServerError(exception);
            }

            return BadRequest(ModelState);

        }



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