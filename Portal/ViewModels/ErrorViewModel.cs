namespace Portal.ViewModels
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
        
        public int HttpCode { get; set; }
        
        public string MessageForClient { get; set; }
    }
}