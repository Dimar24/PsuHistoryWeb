using Microsoft.EntityFrameworkCore;
using PsuHistoryWeb.Domain.Entities.Monuments;
using PsuHistoryWeb.Persistence.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PsuHistoryWeb.Persistence.Repositories
{
    class BurialRepository : IRepository<Burial>
    {
        private ApplicationDbContext db;

        public BurialRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<List<Burial>> GetAllAsync()
        {
            return await db.Burials.Include(b => b.TypeBurial).ToListAsync();
        }

        public async Task<Burial> GetAsync(int id)
        {
            return await db.Burials.Include(b => b.TypeBurial).FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<Burial> FindAsync(Burial entity)
        {
            return await db.Burials.FirstOrDefaultAsync(b =>
                b.NumberBurial == entity.NumberBurial &&
                b.Location == entity.Location &&
                b.NumberPeople == entity.NumberPeople &&
                b.UnknownNumber == entity.UnknownNumber &&
                b.Year == entity.Year &&
                b.Latitude == entity.Latitude &&
                b.Longitude == entity.Longitude &&
                b.Description == entity.Description &&
                b.TypeBurialId == entity.TypeBurialId
            );
        }

        public async Task CreateAsync(Burial entity)
        {
            await db.Burials.AddAsync(entity);
            await db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Burial entity)
        {
            db.Burials.Update(entity);
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
            {
            Burial entity = await GetAsync(id);
            db.Burials.Remove(entity);
            await db.SaveChangesAsync();
        }
    }
}
