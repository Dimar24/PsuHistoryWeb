using PsuHistoryWeb.Domain.Entities.Monuments;
using PsuHistoryWeb.Persistence.Interfaces;
using PsuHistoryWeb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsuHistoryWeb.Service.Services.Admin
{
    class AttachmentBurialService : IService<AttachmentBurial>
    {
        IUnitOfWork Database { get; set; }

        public AttachmentBurialService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task<AttachmentBurial> GetAsync(int id)
        {
            return await Database.AttachmentBurials.GetAsync(id);
        }

        public async Task<AttachmentBurial> FindAsync(AttachmentBurial item)
        {
            return await Database.AttachmentBurials.FindAsync(item);
        }

        public async Task<IEnumerable<AttachmentBurial>> GetAllAsync()
        {
            return await Database.AttachmentBurials.GetAllAsync();
        }

        public async Task<bool> CreateAsync(AttachmentBurial item)
        {
            AttachmentBurial attachmentBurial = await Database.AttachmentBurials.FindAsync(item);

            if (attachmentBurial != null)
                return false;

            attachmentBurial = new AttachmentBurial
            {
                Path = item.Path,
                BurialId = item.BurialId
            };
            await Database.AttachmentBurials.CreateAsync(attachmentBurial);

            return true;
        }

        public async Task<bool> UpdateAsync(AttachmentBurial item)
        {
            AttachmentBurial attachmentBurial = await Database.AttachmentBurials.FindAsync(item);

            if (attachmentBurial != null)
                return false;

            attachmentBurial = new AttachmentBurial
            {
                Id = item.Id,
                Path = item.Path,
                BurialId = item.BurialId
            };

            await Database.AttachmentBurials.UpdateAsync(attachmentBurial);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            AttachmentBurial attachmentBurial = await Database.AttachmentBurials.GetAsync(id);

            if (attachmentBurial == null)
                return false;

            await Database.AttachmentBurials.DeleteAsync(id);

            return true;
        }

        public async ValueTask DisposeAsync()
        {
            await Database.DisposeAsync();
        }
    }
}
