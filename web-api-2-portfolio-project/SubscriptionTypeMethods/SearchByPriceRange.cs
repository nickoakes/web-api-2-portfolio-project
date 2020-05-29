using System;
using System.Collections.Generic;
using System.Linq;
using web_api_2_portfolio_project.Shared;

namespace web_api_2_portfolio_project.SubscriptionTypeMethods
{
    public class SearchByPriceRange
    {
        public dynamic SearchSubscriptionTypesByPriceRange(DBC dbc, string min, string max, List<string> errors)
        {
            if(Double.TryParse(min, out double minPrice) &&
               Double.TryParse(max, out double maxPrice))
            {
                if(dbc
                   .SubscriptionTypes
                   .Where(x => x.SubscriptionMonthlyFee <= maxPrice && 
                               x.SubscriptionMonthlyFee >= minPrice)
                   .Any())
                {
                    return dbc
                           .SubscriptionTypes
                           .Where(x => x.SubscriptionMonthlyFee <= maxPrice &&
                                       x.SubscriptionMonthlyFee >= minPrice)
                           .ToList();
                }
                else
                {
                    errors.Add($"No subscription types found in the price range {min} - {max}");

                    return errors;
                }
            } 
            else if(Double.TryParse(min, out double minP) &&
                    !Double.TryParse(max, out double maxP))
            {
                errors.Add("Please ensure that the value submitted for 'SubscriptionMonthlyFeeMax' can be parsed to a double.");

                return errors;
            } 
            else if(!Double.TryParse(min, out double minPr) &&
                    Double.TryParse(max, out double maxPr))
            {
                errors.Add("Please ensure that the value submitted for 'SubscriptionMonthlyFeeMin' can be parsed to a double.");

                return errors;
            }
            else
            {
                errors.Add("Please ensure that the values submitted for 'SubscriptionMonthlyFeeMin' and 'SubscriptionMonthlyFeeMax' can be parsed to doubles.");

                return errors;
            }
        }
    }
}