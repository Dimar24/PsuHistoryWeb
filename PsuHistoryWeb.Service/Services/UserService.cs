using Microsoft.AspNetCore.Identity;
using PsuHistoryWeb.Domain.Entities.Users;
using PsuHistoryWeb.Persistence.Interfaces;
using PsuHistoryWeb.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PsuHistoryWeb.Service.Services
{
    public class UserService : IUserService
    {
        IUnitOfWork Database { get; set; }

        public UserService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task<bool> Register(User item, string password)
        {
            var user = await Database.Users.FindByNameAsync(item.UserName);
            if (user == null)
            {
                user = new User { UserName = item.UserName };

                var checkAdd = await Database.Users.CreateAsync(user, password);

                var userRole = await Database.Roles.FindByNameAsync("user");

                if (userRole == null)
                {
                    await Database.Roles.CreateAsync(new Role() { Name = "user" });
                    userRole = await Database.Roles.FindByNameAsync("user");
                }

                await Database.Users.AddToRoleAsync(user, userRole.Name);

                if (checkAdd.Succeeded)
                {
                    await Database.SignIn.SignInAsync(user, false);
                    return true;
                }
            }
            return false;
        }


        public async Task<bool> Login(User item, string password)
        {
            var user = await Database.Users.FindByNameAsync(item.UserName);
            if (user != null)
            {
                var checkPassword = await Database.SignIn.CheckPasswordSignInAsync(user, password, false);

                if (checkPassword.Succeeded)
                {
                    await Database.SignIn.SignInAsync(user, false);
                    return true;
                }
            }
            return false;

        }

        public async Task Logout()
        {
            await Database.SignIn.SignOutAsync();
        }
    }
}
