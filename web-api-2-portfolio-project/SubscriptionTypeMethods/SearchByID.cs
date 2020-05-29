using System;
using System.Collections.Generic;
using System.Linq;
using web_api_2_portfolio_project.Shared;

namespace web_api_2_portfolio_project.SubscriptionTypeMethods
{
    public class SearchByID
    {
        public dynamic SearchSubscriptionTypesByID(DBC dbc, string iD, List<string> errors)
        {
            if(Guid.TryParse(iD, out Guid parsedID))
            {
                if(dbc.SubscriptionTypes.Where(x => x.SubscriptionID == parsedID).Any())
                {
                    return dbc
                           .SubscriptionTypes
                           .Where(x => x.SubscriptionID == parsedID)
                           .FirstOrDefault();
                }
                else
                {
                    errors.Add($"No subscription type found with an ID of '{iD}'");

                    return errors;
                }
            }
            else
            {
                errors.Add("Please ensure a GUID is submitted for SubscriptionID");

                return errors;
            }
        }
    }
}