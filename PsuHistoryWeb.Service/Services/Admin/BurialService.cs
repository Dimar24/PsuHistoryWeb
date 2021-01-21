using PsuHistoryWeb.Domain.Entities.Monuments;
using PsuHistoryWeb.Persistence.Interfaces;
using PsuHistoryWeb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PsuHistoryWeb.Service.Services.Admin
{
    public class BurialService : IService<Burial>
    {
        IUnitOfWork Database { get; set; }

        public BurialService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task<Burial> GetAsync(int id)
        {
            return await Database.Burials.GetAsync(id);
        }

        public async Task<Burial> FindAsync(Burial item)
        {
            return await Database.Burials.FindAsync(item);
        }

        public async Task<IEnumerable<Burial>> GetAllAsync()
        {
            return await Database.Burials.GetAllAsync();
        }

        public async Task<bool> CreateAsync(Burial item)
        {
            Burial burial = await Database.Burials.FindAsync(item);

            if (burial != null)
                return false;

            burial = new Burial
            {
                NumberBurial = item.NumberBurial,
                Location = item.Location,
                NumberPeople = item.NumberPeople,
                UnknownNumber = item.UnknownNumber,
                Year = item.Year,
                Latitude = item.Latitude,
                Longitude = item.Longitude,
                Description = item.Description,
                TypeBurialId = item.TypeBurialId
            };

            await Database.Burials.CreateAsync(burial);

            return true;
        }

        public async Task<bool> UpdateAsync(Burial item)
        {
            Burial burial = await Database.Burials.FindAsync(item);

            if (burial != null)
                return false;

            burial = new Burial
            {
                Id = item.Id,
                NumberBurial = item.NumberBurial,
                Location = item.Location,
                NumberPeople = item.NumberPeople,
                UnknownNumber = item.UnknownNumber,
                Year = item.Year,
                Latitude = item.Latitude,
                Longitude = item.Longitude,
                Description = item.Description,
                TypeBurialId = item.TypeBurialId
            };

            await Database.Burials.UpdateAsync(burial);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            Burial burial = await Database.Burials.GetAsync(id);

            if (burial == null)
                return false;

            await Database.Burials.DeleteAsync(id);

            return true;
        }

        public async ValueTask DisposeAsync()
        {
            await Database.DisposeAsync();
        }
    }
}
