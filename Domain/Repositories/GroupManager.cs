using Domain.Core.DAL;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public class GroupManager : IDataRepository<Group>
    {
        readonly PostgreContext dbContext;
        public GroupManager(PostgreContext context)
        {
            dbContext = context;
        }

        public async Task<IEnumerable<Group>> GetAllAsync()
        {
            return await dbContext.Groups.ToListAsync();
        }

        public async Task<Group> GetAsync(int id)
        {
            return await dbContext.Groups
                .FirstOrDefaultAsync(e => e.ID == id);
        }

        public async Task AddAsync(Group group)
        {
            await dbContext.Groups.AddAsync(group);
            await dbContext.SaveChangesAsync();
        }

        public async Task ChangeAsync(Group group, Group entity)
        {
            //employees.Name = entity.Name;
            //employees.Email = entity.Email;
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Group group)
        {
            dbContext.Groups.Remove(group);
            await dbContext.SaveChangesAsync();
        }
    }
}
