using System.Collections.Generic;
using System.Linq;
using web_api_2_portfolio_project.OfficeModels;
using web_api_2_portfolio_project.Shared;

namespace web_api_2_portfolio_project.OfficeMethods
{
    public class SearchByOfficeName
    {
        public dynamic SearchByName(DBC dbc, string name, List<string> errors)
        {
            string processedName = name.ToLower().Replace(" ", "");

            if(dbc
               .Offices
               .Where(x => x
                           .OfficeName
                           .ToLower()
                           .Replace(" ", "") == processedName)
               .Any())
            {
                return new OfficeDTO(dbc
                                     .Offices
                                     .Where(x => x
                                                 .OfficeName
                                                 .ToLower()
                                                 .Replace(" ", "") == processedName)
                                     .FirstOrDefault(), dbc);
            }
            else
            {
                errors.Add($"No office found with the name '{name}'.");

                return errors;
            }
        }
    }
}