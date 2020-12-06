using System;
using Bashi.Core.Enums;
using Bashi.Tests.Framework.Data;
using Bashi.Tests.Framework.Logging;
using Microsoft.Extensions.Logging;
using NUnit.Framework;

namespace Bashi.Tests.Framework.Tests.Logging
{
    [TestFixture]
    public class TestableLoggerTests
    {
        [Test]
        [TestCase(LogLevel.Critical, "Critical error occurred.")]
        [TestCase(LogLevel.Debug, "Additional information.")]
        [TestCase(LogLevel.Error, "An error occurred.")]
        [TestCase(LogLevel.Information, "Finished test.")]
        [TestCase(LogLevel.Trace, "Starting the test.")]
        [TestCase(LogLevel.Warning, "Test results inconclusive.")]
        public void Log_GivenLogEntries_ThenAllAreSavedInOutput(LogLevel logLevel, string expected)
        {
            var subject = new TestableLogger();
            switch (logLevel)
            {
                case LogLevel.Critical:
                    subject.LogCritical("Critical error occurred.");
                    break;
                case LogLevel.Trace:
                    subject.LogTrace("Starting the test.");
                    break;
                case LogLevel.Debug:
                    subject.LogDebug("Additional information.");
                    break;
                case LogLevel.Information:
                    subject.LogInformation("Finished test.");
                    break;
                case LogLevel.Warning:
                    subject.LogWarning("Test results inconclusive.");
                    break;
                case LogLevel.Error:
                    subject.LogError("An error occurred.");
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(logLevel), logLevel, null);
            }

            Assert.That(subject.LogEntries.Count, Is.EqualTo(1));
            Assert.That(subject.LogEntries[0].LogLevel, Is.EqualTo(logLevel));
            Assert.That(subject.LogEntries[0].Message, Is.EqualTo(expected));
        }

        [Test]
        public void Log_GivenFormattedMessage_ThenMessageShouldBeFormatted()
        {
            var subject = new TestableLogger();
            const string name = "Fred";
            subject.LogInformation("My name is {Name}.", name);

            Assert.That(subject.LogEntries[0].Message, Is.EqualTo("My name is Fred."));
        }

        [Test]
        public void Log_GivenErrorException_ThenExceptionIsSet()
        {
            var subject = new TestableLogger();
            var exception = new Exception(TestData.WellKnownString);
            subject.LogError(exception, "An error occurred!");

            Assert.That(subject.LogEntries[0].Exception, Is.EqualTo(exception));
        }

        [Test]
        public void IsEnabled_ReturnsTrue()
        {
            var subject = new TestableLogger();
            foreach (var logLevel in EnumUtil.GetValues<LogLevel>())
            {
                Assert.That(subject.IsEnabled(logLevel), Is.True);
            }
        }

        [Test]
        public void BeginScope_ReturnsAWorkingDisposable()
        {
            var subject = new TestableLogger();
            var scope = subject.BeginScope("");
            Assert.That(scope.Dispose, Throws.Nothing);
        }
    }
}
