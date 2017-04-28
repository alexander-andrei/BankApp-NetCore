using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MvcApplication.Bundles.Core.Context;
using MvcApplication.Config.Users;

namespace MvcApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ConnectionConfiguration _confgurations;

        public HomeController(IOptions<ConnectionConfiguration> subOptionsAccessor)
        {
            _confgurations = subOptionsAccessor.Value;
        }

        public ViewResult Index()
        {
            using (var context = new UserDbContext(_confgurations.ConnectionString))
            {
                var users = context.Users.ToList();
                foreach (var user in users)
                {
                    Console.WriteLine($"{ user.Id } { user.Name } { user.Surname } { user.Account } { user.Ballance }");
                }
            }

            return View();
        }
    }
}
