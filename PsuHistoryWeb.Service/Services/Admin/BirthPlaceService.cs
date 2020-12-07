using PsuHistoryWeb.Domain.Entities.Monuments;
using PsuHistoryWeb.Persistence.Interfaces;
using PsuHistoryWeb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PsuHistoryWeb.Service.Services.Admin
{
    public class BirthPlaceService : IService<BirthPlace>
    {
        IUnitOfWork Database { get; set; }

        public BirthPlaceService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task<BirthPlace> GetAsync(int id)
        {
            return await Database.BirthPlaces.GetAsync(id);
        }

        public async Task<IEnumerable<BirthPlace>> GetAllAsync()
        {
            return await Database.BirthPlaces.GetAllAsync();
        }

        public async Task<bool> CreateAsync(BirthPlace item)
        {
            BirthPlace birthPlace = await Database.BirthPlaces.FindAsync(item);

            if (birthPlace != null)
                return false;

            birthPlace = new BirthPlace
            {
                Place = item.Place
            };
            await Database.BirthPlaces.CreateAsync(birthPlace);

            return true;
        }

        public async Task<bool> UpdateAsync(BirthPlace item)
        {
            BirthPlace birthPlace = await Database.BirthPlaces.FindAsync(item);

            if (birthPlace != null)
                return false;

            birthPlace = new BirthPlace
            {
                Id = item.Id,
                Place = item.Place
            };

            await Database.BirthPlaces.UpdateAsync(birthPlace);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            BirthPlace typeBurial = await Database.BirthPlaces.GetAsync(id);

            if (typeBurial == null)
                return false;

            await Database.BirthPlaces.DeleteAsync(id);

            return true;
        }

        public async ValueTask DisposeAsync()
        {
            await Database.DisposeAsync();
        }

    }
}
