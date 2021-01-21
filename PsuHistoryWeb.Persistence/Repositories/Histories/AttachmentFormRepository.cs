using Microsoft.EntityFrameworkCore;
using PsuHistoryWeb.Domain.Entities.Histories;
using PsuHistoryWeb.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PsuHistoryWeb.Persistence.Repositories
{
    class AttachmentFormRepository : IRepository<AttachmentForm>
    {
        private ApplicationDbContext db;

        public AttachmentFormRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<List<AttachmentForm>> GetAllAsync()
        {
            return await db.AttachmentForms.ToListAsync();
        }

        public async Task<AttachmentForm> GetAsync(int id)
        {
            return await db.AttachmentForms.FindAsync(id);
        }

        public async Task<AttachmentForm> FindAsync(AttachmentForm entity)
        {
            return await db.AttachmentForms.FirstOrDefaultAsync(af => 
            af.Path == entity.Path && af.FormId == entity.FormId && af.FileType == entity.FileType);
        }

        public async Task CreateAsync(AttachmentForm entity)
        {
            await db.AttachmentForms.AddAsync(entity);
            await db.SaveChangesAsync();
        }

        public async Task UpdateAsync(AttachmentForm entity)
        {
            db.AttachmentForms.Update(entity);
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            AttachmentForm entity = await GetAsync(id);
            db.AttachmentForms.Remove(entity);
            await db.SaveChangesAsync();
        }
    }
}
