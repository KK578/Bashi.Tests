namespace Bashi.Tests.Framework.Tests.TestObjects
{
    internal sealed record NestingTestObject
    {
        public TestObject Object { get; init; }
    }
}
