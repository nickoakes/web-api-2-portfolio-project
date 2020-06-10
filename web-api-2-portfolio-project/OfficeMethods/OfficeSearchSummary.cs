using System.Collections.Generic;
using web_api_2_portfolio_project.OfficeModels;
using web_api_2_portfolio_project.Shared;

namespace web_api_2_portfolio_project.OfficeMethods
{
    public class OfficeSearchSummary
    {
        public dynamic SearchOffices(OfficeSearchRequest request)
        {
            SearchByID searchByID = new SearchByID();

            SearchByOfficeName searchByOfficeName = new SearchByOfficeName();

            SearchByOfficeManager searchByOfficeManager = new SearchByOfficeManager();

            List<string> errors = new List<string>();

            DBC dbc = DBC.DatabaseConnection();

            if (!string.IsNullOrWhiteSpace(request.OfficeID))
            {
                return searchByID
                       .SearchEntitiesByID(dbc, "Offices", request.OfficeID, errors);
            }

            if (!string.IsNullOrWhiteSpace(request.OfficeName))
            {
                return searchByOfficeName
                       .SearchByName(dbc, request.OfficeName, errors);
            }

            if (!string.IsNullOrWhiteSpace(request.OfficeManager))
            {
                return searchByOfficeManager
                       .SearchByManager(dbc, request.OfficeManager, errors);
            }
            else
            {
                return new NoParameterOfficeResponse("No offices found. Please check your request for validity against the fields below.");
            }
        }
    }
}