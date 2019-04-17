using Microsoft.AspNetCore.Mvc;
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
            var model = new RestaurantDto();
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
        public IActionResult Create(RestaurantDto restaurant)
        {
            return View();
        }
    }
}
