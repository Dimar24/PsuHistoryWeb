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

        public Task CreateAsync(AttachmentForm entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<AttachmentForm> FindAsync(AttachmentForm entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<AttachmentForm>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<AttachmentForm> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(AttachmentForm entity)
        {
            throw new NotImplementedException();
        }
    }
}
