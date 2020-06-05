using System;
using System.Linq;
using web_api_2_portfolio_project.OfficeModels;
using web_api_2_portfolio_project.Shared;

namespace web_api_2_portfolio_project.RegionModels
{
    public class RegionDTO
    {
        public Guid RegionID { get; set; }
        public string RegionName { get; set; }
        public OfficeDTO RegionHeadOffice { get; set; }
        public RegionDTO(Region region, DBC dbc)
        {
            RegionID = region.RegionID;
            RegionName = region.RegionName;
            RegionHeadOffice = new OfficeDTO(dbc
                                             .Offices
                                             .Where(x => x.OfficeID == region.RegionHeadOfficeID)
                                             .FirstOrDefault(), dbc);
        }
    }
}