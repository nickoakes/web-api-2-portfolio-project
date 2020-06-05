using System;
using System.Linq;
using web_api_2_portfolio_project.Shared;
using web_api_2_portfolio_project.StaffModels;

namespace web_api_2_portfolio_project.OfficeModels
{
    public class OfficeDTO
    {
        public Guid OfficeID { get; set; }
        public string OfficeName { get; set; }
        public StaffDTO OfficeManager { get; set; }
        public OfficeDTO(Office office, DBC dbc)
        {
            OfficeID = office.OfficeID;
            OfficeName = office.OfficeName;
            OfficeManager = new StaffDTO(dbc
                                         .Staff
                                         .Where(x => x.StaffID == office.OfficeManagerID)
                                         .FirstOrDefault(), dbc);
        }
    }
}