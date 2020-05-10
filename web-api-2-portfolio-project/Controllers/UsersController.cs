using Swashbuckle.Swagger.Annotations;
using System.Collections.Generic;
using System.Web.Http;
using web_api_2_portfolio_project.Shared;
using web_api_2_portfolio_project.UsersMethods;
using web_api_2_portfolio_project.UsersModels;

namespace web_api_2_portfolio_project.Controllers
{
    [RoutePrefix("api")]
    public class UsersController : ApiController
    {
        [Route("users")]
        [HttpPost]
        [SwaggerResponse(200, Description = "Success", Type = typeof(User))]
        public dynamic GetUser(UsersSearchRequest request)
        {
            SearchByID searchByID = new SearchByID();

            SearchByName searchByName = new SearchByName();

            List<string> errors = new List<string>();

            DBC dbc = DBC.DatabaseConnection();

            if (!string.IsNullOrEmpty(request.UserID))
            {
                return searchByID.SearchUsersByID(dbc, request.UserID, errors);
            }

            if (!string.IsNullOrWhiteSpace(request.FirstName) ||
                !string.IsNullOrWhiteSpace(request.LastName))
            {
                return searchByName.SearchUsersByName(dbc, request, errors);
            }

            return new User();
        }
    }
}