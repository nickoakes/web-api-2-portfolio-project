using System.Collections.Generic;
using web_api_2_portfolio_project.Shared;
using web_api_2_portfolio_project.SubscriptionTypeModels;

namespace web_api_2_portfolio_project.SubscriptionTypeMethods
{
    public class SubscriptionTypeSearchSummary
    {
        public dynamic SearchSubscriptionTypes(SubscriptionTypeSearchRequest request)
        {
            SearchByID searchByID = new SearchByID();

            SearchByName searchByName = new SearchByName();

            SearchByPriceRange searchByPriceRange = new SearchByPriceRange();

            List<string> errors = new List<string>();

            DBC dbc = DBC.DatabaseConnection();

            if (!string.IsNullOrWhiteSpace(request.SubscriptionID))
            {
                return searchByID
                       .SearchEntitiesByID(dbc, "SubscriptionTypes", request.SubscriptionID, errors);
            }

            if(!string.IsNullOrWhiteSpace(request.SubscriptionName))
            {
                return searchByName
                       .SearchSubscriptionTypesByName(dbc, request.SubscriptionName, errors);
            }

            if(!string.IsNullOrWhiteSpace(request.SubscriptionMonthlyFeeMin) &&
                !string.IsNullOrWhiteSpace(request.SubscriptionMonthlyFeeMax))
            {
                return searchByPriceRange
                       .SearchSubscriptionTypesByPriceRange(dbc,
                                                            request.SubscriptionMonthlyFeeMin,
                                                            request.SubscriptionMonthlyFeeMax,
                                                            errors);
            } 
            else if(string.IsNullOrWhiteSpace(request.SubscriptionMonthlyFeeMin) &&
                    !string.IsNullOrWhiteSpace(request.SubscriptionMonthlyFeeMax))
            {
                return searchByPriceRange
                       .SearchSubscriptionTypesByPriceRange(dbc,
                                                            "0",
                                                            request.SubscriptionMonthlyFeeMax,
                                                            errors);
            } 
            else if(!string.IsNullOrWhiteSpace(request.SubscriptionMonthlyFeeMin) &&
                      string.IsNullOrWhiteSpace(request.SubscriptionMonthlyFeeMax))
            {
                return searchByPriceRange
                       .SearchSubscriptionTypesByPriceRange(dbc,
                                                            request.SubscriptionMonthlyFeeMin,
                                                            "0",
                                                            errors);
            }
            else
            {
                errors.Add("No subscription types found.");

                return errors;
            }
        }
    }
}