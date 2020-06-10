using System.Collections.Generic;
using System.Linq;
using web_api_2_portfolio_project.OfficeModels;
using web_api_2_portfolio_project.Shared;

namespace web_api_2_portfolio_project.OfficeMethods
{
    public class SearchByOfficeManager
    {
        public dynamic SearchByManager(DBC dbc, string name, List<string> errors)
        {
            List<Staff> matchedStaff = new List<Staff>();

            List<OfficeDTO> matchedOffices = new List<OfficeDTO>();

            string processedName = name.ToLower().Replace(" ", "");

            if(dbc.Staff.Where(x => x.FirstName.ToLower() == processedName).Any())
            {
                foreach(Staff member in dbc
                                        .Staff
                                        .Where(x => x.FirstName.ToLower() == processedName))
                {
                    matchedStaff.Add(member);
                }
            } 
            else if(dbc.Staff.Where(x => x.LastName.ToLower() == processedName).Any())
            {
                foreach(Staff member in dbc
                                        .Staff
                                        .Where(x => x.LastName.ToLower() == processedName))
                {
                    matchedStaff.Add(member);
                }
            } 
            else if(dbc
                      .Staff
                      .Where(x => processedName
                                  .Contains(x
                                            .FirstName
                                            .ToLower()
                                            .Replace(" ", "") + 
                                            x
                                            .LastName
                                            .ToLower()
                                            .Replace(" ", "")))
                      .Any())
            {
                foreach(Staff member in dbc
                                        .Staff
                                        .Where(x => processedName
                                                    .Contains(x
                                                            .FirstName
                                                            .ToLower()
                                                            .Replace(" ", "") +
                                                            x
                                                            .LastName
                                                            .ToLower()
                                                            .Replace(" ", ""))))
                {
                    matchedStaff.Add(member);
                }
            }

            if (matchedStaff.Any())
            {
                foreach(Staff member in matchedStaff)
                {
                    if(dbc
                       .Offices
                       .Where(x => x.OfficeManagerID == member.StaffID)
                       .Any())
                    {
                        matchedOffices
                        .Add(new OfficeDTO(dbc
                                           .Offices
                                           .Where(x => x.OfficeManagerID == member.StaffID)
                                           .FirstOrDefault(),
                                           dbc));
                    }
                }

                if (matchedOffices.Any())
                {
                    return matchedOffices;
                }
                else
                {
                    errors.Add("No offices were found for the staff member submitted.");

                    return errors;
                }
            }
            else
            {
                errors.Add($"No staff members were found with the name '{name}'.");

                return errors;
            }
        }
    }
}