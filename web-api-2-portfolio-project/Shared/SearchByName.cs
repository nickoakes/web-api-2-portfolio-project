using System.Collections.Generic;
using System.Linq;

namespace web_api_2_portfolio_project.Shared
{
    public class SearchByName
    {
        public dynamic SearchEntitiesByName(DBC dbc, string table, string field, string name, List<string> errors)
        {
            string processedName = name.ToLower().Replace(" ", "");

            switch (table)
            {
                case "Users":

                    if(field == "FirstName")
                    {
                        if (dbc
                            .Users
                            .Where(x => x
                                        .FirstName
                                        .ToLower()
                                        .Replace(" ", "") == 
                                        processedName)
                            .Any())
                        {
                            return dbc
                                   .Users
                                   .Where(x => x
                                               .FirstName
                                               .ToLower()
                                               .Replace(" ", "") == 
                                               processedName)
                                   .ToList();
                        }
                        else
                        {
                            errors.Add($"No users found with a first name of '{name}'.");

                            return errors;
                        }
                    } 
                    else if(field == "LastName")
                    {
                        if (dbc
                            .Users
                            .Where(x => x
                                        .LastName
                                        .ToLower()
                                        .Replace(" ", "") ==
                                        processedName)
                            .Any())
                        {
                            return dbc
                                   .Users
                                   .Where(x => x
                                               .LastName
                                               .ToLower()
                                               .Replace(" ", "") ==
                                               processedName)
                                   .ToList();
                        }
                        else
                        {
                            errors.Add($"No users found with a last name of '{name}'.");

                            return errors;
                        }
                    }
                    else
                    {
                        errors.Add($"No users found with a {field} of '{name}'.");

                        return errors;
                    }

                case "SubscriptionTypes":

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
                        errors.Add($"No subscription type found with a name of '{name}'.");

                        return errors;
                    }

                default:

                    errors.Add("The field name passed was not recognised.");

                    return errors;
            }
        }
    }
}