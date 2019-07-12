using CodeCampInitiative.Data.Entities;
using System;

namespace CodeCampInitiative.Library.Services
{
    using AutoMapper;
    using Data.Interfaces;
    using Data.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// encapsulate code camp business logic under this service class
    /// </summary>
    /// <seealso cref="CodeCampInitiative.Data.Interfaces.ICodeCampService" />
    public class SessionService : ISessionService
    {
        /// <summary>
        /// The repository
        /// </summary>
        private readonly ISessionRepository _repository;

        /// <summary>
        /// The code camp repository
        /// </summary>
        private readonly ICodeCampRepository _codeCampRepository;

        /// <summary>
        /// The speaker repository
        /// </summary>
        private readonly ISpeakerRepository _speakerRepository;

        /// <summary>
        /// The mapper maps data objects to model and vice versa 
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="CodeCampService"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="codeCampRepository"></param>
        /// <param name="speakerRepository"></param>
        /// <param name="mapper">The mapper.</param>
        public SessionService(ISessionRepository repository, ICodeCampRepository codeCampRepository, ISpeakerRepository speakerRepository, IMapper mapper)
        {
            _repository = repository;
            _codeCampRepository = codeCampRepository;
            _speakerRepository = speakerRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets the code camps.
        /// </summary>
        /// <param name="moniker"></param>
        /// <param name="includeSpeakers"></param>
        /// <returns>list of code camp models</returns>
        public async Task<IEnumerable<SessionModel>> GetSessions(string moniker, bool includeSpeakers = false)
        {
            return _mapper.Map<IEnumerable<SessionModel>>(await _repository.GetSessionsByMonikerAsync(moniker, includeSpeakers));
        }

        /// <summary>
        /// Gets the code camp.
        /// </summary>
        /// <param name="moniker">The moniker.</param>
        /// <param name="id"></param>
        /// <param name="includeSpeaker"></param>
        /// <returns>code camp model for given moniker</returns>
        /// <exception cref="ArgumentNullException">moniker</exception>
        public async Task<SessionModel> GetSessionByMoniker(string moniker, int id, bool includeSpeaker = false)
        {
            if (moniker == null)
            {
                throw new ArgumentNullException(nameof(moniker));
            }

            return _mapper.Map<SessionModel>(await _repository.GetSessionByMonikerAsync(moniker, id, includeSpeaker));
        }

        /// <summary>
        /// Adds the new session to a code camp.
        /// </summary>
        /// <param name="moniker">The moniker.</param>
        /// <param name="sessionModel">The session model.</param>
        /// <exception cref="InvalidOperationException"></exception>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">moniker</exception>
        public async Task<SessionModel> AddNewSessionToACodeCamp(string moniker, SessionModel sessionModel)
        {
            if (moniker == null)
            {
                throw new ArgumentNullException(nameof(moniker));
            }

            var camp = await _codeCampRepository.GetCampByMonikerAsync(moniker);
            if (camp == null)
            {
                throw new InvalidOperationException("Cannot find a code camp by given moniker");
            }

            var session = _mapper.Map<Session>(sessionModel);
            if (sessionModel.Speaker?.Id != null)
            {
                var speaker = await _speakerRepository.GetByIdAsync(sessionModel.Speaker.Id);
                if (speaker == null)
                {
                    throw new InvalidOperationException("Cannot find a speaker for given Identifier");
                }

                session.Speaker = speaker;
            }

            session.CodeCamp = camp;
            _repository.Insert(session);
            await _repository.SaveAsync();

            return _mapper.Map<SessionModel>(await _repository.GetSessionByMonikerAsync(moniker, session.Id, false));

        }

        ///// <summary>  Updates the code camp.</summary>
        ///// <param name="moniker">The moniker.</param>
        ///// <param name="codeCampModel">The code camp model.</param>
        ///// <returns>updated document camp model</returns>
        ///// <exception cref="ArgumentNullException">codeCampModel</exception>
        ///// <exception cref="InvalidOperationException">Cannot find a code camp by given moniker</exception>
        //public async Task<CodeCampModel> UpdateCodeCamp(string moniker, CodeCampModel codeCampModel)
        //{
        //    if (codeCampModel == null)
        //    {
        //        throw new ArgumentNullException(nameof(codeCampModel));
        //    }

        //    var camp = await this.CodeCampIfExists(moniker);
        //    if (camp == null)
        //    {
        //        throw new InvalidOperationException("Cannot find a code camp by given moniker");
        //    }

        //    _mapper.Map(codeCampModel, camp);

        //    await _repository.SaveAsync();

        //    return _mapper.Map<CodeCampModel>(camp);
        //}


        ///// <summary>
        ///// Adds the new code camp.
        ///// </summary>
        ///// <param name="codeCampModel">The code camp model.</param>
        ///// <returns>created code camp model</returns>
        ///// <exception cref="ArgumentNullException">codeCampModel</exception>
        ///// <exception cref="InvalidOperationException">Moniker should be unique</exception>
        //public async Task<CodeCampModel> AddNewCodeCamp(CodeCampModel codeCampModel)
        //{
        //    if (codeCampModel == null)
        //    {
        //        throw new ArgumentNullException(nameof(codeCampModel));
        //    }

        //    if (await this.CodeCampExists(codeCampModel.Moniker))
        //    {
        //        throw new InvalidOperationException("Moniker should be unique");
        //    }

        //    var codeCamp = _mapper.Map<CodeCamp>(codeCampModel);
        //    _repository.Insert(codeCamp);
        //    await _repository.SaveAsync();

        //    return await GetCodeCamp(codeCampModel.Moniker);
        //}

        ///// <summary>
        ///// Deletes the code camp.
        ///// </summary>
        ///// <param name="moniker">The moniker.</param>
        ///// <returns></returns>
        ///// <exception cref="ArgumentNullException">moniker</exception>
        //public async Task DeleteCodeCamp(string moniker)
        //{
        //    if (moniker == null)
        //    {
        //        throw new ArgumentNullException(nameof(moniker));
        //    }

        //    var camp = await this.CodeCampIfExists(moniker);
        //    if (camp != null)
        //    {
        //        _repository.Delete(camp.Id);
        //        await _repository.SaveAsync();
        //    }
        //}

        ///// <summary>
        ///// Codes the camp exists.
        ///// </summary>
        ///// <param name="moniker">The moniker.</param>
        ///// <returns>code camp exist or not</returns>
        //private async Task<bool> CodeCampExists(string moniker)
        //{
        //    return await _repository.GetCampByMonikerAsync(moniker) != null;
        //}

        ///// <summary>
        ///// Codes the camp if exists.
        ///// </summary>
        ///// <param name="moniker">The moniker.</param>
        ///// <returns>if code camp exist this returns the code camp</returns>
        //private async Task<CodeCamp> CodeCampIfExists(string moniker)
        //{
        //    return await _repository.GetCampByMonikerAsync(moniker);
        //}
    }
}
