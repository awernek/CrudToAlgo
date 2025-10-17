using CrudToAlgo.Domain.Entities;

namespace CrudToAlgo.Domain.Repositories
{
    public interface IDesafioRepository
    {
        Task<IEnumerable<Desafio>> GetAllAsync();
        Task<Desafio?> GetByIdAsync(int id);
    }
}
