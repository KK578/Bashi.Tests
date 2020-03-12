using AutoFixture;

namespace Bashi.Tests.Framework.Data
{
    /// <summary>
    /// <see cref="TestDataBuilder"/> allows for creating instances of complex objects that contain properties exposing interfaces.
    /// This can be achieved by adding implementation types via <see cref="Register{TService,TImplementation}"/>.
    /// </summary>
    public class TestDataBuilder
    {
        private readonly Fixture fixture;

        public TestDataBuilder()
        {
            this.fixture = new Fixture();
        }

        /// <summary>
        /// Registers the type <typeparamref name="TImplementation" /> as the type to construct when
        /// <typeparamref name="TService"/> is to be instantiated.
        /// </summary>
        /// <typeparam name="TService">Interface type to be instantiated.</typeparam>
        /// <typeparam name="TImplementation">Class type to create when <typeparamref name="TService"/> is needed.</typeparam>
        /// <returns>The original <see cref="TestDataBuilder"/> for fluent registrations.</returns>
        public TestDataBuilder Register<TService, TImplementation>()
            where TImplementation : TService
        {
            this.fixture.Register<TService>(() => this.fixture.Create<TImplementation>());
            return this;
        }

        /// <summary>
        /// Creates a new instance of <typeparamref name="T" />, auto populating it's properties with values.
        ///
        /// If <typeparamref name="T"/> contains interfaces, consider using <see cref="TestDataBuilder"/>.
        /// </summary>
        /// <typeparam name="T">Type of be created.</typeparam>
        /// <returns>Instance of <typeparamref name="T"/> auto populated with data.</returns>
        public T Create<T>()
        {
            return this.fixture.Create<T>();
        }
    }
}
