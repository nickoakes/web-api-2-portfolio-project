using Swashbuckle.Swagger.Annotations;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using web_api_2_portfolio_project.RegionMethods;
using web_api_2_portfolio_project.RegionModels;
using web_api_2_portfolio_project.Shared;

namespace web_api_2_portfolio_project.Controllers
{
    [RoutePrefix("api")]
    public class RegionController : ApiController
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

        [Route("regions")]
        [HttpPost]
        [SwaggerResponse(200, Description = "Success", Type = typeof(Region))]
        public dynamic GetRegion(RegionSearchRequest request)
        {
            RegionSearchSummary regionSearchSummary = new RegionSearchSummary();

            if (CheckClientSecret())
            {
                return regionSearchSummary.SearchRegions(request);
            }
            else
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
            }
        }
    }
}