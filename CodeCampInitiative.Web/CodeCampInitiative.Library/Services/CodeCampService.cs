namespace CodeCampInitiative.Library.Services
{
    using AutoMapper;
    using Data.Entities;
    using Data.Interfaces;
    using Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// encapsulate code camp business logic under this service class
    /// </summary>
    /// <seealso cref="CodeCampInitiative.Data.Interfaces.ICodeCampService" />
    public class CodeCampService : ICodeCampService
    {
        /// <summary>
        /// The repository
        /// </summary>
        private readonly ICodeCampRepository _repository;

        /// <summary>
        /// The mapper maps data objects to model and vice versa 
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="CodeCampService"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="mapper">The mapper.</param>
        public CodeCampService(ICodeCampRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets the code camps.
        /// </summary>
        /// <param name="includeSessions">if set to <c>true</c> [include sessions].</param>
        /// <returns>list of code camp models</returns>
        public async Task<IEnumerable<CodeCampModel>> GetCodeCamps(bool includeSessions)
        {
            return _mapper.Map<IEnumerable<CodeCampModel>>(await _repository.GetAllAsync(includeSessions));
        }

        /// <summary>
        /// Gets the code camp.
        /// </summary>
        /// <param name="moniker">The moniker.</param>
        /// <returns>code camp model for given moniker</returns>
        /// <exception cref="ArgumentNullException">moniker</exception>
        public async Task<CodeCampModel> GetCodeCamp(string moniker)
        {
            if (moniker == null)
            {
                throw new ArgumentNullException(nameof(moniker));
            }

            return _mapper.Map<CodeCampModel>(await _repository.GetCampByMonikerAsync(moniker));
        }

        /// <summary>  Updates the code camp.</summary>
        /// <param name="moniker">The moniker.</param>
        /// <param name="codeCampModel">The code camp model.</param>
        /// <returns>updated document camp model</returns>
        /// <exception cref="ArgumentNullException">codeCampModel</exception>
        /// <exception cref="InvalidOperationException">Cannot find a code camp by given moniker</exception>
        public async Task<CodeCampModel> UpdateCodeCamp(string moniker, CodeCampModel codeCampModel)
        {
            if (codeCampModel == null)
            {
                throw new ArgumentNullException(nameof(codeCampModel));
            }

            var camp = await this.CodeCampIfExists(moniker);
            if (camp == null)
            {
                throw new InvalidOperationException("Cannot find a code camp by given moniker");
            }

            _mapper.Map(codeCampModel, camp);

            await _repository.SaveAsync();

            return _mapper.Map<CodeCampModel>(camp);
        }


        /// <summary>
        /// Adds the new code camp.
        /// </summary>
        /// <param name="codeCampModel">The code camp model.</param>
        /// <returns>created code camp model</returns>
        /// <exception cref="ArgumentNullException">codeCampModel</exception>
        /// <exception cref="InvalidOperationException">Moniker should be unique</exception>
        public async Task<CodeCampModel> AddNewCodeCamp(CodeCampModel codeCampModel)
        {
            if (codeCampModel == null)
            {
                throw new ArgumentNullException(nameof(codeCampModel));
            }

            if (await this.CodeCampExists(codeCampModel.Moniker))
            {
                throw new InvalidOperationException("Moniker should be unique");
            }

            var codeCamp = _mapper.Map<CodeCamp>(codeCampModel);
            _repository.Insert(codeCamp);
            await _repository.SaveAsync();

            return await GetCodeCamp(codeCampModel.Moniker);
        }

        /// <summary>
        /// Deletes the code camp.
        /// </summary>
        /// <param name="moniker">The moniker.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">moniker</exception>
        public async Task DeleteCodeCamp(string moniker)
        {
            if (moniker == null)
            {
                throw new ArgumentNullException(nameof(moniker));
            }

            var camp = await this.CodeCampIfExists(moniker);
            if (camp != null)
            {
                _repository.Delete(camp.Id);
                await _repository.SaveAsync();
            }
        }

        /// <summary>
        /// Codes the camp exists.
        /// </summary>
        /// <param name="moniker">The moniker.</param>
        /// <returns>code camp exist or not</returns>
        private async Task<bool> CodeCampExists(string moniker)
        {
            return await _repository.GetCampByMonikerAsync(moniker) != null;
        }

        /// <summary>
        /// Codes the camp if exists.
        /// </summary>
        /// <param name="moniker">The moniker.</param>
        /// <returns>if code camp exist this returns the code camp</returns>
        private async Task<CodeCamp> CodeCampIfExists(string moniker)
        {
            return await _repository.GetCampByMonikerAsync(moniker);
        }
    }
}
