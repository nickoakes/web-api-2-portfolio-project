using System.Collections.Generic;
using web_api_2_portfolio_project.Shared;
using web_api_2_portfolio_project.UsersModels;

namespace web_api_2_portfolio_project.UsersMethods
{
    public class UserSearchSummary
    {
        public dynamic SearchByUser(UsersSearchRequest request)
        {
            SearchByID searchByID = new SearchByID();

            SearchByName searchByName = new SearchByName();

            SearchByRegion searchByRegion = new SearchByRegion();

            List<string> errors = new List<string>();

            List<User> matchedUsers = new List<User>();

            DBC dbc = DBC.DatabaseConnection();

            if (!string.IsNullOrEmpty(request.UserID))
            {
                return searchByID.SearchUsersByID(dbc, request.UserID, errors);
            }

            if (!string.IsNullOrWhiteSpace(request.FirstName) ||
                !string.IsNullOrWhiteSpace(request.LastName))
            {
                var result = searchByName.SearchUsersByName(dbc, request, errors);

                if (result.GetType() == typeof(List<User>))
                {
                    foreach(User user in (List<User>)result)
                    {
                        matchedUsers.Add(user);
                    }
                }
                else
                {
                    foreach(string error in (List<string>)result)
                    {
                        errors.Add(error);
                    }
                }
            }

            if (!string.IsNullOrWhiteSpace(request.Region))
            {
                return searchByRegion.SearchUsersByRegion(dbc, request.Region, errors);
            }

            return new NoParameterUserResponse("Please submit at least one search parameter to return users");
        }
    }
}