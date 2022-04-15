#if (MSTest)
using Microsoft.VisualStudio.TestTools.UnitTesting;
#elif (NUnit)
using NUnit.Framework;
#endif
using Roslyn.Generated;
#if (!MSTest && !NUnit)
using Xunit;
#endif

namespace Roslyn.Generator.IntegrationTests
{
#if (MSTest)
	[TestClass]
#elif (NUnit)
	[TestFixture]
#endif
	public class HelloWorldGeneratorIntegrationTests
	{
#if (MSTest)
		[TestMethod]
#elif (NUnit)
		[Test]
#else
		[Fact]
#endif
		public void Generated_HelloWorld()
		{
			string greeting = Greeter.GetHelloWorld();

#if (MSTest)
			Assert.AreEqual("Hello, World!", greeting);
#elif (NUnit)
			Assert.That(greeting, Is.EqualTo("Hello, World!"));
#else
			Assert.Equal("Hello, World!", greeting);
#endif
		}
	}

	internal static partial class Greeter
	{
		[HelloWorld]
		public static partial string GetHelloWorld();
	}
}
