using System.Collections.Generic;
using System.Linq;
using web_api_2_portfolio_project.Shared;

namespace web_api_2_portfolio_project.SubscriptionTypeMethods
{
    public class SearchByName
    {
        public dynamic SearchSubscriptionTypesByName(DBC dbc, string name, List<string> errors)
        {
            string processedName = name.ToLower().Replace(" ", "");

            if(dbc
               .SubscriptionTypes
               .Where(x => x
                           .SubscriptionName
                           .ToLower()
                           .Replace(" ", "") == processedName)
               .Any())
            {
                return dbc
                       .SubscriptionTypes
                       .Where(x => x
                                   .SubscriptionName
                                   .ToLower()
                                   .Replace(" ", "") == processedName)
                       .FirstOrDefault();
            }
            else
            {
                errors.Add($"No subscription type was found with the name '{name}'");

                return errors;
            }
        }
    }
}