using System.Collections.Generic;
using System.Linq;
using Restaurants.Core;

namespace Restaurants.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant { Id = 1, Name = "Fake restaurant 1", Location = "123 Nowhere street, Someton", Cuisine = CuisineType.Chinese },
                new Restaurant { Id = 2, Name = "Bake restaurant 2", Location = "123 Here street, Someton", Cuisine = CuisineType.Chinese },
                new Restaurant { Id = 3, Name = "Lake restaurant 3", Location = "123 There street, Someton", Cuisine = CuisineType.Chinese }
            };
        }

        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            //String.Equals(s, "Foo", StringComparison.CurrentCultureIgnoreCase)
            var s = restaurants.Where(n => n.Name.IndexOf(name ?? "", System.StringComparison.OrdinalIgnoreCase) != -1)
                               .OrderBy(r => r.Name);
            return s;
        }
    }
}
