using Microsoft.AspNetCore.Mvc;

namespace OdeToFood.Controllers
{
    [Route("company/[controller]/[action]")]
    //[Route("[controller]")]
    //[Route("about")]
    public class AboutController
    {

        [Route("")]
        public string Phone()
        {
            return "Phone number";
        }

        [Route("[action]")]
        public string Address()
        {
            return "USA";
        }
    }
}
