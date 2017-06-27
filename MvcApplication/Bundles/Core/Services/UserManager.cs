using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MvcApplication.Bundles.Core.Context;
using MvcApplication.Bundles.Core.Entity;
using MvcApplication.Bundles.Core.Services.Manager;

namespace MvcApplication.Bundles.Core.Services
{
    public class UserManager : BaseManager<User>
    {
        public UserManager(string connectionString) : base(connectionString)
        {
        }

        public override List<User> GetAll(int id = 0)
        {
            List<User> users;

            try
            {
                using (var userCtx = new UserDbContext(GetConnectionString()))
                {
                    users = userCtx.Users.Where(u => u.Id == id).ToList();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return users;
        }

        public void UpdateUser(User user)
        {
            try
            {
                using (var userCtx = new UserDbContext(GetConnectionString()))
                {
                    userCtx.Entry(user).State = EntityState.Modified;
                    userCtx.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public bool AuthenticateUser(string email, string password)
        {
            User user;

            try
            {
                using (var userCtx = new UserDbContext(GetConnectionString()))
                {
                    user = userCtx.Users.Where(u => u.Email == email).ToList().First();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            if (user == null)
            {
                return false;
            }

            return user.Password == password;
        }
    }
}