using PsuHistoryWeb.Domain.Entities.Monuments;
using PsuHistoryWeb.Persistence.Interfaces;
using PsuHistoryWeb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PsuHistoryWeb.Service.Services.Admin
{
    public class VictimService : IService<Victim>
    {
        IUnitOfWork Database { get; set; }

        public VictimService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task<Victim> GetAsync(int id)
        {
            return await Database.Victims.GetAsync(id);
        }

        public async Task<Victim> FindAsync(Victim item)
        {
            return await Database.Victims.FindAsync(item);
        }

        public async Task<IEnumerable<Victim>> GetAllAsync()
        {
            return await Database.Victims.GetAllAsync();
        }

        public async Task<bool> CreateAsync(Victim item)
        {
            Victim victim = await Database.Victims.FindAsync(item);

            if (victim != null)
                return false;

            victim = new Victim
            {
                FirstName = item.FirstName,
                LastName = item.LastName,
                MiddleName = item.MiddleName,
                IsHeroSoviet = item.IsHeroSoviet,
                IsPartisan = item.IsPartisan,
                DateOfBirth = item.DateOfBirth,
                DateOfDeath = item.DateOfDeath,
                TypeVictimId = item.TypeVictimId,
                DutyStationId = item.DutyStationId,
                BirthPlaceId = item.BirthPlaceId,
                ConscriptionPlaceId = item.ConscriptionPlaceId,
                BurialId = item.BurialId
            };
            await Database.Victims.CreateAsync(victim);

            return true;
        }

        public async Task<bool> UpdateAsync(Victim item)
        {
            Victim victim = await Database.Victims.FindAsync(item);

            if (victim != null)
                return false;

            victim = new Victim
            {
                FirstName = item.FirstName,
                LastName = item.LastName,
                MiddleName = item.MiddleName,
                IsHeroSoviet = item.IsHeroSoviet,
                IsPartisan = item.IsPartisan,
                DateOfBirth = item.DateOfBirth,
                DateOfDeath = item.DateOfDeath,
                TypeVictimId = item.TypeVictimId,
                DutyStationId = item.DutyStationId,
                BirthPlaceId = item.BirthPlaceId,
                ConscriptionPlaceId = item.ConscriptionPlaceId,
                BurialId = item.BurialId
            };

            await Database.Victims.UpdateAsync(victim);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            Victim victim = await Database.Victims.GetAsync(id);

            if (victim == null)
                return false;

            await Database.Victims.DeleteAsync(id);

            return true;
        }

        public async ValueTask DisposeAsync()
        {
            await Database.DisposeAsync();
        }

    }
}
