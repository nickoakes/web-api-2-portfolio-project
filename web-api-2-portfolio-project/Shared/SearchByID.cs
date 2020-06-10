using System;
using System.Collections.Generic;
using System.Linq;
using web_api_2_portfolio_project.OfficeModels;
using web_api_2_portfolio_project.RegionModels;
using web_api_2_portfolio_project.UsersModels;

namespace web_api_2_portfolio_project.Shared
{
    public class SearchByID
    {
        public dynamic SearchEntitiesByID(DBC dbc, string table, string iD, List<string> errors)
        {
            if (Guid.TryParse(iD, out Guid parsedID))
            {
                switch (table)
                {
                    case "Users":

                        if (dbc.Users.Where(x => x.UserID == parsedID).Any())
                        {
                            return new UserDTO(dbc
                                               .Users
                                               .Where(x => x.UserID == parsedID)
                                               .FirstOrDefault(), dbc);
                        }
                        else
                        {
                            errors.Add($"No user found with an ID of '{iD}'");

                            return errors;
                        }

                    case "SubscriptionTypes":

                        if (dbc.SubscriptionTypes.Where(x => x.SubscriptionID == parsedID).Any())
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

                    case "Regions":

                        if (dbc.Regions.Where(x => x.RegionID == parsedID).Any())
                        {
                            return new RegionDTO(dbc
                                                 .Regions
                                                 .Where(x => x.RegionID == parsedID)
                                                 .FirstOrDefault(), dbc);
                        }
                        else
                        {
                            errors.Add($"No region found with an ID of '{iD}'");

                            return errors;
                        }

                    case "Offices":

                        if(dbc.Offices.Where(x => x.OfficeID == parsedID).Any())
                        {
                            return new OfficeDTO(dbc
                                                 .Offices
                                                 .Where(x => x
                                                             .OfficeID == parsedID)
                                                 .FirstOrDefault(),
                                                 dbc);
                        }
                        else
                        {
                            errors.Add($"No office found with an ID of '{iD}'");

                            return errors;
                        }

                    default:

                        errors.Add($"The field name passed was not recognised.");

                        return errors;
                }

                
            }
            else
            {
                errors.Add("Please ensure that a GUID-parsable string is submitted for ID.");

                return errors;
            }
        }
    }
}