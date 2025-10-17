using CrudToAlgo.Domain.Entities;
using CrudToAlgo.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CrudToAlgo.Infrastructure.Repositories
{
    public class DesafioRepository : IDesafioRepository
    {
        private readonly AppDbContext _context;
        public DesafioRepository(AppDbContext context) => _context = context;

        public async Task<IEnumerable<Desafio>> GetAllAsync()
        {
            return await _context.Desafios
                .Include(d => d.CasosTeste.Where(c => c.Publico))
                .ToListAsync();
        }

        public async Task<Desafio?> GetByIdAsync(int id)
        {
            return await _context.Desafios
                .Include(d => d.CasosTeste.Where(c => c.Publico))
                .FirstOrDefaultAsync(d => d.Id == id);
        }
    }
}
