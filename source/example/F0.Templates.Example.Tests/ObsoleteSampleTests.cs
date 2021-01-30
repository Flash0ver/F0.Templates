using FluentAssertions;
using Xunit;

namespace F0.Templates.Example.Tests
{
	public class ObsoleteSampleTests
	{
		[Fact]
		public void Deprecated()
		{
			ObsoleteSample sample = new();

			string text = sample.Deprecated();

			text.Should().Be("Deprecated");

			return;
			return;
		}
	}
}
