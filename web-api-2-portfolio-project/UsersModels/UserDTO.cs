using System;
using System.Linq;
using web_api_2_portfolio_project.RegionModels;
using web_api_2_portfolio_project.Shared;

namespace web_api_2_portfolio_project.UsersModels
{
    public class UserDTO
    {
        public Guid UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public RegionDTO Region { get; set; }
        public SubscriptionType SubscriptionType { get; set; }
        public DateTime SubscriptionStartDate { get; set; }
        public DateTime? SubscriptionEndDate { get; set; }
        public UserDTO(User user, DBC dbc)
        {
            UserID = user.UserID;
            FirstName = user.FirstName;
            LastName = user.LastName;
            EmailAddress = user.EmailAddress;
            Region = new RegionDTO(dbc
                                   .Regions
                                   .Where(x => x.RegionID == user.RegionID)
                                   .FirstOrDefault(), dbc);
            SubscriptionType = dbc
                               .SubscriptionTypes
                               .Where(x => x.SubscriptionID == user.SubscriptionID)
                               .FirstOrDefault();
            SubscriptionStartDate = user.SubscriptionStartDate;
            SubscriptionEndDate = user.SubscriptionEndDate;
        }
    }
}