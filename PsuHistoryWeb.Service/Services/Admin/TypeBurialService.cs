
using PsuHistoryWeb.Domain.Entities.Monuments;
using PsuHistoryWeb.Persistence.Interfaces;
using PsuHistoryWeb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PsuHistoryWeb.Service.Services.Admin
{
    public class TypeBurialService : IService<TypeBurial>
    {
        IUnitOfWork Database { get; set; }

        public TypeBurialService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task<TypeBurial> GetAsync(int id)
        {
            return await Database.TypeBurials.GetAsync(id);
        }

        public async Task<IEnumerable<TypeBurial>> GetAllAsync()
        {
            return await Database.TypeBurials.GetAllAsync();
        }

        public async Task<bool> CreateAsync(TypeBurial item)
        {
            TypeBurial typeBurial = await Database.TypeBurials.FindAsync(item);

            if (typeBurial != null)
                return false;

            typeBurial = new TypeBurial
            {
                Name = item.Name
            };
            await Database.TypeBurials.CreateAsync(typeBurial);

            return true;
        }

        public async Task<bool> UpdateAsync(TypeBurial item)
        {
            TypeBurial typeBurial = await Database.TypeBurials.FindAsync(item);

            if (typeBurial != null)
                return false;

            typeBurial = new TypeBurial
            {
                Id = item.Id,
                Name = item.Name
            };

            await Database.TypeBurials.UpdateAsync(typeBurial);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            TypeBurial typeBurial = await Database.TypeBurials.GetAsync(id);

            if (typeBurial == null)
                return false;

            await Database.TypeBurials.DeleteAsync(id);

            return true;
        }

        public async ValueTask DisposeAsync()
        {
            await Database.DisposeAsync();
        }

    }
}
