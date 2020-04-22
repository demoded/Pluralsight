using Microsoft.EntityFrameworkCore;
using Restaurants.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurants.Data
{
    public class RestaurantsDbContext : DbContext
    {
        //dotnet-ef cli commands
        //dotnet ef migrations add initialCreate -s ..\Restaurants\Restaurants.csproj
        //dotnet ef database update -s ..\Restaurants\Restaurants.csproj
        public RestaurantsDbContext(DbContextOptions<RestaurantsDbContext> options) : base(options)
        {

        }
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
