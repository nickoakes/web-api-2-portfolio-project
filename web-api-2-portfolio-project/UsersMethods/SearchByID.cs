using System;
using System.Collections.Generic;
using System.Linq;
using web_api_2_portfolio_project.Shared;

namespace web_api_2_portfolio_project.UsersMethods
{
    public class SearchByID
    {
        public dynamic SearchUsersByID(DBC dbc, string iD, List<string> errors)
        {
            if(Guid.TryParse(iD, out Guid parsedID))
            {
                if(dbc.Users.Where(x => x.UserID == parsedID).Any())
                {
                    return dbc.Users.Where(x => x.UserID == parsedID);
                }
                else
                {
                    errors.Add($"No user found with an ID of '{iD}'");

                    return errors;
                }
            }
            else
            {
                errors.Add("Please ensure a GUID is submitted for UserID");

                return errors;
            }
        }
    }
}