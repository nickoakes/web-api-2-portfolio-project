using System.Collections.Generic;
using System.Linq;
using web_api_2_portfolio_project.Shared;

namespace web_api_2_portfolio_project.RegionMethods
{
    public class SearchByHeadOffice
    {
        public dynamic SearchRegionsByHeadOffice(DBC dbc, string officeName, List<string> errors)
        {
            string processedName = officeName.ToLower().Replace(" ", "");

            if(dbc
               .Offices
               .Where(x => x
                           .OfficeName
                           .ToLower()
                           .Replace(" ", "") == processedName)
               .Any())
            {
                Office matchedOffice = dbc
                                       .Offices
                                       .Where(x => x.OfficeName == processedName)
                                       .FirstOrDefault();

                if(dbc
                   .Regions
                   .Where(x => x.RegionHeadOfficeID == matchedOffice.OfficeID)
                   .Any())
                {
                    return dbc
                           .Regions
                           .Where(x => x.RegionHeadOfficeID == matchedOffice.OfficeID)
                           .FirstOrDefault();
                }
                else
                {
                    errors.Add($"No regions were found for the office with name '{officeName}'");

                    return errors;
                }
            }
            else
            {
                errors.Add($"No office found with the name '{officeName}'");

                return errors;
            }
        }
    }
}