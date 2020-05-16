using System.Collections.Generic;
using System.Linq;
using web_api_2_portfolio_project.Shared;
using web_api_2_portfolio_project.UsersModels;

namespace web_api_2_portfolio_project.UsersMethods
{
    public class SearchByName
    {
        public dynamic SearchUsersByName(DBC dbc, UsersSearchRequest request, List<string> errors)
        {
            string firstName = !string.IsNullOrWhiteSpace(request.FirstName) ?
                               request
                               .FirstName
                               .ToLower()
                               .Replace(" ", "") : 
                               string.Empty;

            string lastName = !string.IsNullOrEmpty(request.LastName) ?
                              request
                              .LastName
                              .ToLower()
                              .Replace(" ", "") :
                              string.Empty;

            if(!string.IsNullOrWhiteSpace(firstName) &&
               !string.IsNullOrWhiteSpace(lastName))
            {
                if(dbc
                   .Users
                   .Where(x => x.FirstName == firstName &&
                          x.LastName == lastName)
                   .Any())
                {
                    return dbc
                           .Users
                           .Where(x => x.FirstName == firstName &&
                                  x.LastName == lastName)
                           .ToList();
                }
                else
                {
                    errors.Add($"No users found with a first name of '{request.FirstName}' and a last name of '{request.LastName}'.");

                    return errors;
                }
            } 
            else if(!string.IsNullOrWhiteSpace(firstName) &&
                      string.IsNullOrWhiteSpace(lastName))
            {
                if(dbc
                   .Users
                   .Where(x => x.FirstName == firstName)
                   .Any())
                {
                    return dbc
                           .Users
                           .Where(x => x.FirstName == firstName)
                           .ToList();
                }
                else
                {
                    errors.Add($"No users found with a first name of '{request.FirstName}'.");

                    return errors;
                }
            } 
            else if(string.IsNullOrWhiteSpace(firstName) &&
                    !string.IsNullOrWhiteSpace(lastName))
            {
                if(dbc
                   .Users
                   .Where(x => x.LastName == lastName)
                   .Any())
                {
                    return dbc
                           .Users
                           .Where(x => x.LastName == lastName)
                           .ToList();
                }
                else
                {
                    errors.Add($"No users found with a last name of '{request.LastName}'.");
                }
            }
            else
            {
                errors.Add("No users found.");
            }

            return errors;
        }
    }
}