using Microsoft.EntityFrameworkCore;
using Restaurants.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restaurants.Data
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly RestaurantsDbContext _db;

        public SqlRestaurantData(RestaurantsDbContext db)
        {
            _db = db;
        }
        public Restaurant Add(Restaurant newRestaurant)
        {
            _db.Add(newRestaurant);
            return newRestaurant;
        }

        public int Commit()
        {
            return _db.SaveChanges();
        }

        public Restaurant Delete(int id)
        {
            var restaurant = GetById(id);
            if (restaurant != null)
            {
                _db.Restaurants.Remove(restaurant);
            }
            return restaurant;
        }

        public Restaurant GetById(int id)
        {
            return _db.Restaurants.Find(id);
        }

        public int GetCountOfRestaurants()
        {
            return _db.Restaurants.Count();
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            return _db.Restaurants.Where<Restaurant>(r => r.Name.IndexOf(name ?? "", System.StringComparison.OrdinalIgnoreCase) != -1)
                                  .OrderBy(r => r.Name);
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var entity = _db.Attach(updatedRestaurant);
            entity.State = EntityState.Modified;
            return updatedRestaurant;
        }
    }
}
