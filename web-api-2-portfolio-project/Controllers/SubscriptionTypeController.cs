using Swashbuckle.Swagger.Annotations;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using web_api_2_portfolio_project.Shared;
using web_api_2_portfolio_project.SubscriptionTypeMethods;
using web_api_2_portfolio_project.SubscriptionTypeModels;

namespace web_api_2_portfolio_project.Controllers
{
    public class SubscriptionTypeController : ApiController
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

        [Route("subscription-types")]
        [HttpPost]
        [SwaggerResponse(200, Description = "Success", Type = typeof(User))]
        public dynamic GetSubscriptionType(SubscriptionTypeSearchRequest request)
        {
            SubscriptionTypeSearchSummary subscriptionTypeSearchSummary = new SubscriptionTypeSearchSummary();

            if (CheckClientSecret())
            {
                return subscriptionTypeSearchSummary.SearchSubscriptionTypes(request);
            }
            else
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
            }
        }
    }
}