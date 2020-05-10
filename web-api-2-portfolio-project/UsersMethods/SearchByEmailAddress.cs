using System.Collections.Generic;
using System.Linq;
using web_api_2_portfolio_project.Shared;

namespace web_api_2_portfolio_project.UsersMethods
{
    public class SearchByEmailAddress
    {
        public dynamic SearchUsersByEmailAddress(DBC dbc, string emailAddress, List<string> errors)
        {
            if (!string.IsNullOrWhiteSpace(emailAddress))
            {
                if(dbc.Users.Where(x => x.EmailAddress == emailAddress).Any())
                {
                    return dbc.Users.Where(x => x.EmailAddress == emailAddress).ToList();
                }
                else
                {
                    errors.Add("No users found with the email address " + emailAddress);
                }
            }

            return errors;
        }
    }
}