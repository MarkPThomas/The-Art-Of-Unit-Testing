
namespace LogAn
{
    public class ErrorInfo
    {
        public int Severity { get; private set; }
        public string Message { get; private set; }

        public ErrorInfo(int severity, string message)
        {
            Severity = severity;
            Message = message;
        }

        public override bool Equals(object obj)
        {
            if (obj is ErrorInfo)
            {
                ErrorInfo objCompare = (ErrorInfo)obj;
                if (Severity != objCompare.Severity) { return false; }
                if (string.Compare(Message, objCompare.Message) != 0) { return false; }
                return true;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return (Severity.GetHashCode() ^ Message.GetHashCode());
        }
    }
}
