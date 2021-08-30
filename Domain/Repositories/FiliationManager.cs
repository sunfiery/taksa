using Domain.Core.DAL;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public class FiliationManager : IDataRepository<Filiation>
    {
        readonly PostgreContext dbContext;
        public FiliationManager(PostgreContext context)
        {
            dbContext = context;
        }

        public async Task<IEnumerable<Filiation>> GetAllAsync()
        {
            return await dbContext.Filiations.ToListAsync();
        }

        public async Task<Filiation> GetAsync(int id)
        {
            return await dbContext.Filiations
                .FirstOrDefaultAsync(e => e.ID == id);
        }

        public async Task AddAsync(Filiation filiation)
        {
            await dbContext.Filiations.AddAsync(filiation);
            await dbContext.SaveChangesAsync();
        }

        public async Task ChangeAsync(Filiation dbFiliation, Filiation filiation)
        {
            //employees.Name = entity.Name;
            //employees.Email = entity.Email;
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Filiation filiation)
        {
            dbContext.Filiations.Remove(filiation);
            await dbContext.SaveChangesAsync();
        }
    }
}
