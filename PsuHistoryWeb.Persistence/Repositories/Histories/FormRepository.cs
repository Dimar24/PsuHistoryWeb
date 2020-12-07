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

        public Task CreateAsync(Form entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Form> FindAsync(Form entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<Form>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Form> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Form entity)
        {
            throw new NotImplementedException();
        }
    }
}
