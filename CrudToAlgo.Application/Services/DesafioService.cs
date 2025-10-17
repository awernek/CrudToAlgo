using CrudToAlgo.Domain.Entities;
using CrudToAlgo.Domain.Repositories;

namespace CrudToAlgo.Application.Services
{
    public class DesafioService : IDesafioService
    {
        private readonly IDesafioRepository _repository;

        public DesafioService(IDesafioRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Desafio>> GetAllAsync() => _repository.GetAllAsync();
        public Task<Desafio?> GetByIdAsync(int id) => _repository.GetByIdAsync(id);
    }
}
