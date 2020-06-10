namespace web_api_2_portfolio_project.RegionModels
{
    public class NoParameterRegionResponse
    {
        public string Message { get; set; }
        public string RegionID { get; set; }
        public string RegionName { get; set; }
        public string HeadOffice { get; set; }
        public NoParameterRegionResponse(string message)
        {
            Message = message;
            RegionID = "string (parsable to a GUID), null";
            RegionName = "string, null";
            HeadOffice = "string (Head Office name), null";
        }
    }
}