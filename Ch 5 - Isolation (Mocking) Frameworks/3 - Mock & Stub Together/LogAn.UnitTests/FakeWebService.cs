
namespace LogAn.UnitTests
{
    /// <summary>
    /// Fake web service that is used as a mock.
    /// </summary>
    public class FakeWebService : IWebService
    {
        public string MessageToWebService;
        public ErrorInfo ErrorInfo;

        public void Write(string message)
        {
            MessageToWebService = message;
        }


        public void Write(ErrorInfo errorInfo)
        {
            ErrorInfo = errorInfo;
        }
    }
}
