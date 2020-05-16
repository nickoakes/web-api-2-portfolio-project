using System.Collections.Generic;
using System.Linq;

namespace web_api_2_portfolio_project.Shared
{
    public class MatchedUsers
    {
        public dynamic ProcessMatchedUsers(List<User> matchedUsers,
                                           List<User> prevMatchedUsers,
                                           string searchField,
                                           string searchValue,
                                           List<string> errors)
        {
            if (matchedUsers.Any() && prevMatchedUsers.Any())
            {
                foreach (User user in prevMatchedUsers)
                {
                    if (!matchedUsers.Contains(user))
                    {
                        prevMatchedUsers.Remove(user);
                    }
                }

                return prevMatchedUsers;
            }
            else if (matchedUsers.Any())
            {
                return matchedUsers;
            }
            else
            {
                errors.Add($"No users were found for the {searchField} '{searchValue}'");

                return errors;
            }
        }
    }
}