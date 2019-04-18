using Microsoft.AspNetCore.Mvc;
using OdeToFood.Models;
using OdeToFood.Services;
using OdeToFood.ViewModels;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        private IRestaurantRepository _restaurantRepository;
        private IGreeter _greeter;

        public HomeController(IRestaurantRepository restaurantRepository,
                             IGreeter greeter)
        {
            _restaurantRepository = restaurantRepository;
            _greeter = greeter;
        }

        public IActionResult Index()
        {
            var model = new HomeIndexViewModel();
            model.Restaurants = _restaurantRepository.GetAll();
            model.CurrentMessage = _greeter.GetMessageOfTheDay();

            return View(model);
        }

        public IActionResult Details(int id)
        {
            var model = _restaurantRepository.GetRestaurant(id);

            if (model == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RestaurantDto restaurant)
        {
            if (ModelState.IsValid)
            {
                var newRestaurant = new Restaurant();
                newRestaurant.Name = restaurant.Name;
                newRestaurant.Cuisine = restaurant.Cuisine;

                newRestaurant = _restaurantRepository.Add(newRestaurant);

                return RedirectToAction(nameof(Details), new { id = newRestaurant.Id });
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _restaurantRepository.GetRestaurant(id);

            if (model == null)
            {
                RedirectToAction(nameof(Details), "Home");
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                restaurant = _restaurantRepository.Update(restaurant);

                return RedirectToAction(nameof(Details), "Home", new { id = restaurant.Id });
            }
            else
            {
                return View();
            }
        }
    }
}
