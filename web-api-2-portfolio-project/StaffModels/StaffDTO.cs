using System;
using System.Linq;
using web_api_2_portfolio_project.Shared;

namespace web_api_2_portfolio_project.StaffModels
{
    public class StaffDTO
    {
        public Guid StaffID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Role Role { get; set; }
        public StaffDTO(Staff staff, DBC dbc)
        {
            StaffID = staff.StaffID;
            FirstName = staff.FirstName;
            LastName = staff.LastName;

            Guid staffRoleID = Guid.Parse(staff.RoleID);

            Role = dbc
                   .Roles
                   .Where(x => x.RoleID == staffRoleID)
                   .FirstOrDefault();
        }
    }
}