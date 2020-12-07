using Microsoft.EntityFrameworkCore;
using PsuHistoryWeb.Domain.Entities.Monuments;
using PsuHistoryWeb.Persistence.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PsuHistoryWeb.Persistence.Repositories
{
    class TypeBurialRepository : IRepository<TypeBurial>
    {
        private ApplicationDbContext db;

        public TypeBurialRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<List<TypeBurial>> GetAllAsync()
        {
            return await db.TypeBurials.ToListAsync();
        }

        public async Task<TypeBurial> GetAsync(int id)
        {
            return await db.TypeBurials.FindAsync(id);
        }

        public async Task<TypeBurial> FindAsync(TypeBurial entity)
        {
            return await db.TypeBurials.FirstOrDefaultAsync(tb => tb.Name == entity.Name);
        }

        public async Task CreateAsync(TypeBurial entity)
        {
            await db.TypeBurials.AddAsync(entity);
            await db.SaveChangesAsync();
        }

        public async Task UpdateAsync(TypeBurial entity)
        {
            db.TypeBurials.Update(entity);
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            TypeBurial entity = await GetAsync(id);
            db.TypeBurials.Remove(entity);
            await db.SaveChangesAsync();
        }
    }
}
