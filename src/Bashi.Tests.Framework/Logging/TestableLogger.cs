using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using Microsoft.Extensions.Logging;

namespace Bashi.Tests.Framework.Logging
{
    /// <inheritdoc cref="Bashi.Tests.Framework.Logging.TestableLogger" />
    public class TestableLogger<T> : TestableLogger, ILogger<T>
    {
    }

    /// <summary>
    /// Represents an <see cref="ILogger"/> where logs are stored to an in-memory collection for asserting against.
    /// </summary>
    public class TestableLogger : ILogger
    {
        private readonly List<TestLogEntry> logs = new();

        /// <summary>
        /// Gets a readonly copy of all log entries written into the logger.
        /// </summary>
        public IReadOnlyList<TestLogEntry> LogEntries => this.logs.AsReadOnly();

        /// <inheritdoc />
        public void Log<TState>(LogLevel logLevel,
                                EventId eventId,
                                TState state,
                                Exception exception,
                                Func<TState, Exception, string> formatter)
        {
            this.logs.Add(new TestLogEntry
            {
                LogLevel = logLevel,
                Exception = exception,
                Message = formatter(state, exception)
            });
        }

        /// <inheritdoc />
        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        /// <inheritdoc />
        public IDisposable BeginScope<TState>(TState state)
        {
            return Disposable.Empty;
        }
    }
}
