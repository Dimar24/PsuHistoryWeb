using PsuHistoryWeb.Domain.Entities.Users;
using PsuHistoryWeb.Persistence.Interfaces;
using PsuHistoryWeb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsuHistoryWeb.Service.Services.Admin
{
    class UserService : IService<User>
    {
        IUnitOfWork Database { get; set; }

        public UserService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public Task<bool> CreateAsync(User item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public ValueTask DisposeAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(User item)
        {
            throw new NotImplementedException();
        }

        public Task<User> FindAsync(User item)
        {
            throw new NotImplementedException();
        }
    }
}
