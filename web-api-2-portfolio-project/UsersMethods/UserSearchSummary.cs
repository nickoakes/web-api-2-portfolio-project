using System.Collections.Generic;
using System.Linq;
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

            SearchBySubscriptionType searchBySubscriptionType = new SearchBySubscriptionType();

            SearchByActiveSubscription searchByActiveSubscription = new SearchByActiveSubscription();

            List<string> errors = new List<string>();

            List<User> matchedUsers = new List<User>();

            DBC dbc = DBC.DatabaseConnection();

            if (!string.IsNullOrEmpty(request.UserID))
            {
                return searchByID.SearchEntitiesByID(dbc, "Users", request.UserID, errors);
            }

            if (!string.IsNullOrWhiteSpace(request.FirstName) ||
                !string.IsNullOrWhiteSpace(request.LastName))
            {
                var result = searchByName.SearchUsersByName(dbc, request, errors);

                if (result.GetType() == typeof(List<User>))
                {
                    matchedUsers = result;
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
                var result = searchByRegion.SearchUsersByRegion(dbc, 
                                                                request.Region, 
                                                                errors, 
                                                                matchedUsers);

                if(result.GetType() == typeof(List<User>))
                {
                    matchedUsers = result;
                }
                else
                {
                    foreach(string error in (List<string>)result)
                    {
                        errors.Add(error);
                    }
                }
            }

            if (!string.IsNullOrWhiteSpace(request.SubscriptionType))
            {
                var result = searchBySubscriptionType
                             .SearchUsersBySubscriptionType(dbc,
                                                            request.SubscriptionType,
                                                            errors,
                                                            matchedUsers);

                if(result.GetType() == typeof(List<User>))
                {
                    matchedUsers = result;
                }
                else
                {
                    foreach(string error in (List<string>)result)
                    {
                        errors.Add(error);
                    }
                }
            }

            if(request.ActiveSubscription != null)
            {
                var result = searchByActiveSubscription
                             .SearchUsersByActiveSubscription(dbc,
                                                              request.ActiveSubscription,
                                                              errors,
                                                              matchedUsers);

                if(result.GetType() == typeof(List<User>))
                {
                    List<UserDTO> userDTOs = new List<UserDTO>();

                    foreach(User user in result)
                    {
                        userDTOs.Add(new UserDTO(user, dbc));
                    }

                    return userDTOs;
                }
                else
                {
                    matchedUsers = new List<User>();

                    errors = result;
                }
            }

            if (matchedUsers.Any())
            {
                List<UserDTO> userDTOs = new List<UserDTO>();

                foreach (User user in matchedUsers)
                {
                    userDTOs.Add(new UserDTO(user, dbc));
                }

                return userDTOs;
            } 
            else if (errors.Any())
            {
                return errors;
            }
            else
            {
                return new NoParameterUserResponse("Please submit at least one search parameter to return users");
            }
        }
    }
}