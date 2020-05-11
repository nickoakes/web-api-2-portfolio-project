namespace web_api_2_portfolio_project.UsersModels
{
    public class NoParameterUserResponse
    {
        public string Message { get; set; }
        public string UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Region { get; set; }
        public string SubscriptionType { get; set; }
        public string ActiveSubscription { get; set; }

        public NoParameterUserResponse(string message)
        {
            Message = message;
            UserID = "string (parsable to a GUID), null";
            FirstName = "string, null";
            LastName = "string, null";
            EmailAddress = "string, null";
            Region = "string, null";
            SubscriptionType = "string, null";
            ActiveSubscription = "boolean";
        }
    }
}