using FluentAssertions;
using Xunit;

namespace F0.Templates.Example.Tests
{
	public class ObsoleteSampleTests
	{
		[Fact]
		public void CS0612()
		{
			ObsoleteSample sample = new();

			string text = sample.CS0612();

			text.Should().Be("CS0612");
		}

		[Fact]
		public void CS0618()
		{
			ObsoleteSample sample = new();

			string text = sample.CS0618();

			text.Should().Be("CS0618");
		}

#if !DEBUG
		[Fact]
		public void CS0619()
		{
			ObsoleteSample sample = new();

			string text = sample.CS0619();

			text.Should().Be("CS0619");
		}
#endif
	}
}
