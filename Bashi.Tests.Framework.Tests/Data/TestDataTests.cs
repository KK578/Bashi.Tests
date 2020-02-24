using System;
using System.Collections.Generic;
using System.Linq;
using Bashi.Tests.Framework.Data;
using NUnit.Framework;

namespace Bashi.Tests.Framework.Tests.Data
{
    [TestFixture]
    public class TestDataTests
    {
        private const int RepeatCount = 5;

        private static List<T> Generate<T>(Func<T> generatorFunc)
        {
            return Enumerable.Range(0, RepeatCount)
                             .Select(x => generatorFunc())
                             .Distinct()
                             .ToList();
        }

        [Test]
        public void NextInt_WhenRepeatedCalled_WillReturnDifferentValues()
        {
            Assert.That(Generate(() => TestData.NextInt()), Has.Count.EqualTo(RepeatCount));
        }

        [Test]
        public void WellKnownInt_WhenRepeatedlyCalled_WillReturnTheSameValue()
        {
            Assert.That(Generate(() => TestData.WellKnownInt), Has.Count.EqualTo(1));
        }

        [Test]
        public void NextString_WhenRepeatedlyCalled_WillReturnDifferentValues()
        {
            Assert.That(Generate(() => TestData.NextString()), Has.Count.EqualTo(RepeatCount));
        }

        [Test]
        public void WellKnownString_WhenRepeatedlyCalled_WillReturnTheSameValue()
        {
            Assert.That(Generate(() => TestData.WellKnownString), Has.Count.EqualTo(1));
        }
    }
}
