using System.Collections.Generic;
using System.Linq;
using web_api_2_portfolio_project.RegionModels;
using web_api_2_portfolio_project.Shared;

namespace web_api_2_portfolio_project.RegionMethods
{
    public class SearchByRegionName
    {
        public dynamic SearchRegionsByName(DBC dbc, string name, List<string> errors)
        {
            string processedName = name.ToLower().Replace(" ", "");

            if (dbc
               .Regions
               .Where(x => x
                           .RegionName
                           .ToLower()
                           .Replace(" ", "") == processedName)
               .Any())
            {
                return new RegionDTO(dbc
                                     .Regions
                                     .Where(x => x
                                                 .RegionName
                                                 .ToLower()
                                                 .Replace(" ", "") == processedName)
                                     .FirstOrDefault(),
                                     dbc);
            }
            else
            {
                errors.Add($"No region was found with the name '{name}'");

                return errors;
            }
        }
    }
}