using AutoFixture;

namespace Bashi.Tests.Framework.Data
{
    /// <summary>
    /// <see cref="TestData"/> provides helper methods for easily creating data objects automatically populated with
    /// non-default data. This generally creates random data each time.
    ///
    /// Use the "WellKnown" properties, to get a value that will not change during the course of the assembly lifetime.
    /// Use the "Next" methods, to get a fresh random value each time.
    /// </summary>
    public static class TestData
    {
        private static readonly Fixture Fixture = new Fixture();

        static TestData()
        {
            TestData.WellKnownInt = TestData.NextInt();
            TestData.WellKnownString = TestData.NextString();
        }

        /// <summary>
        /// Gets a random, but consistent for the assembly lifetime, integer value.
        /// </summary>
        public static int WellKnownInt { get; }

        /// <summary>
        /// Gets a random, but consisten for the assembly lifetime, string value.
        /// </summary>
        public static string WellKnownString { get; }

        /// <summary>
        /// Creates a fresh pseudo-random integer value.
        /// </summary>
        /// <returns>New integer value.</returns>
        public static int NextInt() => TestData.Create<int>();

        /// <summary>
        /// Creates a fresh pseudo-random string value, normally formed as a guid.
        /// </summary>
        /// <returns>New string value.</returns>
        public static string NextString() => TestData.Create<string>();

        /// <summary>
        /// Creates a new instance of <typeparamref name="T" />, auto populating it's properties with values.
        ///
        /// If <typeparamref name="T"/> contains interfaces, consider using <see cref="TestDataBuilder"/>.
        /// </summary>
        /// <typeparam name="T">Type of be created.</typeparam>
        /// <returns>Instance of <typeparamref name="T"/> auto populated with data.</returns>
        public static T Create<T>()
        {
            return Fixture.Create<T>();
        }
    }
}
