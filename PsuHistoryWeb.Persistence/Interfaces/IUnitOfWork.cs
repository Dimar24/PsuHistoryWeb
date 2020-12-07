using Microsoft.AspNetCore.Identity;
using PsuHistoryWeb.Domain.Entities.Histories;
using PsuHistoryWeb.Domain.Entities.Monuments;
using PsuHistoryWeb.Domain.Entities.Users;
using PsuHistoryWeb.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PsuHistoryWeb.Persistence.Interfaces
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        UserManager<User> Users { get; }
        RoleManager<Role> Roles { get; }
        SignInManager<User> SignIn { get; }

        IRepository<AttachmentForm> AttachmentForms { get; }
        IRepository<Form> Forms { get; }

        IRepository<AttachmentBurial> AttachmentBurials { get; }
        IRepository<BirthPlace> BirthPlaces { get; }
        IRepository<Burial> Burials { get; }
        IRepository<ConscriptionPlace> ConscriptionPlaces { get; }
        IRepository<DutyStation> DutyStations { get; }
        IRepository<TypeBurial> TypeBurials { get; }
        IRepository<TypeVictim> TypeVictims { get; }
        IRepository<Victim> Victims { get; }

        void Save();
        Task SaveAsync();
    }
}
