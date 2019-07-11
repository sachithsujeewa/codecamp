namespace CodeCampInitiative.Web.Controllers
{
    using Data.Interfaces;
    using System;
    using System.Threading.Tasks;
    using System.Web.Http;

    /// <summary>
    /// Code camp controller
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    [RoutePrefix("api/codeCamps/{moniker}/sessions")]
    public class SessionController : ApiController
    {
        /// <summary>
        /// The code camp service
        /// </summary>
        private readonly ISessionService _sessionService;

        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Initializes a new instance of the <see cref="CodeCampsController"/> class.
        /// </summary>
        /// <param name="sessionService"></param>
        public SessionController(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }

        // GET: api/CodeCamps/{moniker}/Sessions
        /// <summary>
        /// Gets the code camps.
        /// </summary>
        /// <param name="moniker"></param>
        /// <param name="includeSpeaker">if set to <c>true</c> [include sessions].</param>
        /// <returns>
        /// list of sessions and speaker details if flag is on
        /// </returns>
        [Route()]
        public async Task<IHttpActionResult> GetSessions(string moniker, bool includeSpeaker = false)
        {
            try
            {
                var sessionModels = await _sessionService.GetSessions(moniker, includeSpeaker);
                Logger.Info(Newtonsoft.Json.JsonConvert.SerializeObject(sessionModels));
                return Ok(sessionModels);
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
        /// <param name="id"></param>
        /// <param name="includeSpeaker"></param>
        /// <returns>code camp model by filtering moniker</returns>
        [Route("{id:int}", Name = "GetSession")]
        public async Task<IHttpActionResult> GetSession(string moniker, int id, bool includeSpeaker = false)
        {
            try
            {
                var camp = await _sessionService.GetSessionByMoniker(moniker, id, includeSpeaker);
                return camp == null ? (IHttpActionResult)NotFound() : Ok(camp);
            }
            catch (Exception exception)
            {
                Logger.Error(exception);
                return InternalServerError(exception);
            }
        }

        //// POST: api/CodeCamps
        ///// <summary>
        ///// Posts the code camp.
        ///// </summary>
        ///// <param name="codeCampModel">The code camp model.</param>
        ///// <returns>created code camp model</returns>
        //public async Task<IHttpActionResult> PostCodeCamp(CodeCampModel codeCampModel)
        //{
        //    try
        //    {
        //        if (await _sessionService.GetCodeCamp(codeCampModel.Moniker) != null)
        //        {
        //            ModelState.AddModelError("Moniker", "Moniker should be unique");
        //        }

        //        if (ModelState.IsValid)
        //        {
        //            var createdModel = await _sessionService.AddNewCodeCamp(codeCampModel);
        //            return CreatedAtRoute("GetCodeCamp", new { moniker = createdModel.Moniker }, createdModel);
        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        Logger.Error(exception);
        //        return InternalServerError(exception);
        //    }

        //    return BadRequest(ModelState);
        //}

        //// PUT: api/CodeCamps/moniker
        ///// <summary>Puts the code camp.</summary>
        ///// <param name="moniker">The moniker.</param>
        ///// <param name="codeCampModel">The code camp model.</param>
        ///// <returns>updated code camp model</returns>
        //[Route("{moniker}")]
        //public async Task<IHttpActionResult> PutCodeCamp(string moniker, CodeCampModel codeCampModel)
        //{
        //    try
        //    {
        //        if (await _sessionService.GetCodeCamp(moniker) == null)
        //        {
        //            return NotFound();
        //        }

        //        // if moniker changed then new moniker unique check
        //        if (!string.Equals(moniker, codeCampModel.Moniker) &&
        //            await _sessionService.GetCodeCamp(codeCampModel.Moniker) != null)
        //        {
        //            ModelState.AddModelError("Moniker", "Moniker should be unique");
        //        }

        //        if (ModelState.IsValid)
        //        {
        //            var createdModel = await _sessionService.UpdateCodeCamp(moniker, codeCampModel);
        //            return CreatedAtRoute("GetCodeCamp", new { moniker = createdModel.Moniker }, createdModel);
        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        Logger.Error(exception);
        //        return InternalServerError(exception);
        //    }

        //    return BadRequest(ModelState);
        //}



        //// DELETE: api/CodeCamps/moniker
        ///// <summary>
        ///// Deletes the code camp.
        ///// </summary>
        ///// <param name="moniker">The moniker.</param>
        ///// <returns>ok action result</returns>
        //[Route("{moniker}")]
        //public async Task<IHttpActionResult> DeleteCodeCamp(string moniker)
        //{
        //    try
        //    {
        //        if (await _sessionService.GetCodeCamp(moniker) == null)
        //        {
        //            return NotFound();
        //        }

        //        await _sessionService.DeleteCodeCamp(moniker);
        //        return Ok();
        //    }
        //    catch (Exception exception)
        //    {
        //        Logger.Error(exception);
        //        return InternalServerError(exception);
        //    }
        //}

    }
}