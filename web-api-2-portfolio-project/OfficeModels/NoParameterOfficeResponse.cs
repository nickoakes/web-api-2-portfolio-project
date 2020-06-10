namespace web_api_2_portfolio_project.OfficeModels
{
    public class NoParameterOfficeResponse
    {
        public string Message { get; set; }
        public string OfficeID { get; set; }
        public string OfficeName { get; set; }
        public string OfficeManager { get; set; }
        public NoParameterOfficeResponse(string message)
        {
            Message = message;
            OfficeID = "string (parsable to a GUID), null";
            OfficeName = "string, null";
            OfficeManager = "string (FirstName, LastName or both), null";
        }
    }
}