using System.Collections.Generic;
using System.Linq;
using web_api_2_portfolio_project.Shared;

namespace web_api_2_portfolio_project.UsersMethods
{
    public class SearchBySubscriptionType
    {
        public dynamic SearchUsersBySubscriptionType(DBC dbc,
                                                     string subscriptionType,
                                                     List<string> errors,
                                                     List<User> prevMatchedUsers)
        {
            List<User> matchedUsers = new List<User>();

            MatchedUsers methods = new MatchedUsers();

            if (!string.IsNullOrWhiteSpace(subscriptionType))
            {
                List<string> subscriptionTypeList = subscriptionType.Split('|').ToList();

                foreach(string type in subscriptionTypeList)
                {
                    if(dbc.SubscriptionTypes.Where(x => x.SubscriptionName.ToLower() ==
                                                        type.ToLower())
                                            .Any())
                    {
                        SubscriptionType matchedType = dbc
                                                       .SubscriptionTypes
                                                       .Where(x => x.SubscriptionName.ToLower() ==
                                                                   type.ToLower())
                                                       .FirstOrDefault();

                        foreach(User user in dbc.Users.Where(x => x.SubscriptionID ==
                                                                  matchedType.SubscriptionID))
                        {
                            matchedUsers.Add(user);
                        }
                    }
                    else
                    {
                        errors.Add($"The subscription type '{subscriptionType}' was not found.");

                        return errors;
                    }
                }
            }

            return methods.ProcessMatchedUsers(matchedUsers,
                                               prevMatchedUsers,
                                               "subscription type",
                                               subscriptionType,
                                               errors);
        }
    }
}