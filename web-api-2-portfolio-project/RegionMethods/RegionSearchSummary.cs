using System.Collections.Generic;
using web_api_2_portfolio_project.RegionModels;
using web_api_2_portfolio_project.Shared;

namespace web_api_2_portfolio_project.RegionMethods
{
    public class RegionSearchSummary
    {
        public dynamic SearchRegions(RegionSearchRequest request)
        {
            SearchByID searchByID = new SearchByID();

            SearchByRegionName searchByRegionName = new SearchByRegionName();

            SearchByHeadOffice searchByHeadOffice = new SearchByHeadOffice();

            List<string> errors = new List<string>();

            DBC dbc = DBC.DatabaseConnection();

            if (!string.IsNullOrWhiteSpace(request.RegionID))
            {
                return searchByID
                       .SearchEntitiesByID(dbc, "Regions", request.RegionID, errors);
            }

            if (!string.IsNullOrWhiteSpace(request.RegionName))
            {
                return searchByRegionName
                       .SearchRegionsByName(dbc, request.RegionName, errors);
            }

            if (!string.IsNullOrWhiteSpace(request.HeadOffice))
            {
                return searchByHeadOffice
                       .SearchRegionsByHeadOffice(dbc, request.HeadOffice, errors);
            }
            else
            {
                errors.Add("No regions found.");

                return errors;
            }
        }
    }
}