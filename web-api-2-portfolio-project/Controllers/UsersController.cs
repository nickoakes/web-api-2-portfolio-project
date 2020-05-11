using Swashbuckle.Swagger.Annotations;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using web_api_2_portfolio_project.Shared;
using web_api_2_portfolio_project.UsersMethods;
using web_api_2_portfolio_project.UsersModels;

namespace web_api_2_portfolio_project.Controllers
{
    [RoutePrefix("api")]
    public class UsersController : ApiController
    {
        private bool CheckClientSecret()
        {
            IEnumerable<string> headerValuesClientSecret;
            IEnumerable<string> headerValuesClientID;

            if (Request
                .Headers
                .TryGetValues("client-secret", out headerValuesClientSecret) &&
                (Request
                .Headers
                .TryGetValues("client-id", out headerValuesClientID)))
            {
                if (string
                    .Equals(headerValuesClientSecret.FirstOrDefault(), Config.GetClientSecret()) &&
                    (string
                    .Equals(headerValuesClientID.FirstOrDefault(), Config.GetClientID())))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        [Route("users")]
        [HttpPost]
        [SwaggerResponse(200, Description = "Success", Type = typeof(User))]
        public dynamic GetUser(UsersSearchRequest request)
        {
            UserSearchSummary userSearchSummary = new UserSearchSummary();

            if (CheckClientSecret())
            {
                return userSearchSummary.SearchByUser(request);
            }
            else
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
            }
        }
    }
}