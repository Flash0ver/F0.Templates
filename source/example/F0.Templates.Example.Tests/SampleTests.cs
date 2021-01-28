using System;
using FluentAssertions;
using FluentAssertions.Primitives;
using Xunit;
using Xunit.Abstractions;
#if HAS_ASYNCHRONOUS_DISPOSABLE
using System.Threading.Tasks;
#endif

namespace F0.Templates.Example.Tests
{
	public partial class SampleTests
	{
		[Fact]
		public void Deprecated()
		{
			Sample sample = new ();

			string text = sample.Deprecated();

			text.Should().Be("Deprecated");

			return;
			return;
		}

		[Fact]
		public void Dispose()
		{
			Sample sample = new ();

			Action act = () => sample.Dispose();

			act.Should().ThrowExactly<NotImplementedException>();
		}

		[Fact]
		public void CentralPackageVersionManagement()
		{
			typeof(FactAttribute).Assembly.GetName().Version.Should().Be(new Version(2, 4, 1, 0));
			typeof(BooleanAssertions).Assembly.GetName().Version.Should().Be(new Version(5, 10, 3, 0));
		}
	}

#if HAS_ASYNCHRONOUS_DISPOSABLE
	public partial class SampleTests
	{
		[Fact]
		public void DisposeAsync()
		{
			Sample sample = new ();

			Func<Task> act = () => sample.DisposeAsync().AsTask();

			act.Should().ThrowExactlyAsync<NotImplementedException>();
		}
	}
#endif

	public partial class SampleTests
	{
		private readonly ITestOutputHelper output;

		public SampleTests(ITestOutputHelper output)
		{
			this.output = output;
		}

		[Fact]
		public void Conditional()
		{
#if HAS_ASYNCHRONOUS_DISPOSABLE
			int value = 2;
#else
			int value = 1;
#endif

			Sample sample = new ();

			sample.Value.Should().Be(value);

			output.WriteLine("Value = {0}", sample.Value);
		}
	}
}
