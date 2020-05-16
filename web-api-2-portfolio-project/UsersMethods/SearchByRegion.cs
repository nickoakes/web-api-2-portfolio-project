using System.Collections.Generic;
using System.Linq;
using web_api_2_portfolio_project.Shared;

namespace web_api_2_portfolio_project.UsersMethods
{
    public class SearchByRegion
    {
        public dynamic SearchUsersByRegion(DBC dbc, string region, List<string> errors, List<User> prevMatchedUsers)
        {
            List<User> matchedUsers = new List<User>();

            MatchedUsers methods = new MatchedUsers();

            if (!string.IsNullOrWhiteSpace(region))
            {
                List<string> regionList = region
                                          .Split('|')
                                          .ToList();

                foreach(string item in regionList)
                {
                    if(dbc.Regions.Where(x => x
                                              .RegionName
                                              .ToLower() == 
                                              item
                                              .ToLower())
                                  .Any())
                    {
                        Region matchedRegion = dbc.Regions.Where(x => x
                                                                      .RegionName
                                                                      .ToLower() ==
                                                                      item
                                                                      .ToLower())
                                                          .FirstOrDefault();

                        foreach(User user in dbc.Users.Where(x => x.RegionID ==
                                                                  matchedRegion.RegionID))
                        {
                            matchedUsers.Add(user);
                        }
                    }
                    else
                    {
                        errors.Add($"The region '{region}' was not found");

                        return errors;
                    }
                }
            }

            return methods.ProcessMatchedUsers(matchedUsers, 
                                               prevMatchedUsers, 
                                               "region", 
                                               region, 
                                               errors);
        }
    }
}