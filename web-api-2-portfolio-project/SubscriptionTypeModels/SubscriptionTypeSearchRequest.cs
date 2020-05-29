namespace web_api_2_portfolio_project.SubscriptionTypeModels
{
    public class SubscriptionTypeSearchRequest
    {
        public string SubscriptionID { get; set; }
        public string SubscriptionName { get; set; }
        public string SubscriptionMonthlyFeeMin { get; set; }
        public string SubscriptionMonthlyFeeMax { get; set; }
    }
}