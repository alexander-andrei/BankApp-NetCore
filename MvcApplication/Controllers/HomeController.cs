using System;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MvcApplication.Attributes;
using MvcApplication.Bundles.Core.Context;
using MvcApplication.Config.Users;
using MvcApplication.Services;

namespace MvcApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserConfiguration _confgurations;

        public HomeController(IOptions<UserConfiguration> subOptionsAccessor)
        {
            _confgurations = subOptionsAccessor.Value;
        }

        public ViewResult Index()
        {
            var x = _confgurations.ConnectionString;

            Console.WriteLine(x);
            using (var context = new UserDbContext())
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
