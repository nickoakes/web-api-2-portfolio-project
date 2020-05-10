namespace web_api_2_portfolio_project.UsersModels
{
    public class UsersSearchRequest
    {
        public string UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Region { get; set; }
        public string SubscriptionType { get; set; }
        public bool ActiveSubscription { get; set; }
    }
}