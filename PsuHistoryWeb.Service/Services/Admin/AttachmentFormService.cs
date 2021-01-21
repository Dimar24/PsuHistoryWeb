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
    class AttachmentFormService : IService<AttachmentForm>
    {
        IUnitOfWork Database { get; set; }

        public AttachmentFormService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task<AttachmentForm> GetAsync(int id)
        {
            return await Database.AttachmentForms.GetAsync(id);
        }

        public async Task<AttachmentForm> FindAsync(AttachmentForm item)
        {
            return await Database.AttachmentForms.FindAsync(item);
        }

        public async Task<IEnumerable<AttachmentForm>> GetAllAsync()
        {
            return await Database.AttachmentForms.GetAllAsync();
        }

        public async Task<bool> CreateAsync(AttachmentForm item)
        {
            AttachmentForm attachmentForm = await Database.AttachmentForms.FindAsync(item);

            if (attachmentForm != null)
                return false;

            attachmentForm = new AttachmentForm
            {
                Path = item.Path,
                FormId = item.FormId,
                FileType = item.FileType
            };
            await Database.AttachmentForms.CreateAsync(attachmentForm);

            return true;
        }

        public async Task<bool> UpdateAsync(AttachmentForm item)
        {
            AttachmentForm attachmentForm = await Database.AttachmentForms.FindAsync(item);

            if (attachmentForm != null)
                return false;

            attachmentForm = new AttachmentForm
            {
                Id = item.Id,
                Path = item.Path,
                FormId = item.FormId,
                FileType = item.FileType
            };

            await Database.AttachmentForms.UpdateAsync(attachmentForm);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            AttachmentForm attachmentForm = await Database.AttachmentForms.GetAsync(id);

            if (attachmentForm == null)
                return false;

            await Database.AttachmentForms.DeleteAsync(id);

            return true;
        }

        public async ValueTask DisposeAsync()
        {
            await Database.DisposeAsync();
        }
    }
}
