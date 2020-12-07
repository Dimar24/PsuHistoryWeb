using PsuHistoryWeb.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PsuHistoryWeb.Service.Interfaces
{
    public interface IUserService
    {
        Task<bool> Register(User item, string password);
        Task<bool> Login(User item, string password);
        Task Logout();
    }
}
