using AutoMapper;
using CodeCampInitiative.Data.Entities;
using CodeCampInitiative.Data.Interfaces;
using CodeCampInitiative.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeCampInitiative.Library.Services
{
    public class CodeCampService : ICodeCampService
    {
        private readonly ICodeCampRepository _repository;
        private readonly IMapper _mapper;

        public CodeCampService(ICodeCampRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CodeCampModel>> GetCodeCamps(bool includeSessions)
        {
            return _mapper.Map<IEnumerable<CodeCampModel>>(await _repository.GetAllAsync(includeSessions));
        }

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

        private async Task<bool> CodeCampExists(string moniker)
        {
            return await _repository.GetCampByMonikerAsync(moniker) != null;
        }

        private async Task<CodeCamp> CodeCampIfExists(string moniker)
        {
            return await _repository.GetCampByMonikerAsync(moniker);
        }
    }
}
