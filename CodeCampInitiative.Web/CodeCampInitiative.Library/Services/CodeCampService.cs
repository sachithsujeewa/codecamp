using AutoMapper;
using CodeCampInitiative.Data.Entities;
using CodeCampInitiative.Data.Interfaces;
using CodeCampInitiative.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeCampInitiative.Library.Services
{
    public class CodeCampService
    {
        private readonly IEntityRepository<CodeCamp> _repository;
        private readonly IMapper _mapper;

        public CodeCampService(IEntityRepository<CodeCamp> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CodeCampModel>> GetCodeCamps()
        {
            return _mapper.Map<IEnumerable<CodeCampModel>>(await _repository.GetAllAsync());
        }

        public async Task<CodeCampModel> GetCodeCamp(int id)
        {
            if (id == 0)
            {
                throw new ArgumentNullException(nameof(id));
            }

            return _mapper.Map<CodeCampModel>(await _repository.GetByIdAsync(id));
        }

        public async Task<CodeCampModel> UpdateCodeCamp(int id, CodeCampModel codeCampModel)
        {
            if (id == 0 || codeCampModel == null)
            {
                throw new ArgumentNullException(nameof(codeCampModel));
            }

            if (!await this.CodeCampExists(id))
            {
                throw new InvalidOperationException();
            }

            _repository.Update(_mapper.Map<CodeCamp>(codeCampModel));
            await _repository.SaveAsync();

            return await GetCodeCamp(id);
        }


        public async Task<CodeCampModel> PostCodeCamp(CodeCampModel codeCampModel)
        {
            if (codeCampModel == null)
            {
                throw new ArgumentNullException(nameof(codeCampModel));
            }
            var codeCamp = _mapper.Map<CodeCamp>(codeCampModel);
            _repository.Insert(codeCamp);
            await _repository.SaveAsync();

            return await GetCodeCamp(codeCamp.Id);
        }

        public async Task DeleteCodeCamp(int id)
        {
            if (id == 0)
            {
                throw new ArgumentNullException(nameof(id));
            }

            if (await this.CodeCampExists(id))
            {
                _repository.Delete(id);
                await _repository.SaveAsync();
            }

        }


        private async Task<bool> CodeCampExists(int id)
        {
            return await _repository.GetByIdAsync(id) != null;
        }
    }
}
