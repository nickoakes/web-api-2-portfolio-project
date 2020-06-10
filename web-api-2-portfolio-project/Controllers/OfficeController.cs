using Swashbuckle.Swagger.Annotations;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using web_api_2_portfolio_project.OfficeMethods;
using web_api_2_portfolio_project.OfficeModels;
using web_api_2_portfolio_project.Shared;

namespace web_api_2_portfolio_project.Controllers
{
    [RoutePrefix("api")]
    public class OfficeController : ApiController
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

        [Route("offices")]
        [HttpPost]
        [SwaggerResponse(200, Description = "Success", Type = typeof(List<OfficeDTO>))]
        public dynamic GetOffice(OfficeSearchRequest request)
        {
            OfficeSearchSummary officeSearchSummary = new OfficeSearchSummary();

            if (CheckClientSecret())
            {
                return officeSearchSummary.SearchOffices(request);
            }
            else
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
            }
        }
    }
}