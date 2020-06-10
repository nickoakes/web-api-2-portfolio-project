namespace web_api_2_portfolio_project.SubscriptionTypeModels
{
    public class NoParameterSubscriptionTypeResponse
    {
        public string Message { get; set; }
        public string SubscriptionID { get; set; }
        public string SubscriptionName { get; set; }
        public string SubscriptionMonthlyFeeMin { get; set; }
        public string SubscriptionMonthlyFeeMax { get; set; }
        public NoParameterSubscriptionTypeResponse(string message)
        {
            Message = message;
            SubscriptionID = "string (parsable to a GUID), null";
            SubscriptionName = "string, null";
            SubscriptionMonthlyFeeMin = "string (parsable to a double), null";
            SubscriptionMonthlyFeeMax = "string (parsable to a double), null";
        }
    }
}