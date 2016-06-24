using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.IO;

namespace Pagination.Models
{
    public class DataInitializer
    {
        private ApplicationDbContext _ctx;
        private MithunDbContext _mithunDbContext;
        private UserManager<ApplicationUser> _userManager;

        public void InitializeDataAsync(IServiceProvider serviceProvider)
       {
            _userManager = serviceProvider.GetService<UserManager<ApplicationUser>>(); ;
            _mithunDbContext = serviceProvider.GetService<MithunDbContext>();
            CreateUsersAsync();
            CreateMenu();
        }

        private void CreateUsersAsync()
        {
            ApplicationUser user = _userManager.FindByEmailAsync("mithun@gmail.com").Result;
            if (user == null)
            {
                user = new ApplicationUser { UserName = "mithun", Email = "mithun@gmail.com" };
                _userManager.CreateAsync(user, "Mithun@123");
                
            }
            
        }

        private void CreateMenu()
        {
            var productlst = new List<Product>
            {
            new Product  { Name="Apple", Unit="KG", Quantity=2,Price=200},
            new Product  { Name="Mango", Unit="KG", Quantity=3,Price=300},
            new Product  { Name="Oil", Unit="liter", Quantity=2,Price=250},
            new Product  { Name="Banana", Unit="Pieces", Quantity=12,Price=80},
            };
            foreach (var item in productlst)
            {
                var productexit = _mithunDbContext.Product.Any(r => r.Name == item.Name);
                if (!productexit)
                {
                    _mithunDbContext.Product.Add(item);
                }
            }
            _mithunDbContext.SaveChanges();
        }
    }

}
