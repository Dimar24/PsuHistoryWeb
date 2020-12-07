using PsuHistoryWeb.Domain.Entities.Monuments;
using PsuHistoryWeb.Persistence.Interfaces;
using PsuHistoryWeb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PsuHistoryWeb.Service.Services.Admin
{
    public class DutyStationService : IService<DutyStation>
    {
        IUnitOfWork Database { get; set; }

        public DutyStationService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task<DutyStation> GetAsync(int id)
        {
            return await Database.DutyStations.GetAsync(id);
        }

        public async Task<IEnumerable<DutyStation>> GetAllAsync()
        {
            return await Database.DutyStations.GetAllAsync();
        }

        public async Task<bool> CreateAsync(DutyStation item)
        {
            DutyStation dutyStation = await Database.DutyStations.FindAsync(item);

            if (dutyStation != null)
                return false;

            dutyStation = new DutyStation
            {
                Place = item.Place
            };
            await Database.DutyStations.CreateAsync(dutyStation);

            return true;
        }

        public async Task<bool> UpdateAsync(DutyStation item)
        {
            DutyStation dutyStation = await Database.DutyStations.FindAsync(item);

            if (dutyStation != null)
                return false;

            dutyStation = new DutyStation
            {
                Id = item.Id,
                Place = item.Place
            };

            await Database.DutyStations.UpdateAsync(dutyStation);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            DutyStation dutyStation = await Database.DutyStations.GetAsync(id);

            if (dutyStation == null)
                return false;

            await Database.DutyStations.DeleteAsync(id);

            return true;
        }

        public async ValueTask DisposeAsync()
        {
            await Database.DisposeAsync();
        }

    }
}
