using PsuHistoryWeb.Domain.Entities.Monuments;
using PsuHistoryWeb.Persistence.Interfaces;
using PsuHistoryWeb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PsuHistoryWeb.Service.Services.Admin
{
    public class ConscriptionPlaceService : IService<ConscriptionPlace>
    {
        IUnitOfWork Database { get; set; }

        public ConscriptionPlaceService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task<ConscriptionPlace> GetAsync(int id)
        {
            return await Database.ConscriptionPlaces.GetAsync(id);
        }

        public async Task<ConscriptionPlace> FindAsync(ConscriptionPlace item)
        {
            return await Database.ConscriptionPlaces.FindAsync(item);
        }

        public async Task<IEnumerable<ConscriptionPlace>> GetAllAsync()
        {
            return await Database.ConscriptionPlaces.GetAllAsync();
        }

        public async Task<bool> CreateAsync(ConscriptionPlace item)
        {
            ConscriptionPlace conscriptionPlace = await Database.ConscriptionPlaces.FindAsync(item);

            if (conscriptionPlace != null)
                return false;

            conscriptionPlace = new ConscriptionPlace
            {
                Place = item.Place
            };
            await Database.ConscriptionPlaces.CreateAsync(conscriptionPlace);

            return true;
        }

        public async Task<bool> UpdateAsync(ConscriptionPlace item)
        {
            ConscriptionPlace conscriptionPlace = await Database.ConscriptionPlaces.FindAsync(item);

            if (conscriptionPlace != null)
                return false;

            conscriptionPlace = new ConscriptionPlace
            {
                Id = item.Id,
                Place = item.Place
            };

            await Database.ConscriptionPlaces.UpdateAsync(conscriptionPlace);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            ConscriptionPlace conscriptionPlace = await Database.ConscriptionPlaces.GetAsync(id);

            if (conscriptionPlace == null)
                return false;

            await Database.ConscriptionPlaces.DeleteAsync(id);

            return true;
        }

        public async ValueTask DisposeAsync()
        {
            await Database.DisposeAsync();
        }

    }
}
