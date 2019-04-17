using OdeToFood.Models;
using System.Collections.Generic;

namespace OdeToFood.ViewModels
{
    public class RestaurantDto
    {
        public IEnumerable<Restaurant> Restaurants { get; set; }
        public string CurrentMessage { get; set; }
    }
}
