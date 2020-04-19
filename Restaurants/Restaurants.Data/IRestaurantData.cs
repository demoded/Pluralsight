using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Restaurants.Core;

namespace Restaurants.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant { Id = 1, Name = "Fake restaurant 1", Location = "123 Nowhere street, Someton", Cuisine = CuisineType.Chinese },
                new Restaurant { Id = 2, Name = "Fake restaurant 2", Location = "123 Here street, Someton", Cuisine = CuisineType.Chinese },
                new Restaurant { Id = 3, Name = "Fake restaurant 3", Location = "123 There street, Someton", Cuisine = CuisineType.Chinese }
            };
        }
        public IEnumerable<Restaurant> GetAll()
        {
            return restaurants.OrderBy(r => r.Name);
        }
    }
}
