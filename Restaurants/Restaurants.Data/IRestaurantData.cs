﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Restaurants.Core;

namespace Restaurants.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetById(int id);
    }
}
