using System;
using FluentAssertions;
using FluentAssertions.Primitives;
using Xunit;

namespace F0.Templates.Example.Tests
{
	public class PackageVersionTests
	{
		[Fact]
		public void CentralPackageVersionManagement()
		{
			typeof(FactAttribute).Assembly.GetName().Version.Should().Be(new Version(2, 4, 1, 0));
			typeof(BooleanAssertions).Assembly.GetName().Version.Should().Be(new Version(5, 10, 3, 0));
		}
	}
}
