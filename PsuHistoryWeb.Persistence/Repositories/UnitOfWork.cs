using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PsuHistoryWeb.Domain.Entities.Histories;
using PsuHistoryWeb.Domain.Entities.Monuments;
using PsuHistoryWeb.Domain.Entities.Users;
using PsuHistoryWeb.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PsuHistoryWeb.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        ApplicationDbContext db;

        private UserManager<User> userManager;
        private RoleManager<Role> roleManager;
        private SignInManager<User> signInManager;

        private AttachmentFormRepository attachmentFormRepository;
        private FormRepository formRepository;

        private AttachmentBurialRepository attachmentBurialRepository;
        private BirthPlaceRepository birthPlaceRepository;
        private BurialRepository burialRepository;
        private ConscriptionPlaceRepository conscriptionPlaceRepository;
        private DutyStationRepository dutyStationRepository;
        private TypeBurialRepository typeBurialRepository;
        private TypeVictimRepository typeVictimRepository;
        private VictimRepository victimRepository;

        public UnitOfWork(DbContextOptions<ApplicationDbContext> options, UserManager<User> _userManager,
            RoleManager<Role> _roleManager, SignInManager<User> _signInManager)
        {
            db = new ApplicationDbContext(options);
            userManager = _userManager;
            roleManager = _roleManager;
            signInManager = _signInManager;
        }

        public UserManager<User> Users { get { return userManager; } }

        public RoleManager<Role> Roles { get { return roleManager; } }

        public SignInManager<User> SignIn { get { return signInManager; } }

        public IRepository<AttachmentForm> AttachmentForms
        {
            get
            {
                return attachmentFormRepository = attachmentFormRepository ?? new AttachmentFormRepository(db);
            }
        }

        public IRepository<Form> Forms
        {
            get
            {
                return formRepository = formRepository ?? new FormRepository(db);
            }
        }

        public IRepository<AttachmentBurial> AttachmentBurials
        {
            get
            {
                return attachmentBurialRepository = attachmentBurialRepository ?? new AttachmentBurialRepository(db);
            }
        }

        public IRepository<BirthPlace> BirthPlaces
        {
            get
            {
                return birthPlaceRepository = birthPlaceRepository ?? new BirthPlaceRepository(db);
            }
        }

        public IRepository<Burial> Burials
        {
            get
            {
                return burialRepository = burialRepository ?? new BurialRepository(db);
            }
        }

        public IRepository<ConscriptionPlace> ConscriptionPlaces
        {
            get
            {
                return conscriptionPlaceRepository = conscriptionPlaceRepository ?? new ConscriptionPlaceRepository(db);
            }
        }

        public IRepository<DutyStation> DutyStations
        {
            get
            {
                return dutyStationRepository = dutyStationRepository ?? new DutyStationRepository(db);
            }
        }

        public IRepository<TypeBurial> TypeBurials
        {
            get
            {
                return typeBurialRepository = typeBurialRepository ?? new TypeBurialRepository(db);
            }
        }

        public IRepository<TypeVictim> TypeVictims
        {
            get
            {
                return typeVictimRepository = typeVictimRepository ?? new TypeVictimRepository(db);
            }
        }

        public IRepository<Victim> Victims
        {
            get
            {
                return victimRepository = victimRepository ?? new VictimRepository(db);
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
        }

        private bool disposed = false;

        public virtual async ValueTask DisposeAsync(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    await db.DisposeAsync();
                }
                disposed = true;
            }
        }

        public async ValueTask DisposeAsync()
        {
            await DisposeAsync(true);
            GC.SuppressFinalize(this);
        }
    }
}
