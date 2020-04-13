using System;
using Microsoft.Extensions.Logging;

namespace Bashi.Tests.Framework.Logging
{
    public class TestLogEntry
    {
        public TestLogEntry(LogLevel logLevel, Exception exception, string message)
        {
            this.LogLevel = logLevel;
            this.Exception = exception;
            this.Message = message;
        }

        public LogLevel LogLevel { get; }
        public Exception Exception { get; }
        public string Message { get; }
    }
}
