using DesafioAeC.Domain.Views;

namespace DesafioAeC.Domain.Interfaces.Services
{
    public interface IAluraService
	{
        Task<AluraView> Get(Guid id);
        Task<IEnumerable<AluraView>> GetAll();
        Task<AluraView> Post(AluraView alura);
        Task<AluraView> Put(AluraView alura);
        Task<bool> Delete(Guid id);
    }
}

