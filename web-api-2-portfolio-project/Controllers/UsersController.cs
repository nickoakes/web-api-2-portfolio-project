using System;
using System.Linq;
using System.Web.Http;
using web_api_2_portfolio_project.Shared;

namespace web_api_2_portfolio_project.Controllers
{
    [RoutePrefix("api")]
    public class UsersController : ApiController
    {
        [Route("users/{userID}")]
        [HttpGet]
        public User GetUser(Guid userID)
        {
            using(var dbc = DBC.DatabaseConnection())
            {
                return dbc.Users.Where(x => x.UserID == userID).FirstOrDefault();
            }
        }
    }
}