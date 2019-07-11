namespace CodeCampInitiative.Web.Controllers
{
    using Data.Interfaces;
    using Data.Models;
    using System;
    using System.Threading.Tasks;
    using System.Web.Http;

    /// <summary>
    /// Code camp controller
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    [RoutePrefix("api/codeCamps")]
    public class CodeCampsController : ApiController
    {
        /// <summary>
        /// The code camp service
        /// </summary>
        private readonly ICodeCampService _codeCampService;

        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Initializes a new instance of the <see cref="CodeCampsController"/> class.
        /// </summary>
        /// <param name="codeCampService">The code camp service.</param>
        public CodeCampsController(ICodeCampService codeCampService)
        {
            _codeCampService = codeCampService;
        }

        // GET: api/CodeCamps
        /// <summary>
        /// Gets the code camps.
        /// </summary>
        /// <param name="includeSessions">if set to <c>true</c> [include sessions].</param>
        /// <returns>
        /// list of code camps, with session and speaker details if flag is on
        /// </returns>
        public async Task<IHttpActionResult> GetCodeCamps(bool includeSessions = false)
        {
            try
            {
                var codeCampModels = await _codeCampService.GetCodeCamps(includeSessions);
                Logger.Info(Newtonsoft.Json.JsonConvert.SerializeObject(codeCampModels));
                return Ok(codeCampModels);
            }
            catch (Exception exception)
            {
                Logger.Error(exception);
                return InternalServerError(exception);
            }

        }

        // GET: api/CodeCamps/moniker
        /// <summary>
        /// Gets the code camp.
        /// </summary>
        /// <param name="moniker">The moniker.</param>
        /// <returns>code camp model by filtering moniker</returns>
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
                Logger.Error(exception);
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
                Logger.Error(exception);
                return InternalServerError(exception);
            }

            return BadRequest(ModelState);
        }

        // PUT: api/CodeCamps/moniker
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
                if (!string.Equals(moniker, codeCampModel.Moniker) &&
                    await _codeCampService.GetCodeCamp(codeCampModel.Moniker) != null)
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
                Logger.Error(exception);
                return InternalServerError(exception);
            }

            return BadRequest(ModelState);
        }



        // DELETE: api/CodeCamps/moniker
        /// <summary>
        /// Deletes the code camp.
        /// </summary>
        /// <param name="moniker">The moniker.</param>
        /// <returns>ok action result</returns>
        [Route("{moniker}")]
        public async Task<IHttpActionResult> DeleteCodeCamp(string moniker)
        {
            try
            {
                if (await _codeCampService.GetCodeCamp(moniker) == null)
                {
                    return NotFound();
                }

                await _codeCampService.DeleteCodeCamp(moniker);
                return Ok();
            }
            catch (Exception exception)
            {
                Logger.Error(exception);
                return InternalServerError(exception);
            }
        }

    }
}