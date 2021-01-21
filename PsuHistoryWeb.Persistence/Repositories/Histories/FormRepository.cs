using Microsoft.EntityFrameworkCore;
using PsuHistoryWeb.Domain.Entities.Histories;
using PsuHistoryWeb.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PsuHistoryWeb.Persistence.Repositories
{
    class FormRepository : IRepository<Form>
    {
        private ApplicationDbContext db;

        public FormRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<List<Form>> GetAllAsync()
        {
            return await db.Forms.ToListAsync();
        }

        public async Task<Form> GetAsync(int id)
        {
            return await db.Forms.FindAsync(id);
        }

        public async Task<Form> FindAsync(Form entity)
        {
            return await db.Forms.FirstOrDefaultAsync(f => 
                f.FirstName == entity.FirstName && 
                f.LastName == entity.LastName && 
                f.MiddleName == entity.MiddleName
            );
        }

        public async Task CreateAsync(Form entity)
        {
            await db.Forms.AddAsync(entity);
            await db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Form entity)
        {
            db.Forms.Update(entity);
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Form entity = await GetAsync(id);
            db.Forms.Remove(entity);
            await db.SaveChangesAsync();
        }
    }
}
