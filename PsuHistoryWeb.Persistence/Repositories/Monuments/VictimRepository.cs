using Microsoft.EntityFrameworkCore;
using PsuHistoryWeb.Domain.Entities.Monuments;
using PsuHistoryWeb.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PsuHistoryWeb.Persistence.Repositories
{
    class VictimRepository : IRepository<Victim>
    {
        private ApplicationDbContext db;

        public VictimRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<List<Victim>> GetAllAsync()
        {
            return await db.Victims
                .Include(v => v.TypeVictim)
                .Include(v => v.DutyStation)
                .Include(v => v.BirthPlace)
                .Include(v => v.ConscriptionPlace)
                .Include(v => v.Burial)
                .ThenInclude(b => b.TypeBurial)
                .ToListAsync();
        }

        public async Task<Victim> GetAsync(int id)
        {
            return await db.Victims
                .Include(v => v.TypeVictim)
                .Include(v => v.DutyStation)
                .Include(v => v.BirthPlace)
                .Include(v => v.ConscriptionPlace)
                .Include(v => v.Burial)
                .ThenInclude(b => b.TypeBurial)
                .FirstAsync(v => v.Id == id);
        }

        public async Task<Victim> FindAsync(Victim entity)
        {
            return await db.Victims.FirstOrDefaultAsync(v =>
                v.FirstName == entity.FirstName &&
                v.LastName == entity.LastName &&
                v.MiddleName == entity.MiddleName &&
                v.IsHeroSoviet == entity.IsHeroSoviet &&
                v.IsPartisan == entity.IsPartisan &&
                v.DateOfBirth == entity.DateOfBirth &&
                v.DateOfDeath == entity.DateOfDeath &&
                v.TypeVictimId == entity.TypeVictimId &&
                v.DutyStationId == entity.DutyStationId &&
                v.BirthPlaceId == entity.BirthPlaceId &&
                v.ConscriptionPlaceId == entity.ConscriptionPlaceId &&
                v.BurialId == entity.BurialId
            );
        }

        public async Task CreateAsync(Victim entity)
        {
            await db.Victims.AddAsync(entity);
            await db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Victim entity)
        {
            db.Victims.Update(entity);
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Victim entity = await GetAsync(id);
            db.Victims.Remove(entity);
            await db.SaveChangesAsync();
        }
    }
}
