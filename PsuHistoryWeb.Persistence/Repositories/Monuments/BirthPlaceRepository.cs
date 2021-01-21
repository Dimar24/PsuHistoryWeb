using Microsoft.EntityFrameworkCore;
using PsuHistoryWeb.Domain.Entities.Monuments;
using PsuHistoryWeb.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PsuHistoryWeb.Persistence.Repositories
{
    class BirthPlaceRepository : IRepository<BirthPlace>
    {
        private ApplicationDbContext db;

        public BirthPlaceRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<List<BirthPlace>> GetAllAsync()
        {
            return await db.BirthPlaces.ToListAsync();
        }

        public async Task<BirthPlace> GetAsync(int id)
        {
            return await db.BirthPlaces.FindAsync(id);
        }

        public async Task<BirthPlace> FindAsync(BirthPlace entity)
        {
            return await db.BirthPlaces.FirstOrDefaultAsync(bp => bp.Place == entity.Place);
        }

        public async Task CreateAsync(BirthPlace entity)
        {
            await db.BirthPlaces.AddAsync(entity);
            await db.SaveChangesAsync();
        }

        public async Task UpdateAsync(BirthPlace entity)
        {
            db.BirthPlaces.Update(entity);
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            BirthPlace entity = await GetAsync(id);
            db.BirthPlaces.Remove(entity);
            await db.SaveChangesAsync();
        }
    }
}
