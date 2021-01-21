using Microsoft.EntityFrameworkCore;
using PsuHistoryWeb.Domain.Entities.Monuments;
using PsuHistoryWeb.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PsuHistoryWeb.Persistence.Repositories
{
    class DutyStationRepository : IRepository<DutyStation>
    {
        private ApplicationDbContext db;

        public DutyStationRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<List<DutyStation>> GetAllAsync()
        {
            return await db.DutyStations.ToListAsync();
        }

        public async Task<DutyStation> GetAsync(int id)
        {
            return await db.DutyStations.FindAsync(id);
        }

        public async Task<DutyStation> FindAsync(DutyStation entity)
        {
            return await db.DutyStations.FirstOrDefaultAsync(ds => ds.Place == entity.Place);
        }

        public async Task CreateAsync(DutyStation entity)
        {
            await db.DutyStations.AddAsync(entity);
            await db.SaveChangesAsync();
        }

        public async Task UpdateAsync(DutyStation entity)
        {
            db.DutyStations.Update(entity);
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            DutyStation entity = await GetAsync(id);
            db.DutyStations.Remove(entity);
            await db.SaveChangesAsync();
        }
    }
}
