using System;

namespace LogAn
{
    public class LogAnalyzer
    {
        private ILogger _logger;
        private IWebService _webService;
        
        public int MinNameLength { get; set; }
        public bool UseInfoObject { get; set; }

        public LogAnalyzer(ILogger logger, IWebService webService)
        {
            _logger = logger;
            _webService = webService;
        }

        public void Analyze(string fileName)
        {
            if (fileName.Length < MinNameLength)
            {
                try
                {
                    _logger.LogError("Filename too short: " + fileName);
                }
                catch (Exception e)
                {
                    if (UseInfoObject)
                    {
                        _webService.Write(new ErrorInfo(1000, e.Message));
                    }
                    else
                    {
                        _webService.Write("Error From Logger: " + e);
                    }
                }
            }
        }
    }
}
