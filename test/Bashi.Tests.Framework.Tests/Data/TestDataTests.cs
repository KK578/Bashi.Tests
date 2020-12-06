using System;
using System.Collections.Generic;
using System.Linq;
using Bashi.Tests.Framework.Data;
using Bashi.Tests.Framework.Tests.TestObjects;
using NUnit.Framework;

namespace Bashi.Tests.Framework.Tests.Data
{
    [TestFixture]
    public class TestDataTests
    {
        private const int RepeatCount = 5;

        private static List<T> Generate<T>(Func<T> generatorFunc)
        {
            return Enumerable.Range(0, TestDataTests.RepeatCount)
                             .Select(_ => generatorFunc())
                             .Distinct()
                             .ToList();
        }

        [Test]
        public void NextInt_WhenRepeatedCalled_WillReturnDifferentValues()
        {
            Assert.That(TestDataTests.Generate(TestData.NextInt), Has.Count.EqualTo(TestDataTests.RepeatCount));
        }

        [Test]
        public void WellKnownInt_WhenRepeatedlyCalled_WillReturnTheSameValue()
        {
            Assert.That(TestDataTests.Generate(() => TestData.WellKnownInt), Has.Count.EqualTo(1));
        }

        [Test]
        public void NextString_WhenRepeatedlyCalled_WillReturnDifferentValues()
        {
            Assert.That(TestDataTests.Generate(TestData.NextString), Has.Count.EqualTo(TestDataTests.RepeatCount));
        }

        [Test]
        public void WellKnownString_WhenRepeatedlyCalled_WillReturnTheSameValue()
        {
            Assert.That(TestDataTests.Generate(() => TestData.WellKnownString), Has.Count.EqualTo(1));
        }

        [Test]
        public void Create_GivenAssortedTypes_ReturnsAValidValue()
        {
            Assert.That(TestData.Create<Uri>().ToString(), Contains.Substring("http://"));
            Assert.That(TestData.Create<TestObject>().Numbers, Is.Not.Null.Or.Empty);
        }
    }
}
