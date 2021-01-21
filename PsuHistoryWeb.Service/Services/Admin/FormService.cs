using PsuHistoryWeb.Domain.Entities.Histories;
using PsuHistoryWeb.Persistence.Interfaces;
using PsuHistoryWeb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsuHistoryWeb.Service.Services.Admin
{
    class FormService : IService<Form>
    {
        IUnitOfWork Database { get; set; }

        public FormService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task<Form> GetAsync(int id)
        {
            return await Database.Forms.GetAsync(id);
        }

        public async Task<Form> FindAsync(Form item)
        {
            return await Database.Forms.FindAsync(item);
        }

        public async Task<IEnumerable<Form>> GetAllAsync()
        {
            return await Database.Forms.GetAllAsync();
        }

        public async Task<bool> CreateAsync(Form item)
        {
            Form form = await Database.Forms.FindAsync(item);

            if (form != null)
                return false;

            form = new Form
            {
                FirstName = item.FirstName,
                LastName = item.LastName,
                MiddleName = item.MiddleName
            };
            await Database.Forms.CreateAsync(form);

            return true;
        }

        public async Task<bool> UpdateAsync(Form item)
        {
            Form form = await Database.Forms.FindAsync(item);

            if (form != null)
                return false;

            form = new Form
            {
                Id = item.Id,
                FirstName = item.FirstName,
                LastName = item.LastName,
                MiddleName = item.MiddleName
            };

            await Database.Forms.UpdateAsync(form);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            Form form = await Database.Forms.GetAsync(id);

            if (form == null)
                return false;

            await Database.Forms.DeleteAsync(id);

            return true;
        }

        public async ValueTask DisposeAsync()
        {
            await Database.DisposeAsync();
        }
    }
}
