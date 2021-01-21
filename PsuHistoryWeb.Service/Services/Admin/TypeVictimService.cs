using PsuHistoryWeb.Domain.Entities.Monuments;
using PsuHistoryWeb.Persistence.Interfaces;
using PsuHistoryWeb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PsuHistoryWeb.Service.Services.Admin
{
    public class TypeVictimService : IService<TypeVictim>
    {
        IUnitOfWork Database { get; set; }

        public TypeVictimService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task<TypeVictim> GetAsync(int id)
        {
            return await Database.TypeVictims.GetAsync(id);
        }

        public async Task<TypeVictim> FindAsync(TypeVictim item)
        {
            return await Database.TypeVictims.FindAsync(item);
        }

        public async Task<IEnumerable<TypeVictim>> GetAllAsync()
        {
            return await Database.TypeVictims.GetAllAsync();
        }

        public async Task<bool> CreateAsync(TypeVictim item)
        {
            TypeVictim typeVictim = await Database.TypeVictims.FindAsync(item);

            if (typeVictim != null)
                return false;

            typeVictim = new TypeVictim
            {
                Name = item.Name
            };
            await Database.TypeVictims.CreateAsync(typeVictim);

            return true;
        }

        public async Task<bool> UpdateAsync(TypeVictim item)
        {
            TypeVictim typeVictim = await Database.TypeVictims.FindAsync(item);

            if (typeVictim != null)
                return false;

            typeVictim = new TypeVictim
            {
                Id = item.Id,
                Name = item.Name
            };

            await Database.TypeVictims.UpdateAsync(typeVictim);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            TypeVictim typeVictim = await Database.TypeVictims.GetAsync(id);

            if (typeVictim == null)
                return false;

            await Database.TypeVictims.DeleteAsync(id);

            return true;
        }

        public async ValueTask DisposeAsync()
        {
            await Database.DisposeAsync();
        }

    }
}
