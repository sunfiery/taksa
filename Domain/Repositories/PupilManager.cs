using Domain.Core.DAL;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public class PupilManager : IDataRepository<Pupil>
    {
        readonly PostgreContext dbContext;
        public PupilManager(PostgreContext context)
        {
            dbContext = context;
        }

        public async Task<IEnumerable<Pupil>> GetAllAsync()
        {
            return await dbContext.Pupils.ToListAsync();
        }

        public async Task<Pupil> GetAsync(int id)
        {
            return await dbContext.Pupils
                .FirstOrDefaultAsync(e => e.ID == id);
        }

        public async Task AddAsync(Pupil employees)
        {
            await dbContext.Pupils.AddAsync(employees);
            await dbContext.SaveChangesAsync();
        }

        public async Task ChangeAsync(Pupil employees, Pupil entity)
        {
            //employees.Name = entity.Name;
            //employees.Email = entity.Email;
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Pupil employees)
        {
            dbContext.Pupils.Remove(employees);
            await dbContext.SaveChangesAsync();
        }
    }
}
