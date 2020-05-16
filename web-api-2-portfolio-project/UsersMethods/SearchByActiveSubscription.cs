using System;
using System.Collections.Generic;
using System.Linq;
using web_api_2_portfolio_project.Shared;

namespace web_api_2_portfolio_project.UsersMethods
{
    public class SearchByActiveSubscription
    {
        public dynamic SearchUsersByActiveSubscription(DBC dbc,
                                                       bool? subscriptionStatus,
                                                       List<string> errors,
                                                       List<User> prevMatchedUsers)
        {
            MatchedUsers methods = new MatchedUsers();

            string errorMessage = "No users found for the search parameters provided.";

            try
            {
                if (prevMatchedUsers.Any() && subscriptionStatus == true)
                {
                    if (prevMatchedUsers.Where(x => x.SubscriptionEndDate == null).Any())
                    {
                        return prevMatchedUsers.Where(x => x.SubscriptionEndDate == null).ToList();
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                else if (prevMatchedUsers.Any() && subscriptionStatus == false)
                {
                    if (prevMatchedUsers.Where(x => x.SubscriptionEndDate != null).Any())
                    {
                        return prevMatchedUsers.Where(x => x.SubscriptionEndDate != null).ToList();
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                else if (subscriptionStatus == true)
                {
                    if (dbc.Users.Where(x => x.SubscriptionEndDate == null).Any())
                    {
                        return dbc.Users.Where(x => x.SubscriptionEndDate == null).ToList();
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                else
                {
                    if(dbc.Users.Where(x => x.SubscriptionEndDate != null).Any())
                    {
                        return dbc.Users.Where(x => x.SubscriptionEndDate != null).ToList();
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
            }
            catch
            {
                errors.Add(errorMessage);

                return errors.ToList();
            }
        }
    }
}