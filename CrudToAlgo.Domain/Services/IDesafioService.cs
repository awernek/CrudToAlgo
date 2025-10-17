using CrudToAlgo.Domain.Entities;

namespace CrudToAlgo.Application.Services
{
    public interface IDesafioService
    {
        Task<IEnumerable<Desafio>> GetAllAsync();
        Task<Desafio?> GetByIdAsync(int id);
    }
}
