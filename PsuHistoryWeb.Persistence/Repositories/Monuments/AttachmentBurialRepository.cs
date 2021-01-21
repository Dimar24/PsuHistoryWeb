using Microsoft.EntityFrameworkCore;
using PsuHistoryWeb.Domain.Entities.Monuments;
using PsuHistoryWeb.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PsuHistoryWeb.Persistence.Repositories
{
    class AttachmentBurialRepository : IRepository<AttachmentBurial>
    {
        private ApplicationDbContext db;

        public AttachmentBurialRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<List<AttachmentBurial>> GetAllAsync()
        {
            return await db.AttachmentBurials.ToListAsync();
        }

        public async Task<AttachmentBurial> GetAsync(int id)
        {
            return await db.AttachmentBurials.FindAsync(id);
        }

        public async Task<AttachmentBurial> FindAsync(AttachmentBurial entity)
        {
            return await db.AttachmentBurials.FirstOrDefaultAsync(ab => 
                ab.Path == entity.Path && 
                ab.BurialId == entity.BurialId
            );
        }

        public async Task CreateAsync(AttachmentBurial entity)
        {
            await db.AttachmentBurials.AddAsync(entity);
            await db.SaveChangesAsync();
        }

        public async Task UpdateAsync(AttachmentBurial entity)
        {
            db.AttachmentBurials.Update(entity);
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            AttachmentBurial entity = await GetAsync(id);
            db.AttachmentBurials.Remove(entity);
            await db.SaveChangesAsync();
        }
    }
}
