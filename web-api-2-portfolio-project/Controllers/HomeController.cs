using System.Web.Http;

namespace web_api_2_portfolio_project.Controllers
{
    public class HomeController : ApiController
    {
        [Route("")]
        [HttpGet]
        public string Home()
        {
            return "Running";
        }
    }
}