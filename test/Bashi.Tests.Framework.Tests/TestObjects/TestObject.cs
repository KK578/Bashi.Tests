using System.Collections.Generic;

namespace Bashi.Tests.Framework.Tests.TestObjects
{
    internal sealed record TestObject
    {
        public List<int> Numbers { get; init; }
    }
}
