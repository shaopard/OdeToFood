using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OdeToFood.Models;

namespace OdeToFood.Services
{
    public class InMemoryRestaurantData : IRestaurantRepository
    {
        List<Restaurant> _restaurants;

        public InMemoryRestaurantData()
        {
            _restaurants = new List<Restaurant>
            {
                new Restaurant { Id = 1, Name = "Scotts Restaurant" },
                new Restaurant { Id = 2, Name = "Scotts Pizzeria" },
                new Restaurant { Id = 3, Name = "Pizza Tugos" }
            };
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants.OrderBy(r => r.Name);
        }

        public Restaurant GetRestaurant(int id)
        {
            return _restaurants.FirstOrDefault(r => r.Id == id);
        }
    }
}
