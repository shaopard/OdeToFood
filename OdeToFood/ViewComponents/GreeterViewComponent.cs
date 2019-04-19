using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using OdeToFood.Services;
using System;

namespace OdeToFood.ViewComponents
{
    public class GreeterViewComponent : ViewComponent
    {
        private IGreeter _greeter;
        private IHostingEnvironment _environment;

        public GreeterViewComponent(IGreeter greeter, IHostingEnvironment environment)
        {
            _greeter = greeter;
            _environment = environment;
        }

        public IViewComponentResult Invoke()
        {
            //var model = _greeter.GetMessageOfTheDay();

            var model = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            return View("Default", model);
        }
    }
}
