using System;
using Microsoft.Extensions.Logging;

namespace Bashi.Tests.Framework.Logging
{
    /// <summary>
    /// Represents the contents of a log entry written into <see cref="TestableLogger"/>.
    /// </summary>
    public record TestLogEntry
    {
        public LogLevel LogLevel { get; init; }
        public Exception Exception { get; init; }
        public string Message { get; init; }
    }
}
