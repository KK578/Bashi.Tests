namespace Bashi.Tests.Framework.Tests.TestObjects
{
    internal sealed record TestInterfaceImplementation : ITestInterface
    {
        public int Number { get; init; }
    }
}
