using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WEB_API_DEMO_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        [Route("get-all")]
        public string getAll()
        {
            return "getAll method with the route mapped to get-all";
        }

        [HttpGet]   // REQUIRED
        [Route("get-allAuth_Users")]
        public string getAllAuth()
        {
            return "Authors List to Download";
        }

        [HttpGet]   // REQUIRED
        [Route("getBooks/{book}/getPrice/{price}")]
        public string getAllAuth(string book,decimal price)
        {
            return book+" cost is :- "+price;
        }                                                                                                                                                                                                                    


    }
}