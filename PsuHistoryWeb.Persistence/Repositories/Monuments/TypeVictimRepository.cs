using Microsoft.EntityFrameworkCore;
using PsuHistoryWeb.Domain.Entities.Monuments;
using PsuHistoryWeb.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PsuHistoryWeb.Persistence.Repositories
{
    class TypeVictimRepository : IRepository<TypeVictim>
    {
        private ApplicationDbContext db;

        public TypeVictimRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<List<TypeVictim>> GetAllAsync()
        {
            return await db.TypeVictims.ToListAsync();
        }

        public async Task<TypeVictim> GetAsync(int id)
        {
            return await db.TypeVictims.FindAsync(id);
        }

        public async Task<TypeVictim> FindAsync(TypeVictim entity)
        {
            return await db.TypeVictims.FirstOrDefaultAsync(tv => tv.Name == entity.Name);
        }

        public async Task CreateAsync(TypeVictim entity)
        {
            await db.TypeVictims.AddAsync(entity);
            await db.SaveChangesAsync();
        }

        public async Task UpdateAsync(TypeVictim entity)
        {
            db.TypeVictims.Update(entity);
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            TypeVictim entity = await GetAsync(id);
            db.TypeVictims.Remove(entity);
            await db.SaveChangesAsync();
        }
    }
}
