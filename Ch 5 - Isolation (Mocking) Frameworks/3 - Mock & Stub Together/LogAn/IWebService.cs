﻿
namespace LogAn
{
    public interface IWebService
    {
        void Write(string message);

        void Write(ErrorInfo errorInfo);
    }
}
