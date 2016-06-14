using System;

namespace LogAn
{
    public class LogAnalyzer
    {
        public ILogger _logger { get; set; }
        public int MinNameLength { get; set; } = 8;

        public LogAnalyzer(ILogger logger)
        {
            _logger = logger;
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
                    throw e;
                }
            }
        }
    }
}
