namespace Recruitment_Software_Project.Models.Common
{
    public class Response
    {
        public int StatusCode { get; set; }
        public string ResponseMessage { get; set; }
        public object ResultData { get; set; }
    }
}
