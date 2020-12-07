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

        public Task CreateAsync(AttachmentBurial entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<AttachmentBurial> FindAsync(AttachmentBurial entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<AttachmentBurial>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<AttachmentBurial> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(AttachmentBurial entity)
        {
            throw new NotImplementedException();
        }
    }
}
