using Microsoft.EntityFrameworkCore;
using PsuHistoryWeb.Domain.Entities.Monuments;
using PsuHistoryWeb.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PsuHistoryWeb.Persistence.Repositories
{
    class ConscriptionPlaceRepository : IRepository<ConscriptionPlace>
    {
        private ApplicationDbContext db;

        public ConscriptionPlaceRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<List<ConscriptionPlace>> GetAllAsync()
        {
            return await db.ConscriptionPlaces.ToListAsync();
        }

        public async Task<ConscriptionPlace> GetAsync(int id)
        {
            return await db.ConscriptionPlaces.FindAsync(id);
        }

        public async Task<ConscriptionPlace> FindAsync(ConscriptionPlace entity)
        {
            return await db.ConscriptionPlaces.FirstOrDefaultAsync(cp => cp.Place == entity.Place);
        }

        public async Task CreateAsync(ConscriptionPlace entity)
        {
            await db.ConscriptionPlaces.AddAsync(entity);
            await db.SaveChangesAsync();
        }

        public async Task UpdateAsync(ConscriptionPlace entity)
        {
            db.ConscriptionPlaces.Update(entity);
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            ConscriptionPlace entity = await GetAsync(id);
            db.ConscriptionPlaces.Remove(entity);
            await db.SaveChangesAsync();
        }
    }
}
