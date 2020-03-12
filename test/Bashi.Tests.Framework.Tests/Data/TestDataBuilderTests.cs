using Bashi.Tests.Framework.Data;
using Bashi.Tests.Framework.Tests.TestObjects;
using NUnit.Framework;

namespace Bashi.Tests.Framework.Tests.Data
{
    [TestFixture]
    public class TestDataBuilderTests
    {
        [Test]
        public void Build_GivenSimpleTestObject_ShouldConstructSuccessfully()
        {
            var subject = new TestDataBuilder().Create<TestObject>();
            Assert.That(subject.Numbers, Is.Not.Null.Or.Empty);
        }

        [Test]
        public void Build_GivenNestedObject_ShouldConstructSuccessfully()
        {
            var subject = new TestDataBuilder().Create<NestingTestObject>();
            Assert.That(subject.Object.Numbers, Is.Not.Null.Or.Empty);
        }

        [Test]
        public void Build_GivenInterface_WhenImplementationIsRegistered_ShouldConstructSuccessfully()
        {
            var subject = new TestDataBuilder().Register<ITestInterface, TestInterfaceImplementation>()
                                               .Create<ITestInterface>();
            Assert.That(subject, Is.TypeOf<TestInterfaceImplementation>());
            Assert.That(subject.Number, Is.Not.EqualTo(0));
        }
    }
}
