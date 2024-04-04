using AutoMapper;
using DesafioAeC.Domain.Entities;
using DesafioAeC.Domain.Interfaces;
using DesafioAeC.Domain.Interfaces.Services;
using DesafioAeC.Domain.Views;

namespace DesafioAeC.Service.Services
{
    public class AluraService : IAluraService
	{
        private IRepository<AluraEntity> _repository;
        private readonly IMapper _mapper;

        public AluraService(IRepository<AluraEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<AluraView> Get(Guid id)
        {
            var retorno = await _repository.SelectAsync(id);
            return _mapper.Map<AluraEntity, AluraView>(retorno);
        }

        public async Task<IEnumerable<AluraView>> GetAll()
        {
            var retorno = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<AluraEntity>, IEnumerable<AluraView>>(retorno);
        }

        public async Task<AluraView> Post(AluraView alura)
        {
            var retorno = await _repository.InsertAsync(_mapper.Map<AluraView, AluraEntity>(alura));
            return _mapper.Map<AluraEntity, AluraView>(retorno);
        }

        public async Task<AluraView> Put(AluraView alura)
        {
            var retorno = await _repository.InsertAsync(_mapper.Map<AluraView, AluraEntity>(alura));
            return _mapper.Map<AluraEntity, AluraView>(retorno);
        }
    }
}

