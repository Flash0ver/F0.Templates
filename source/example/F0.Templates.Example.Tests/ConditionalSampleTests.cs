using System;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;
#if HAS_ASYNCHRONOUS_DISPOSABLE
using System.Threading.Tasks;
#endif

namespace F0.Templates.Example.Tests
{
	public partial class ConditionalSampleTests
	{
		[Fact]
		public void Dispose()
		{
			ConditionalSample sample = new();

			Action act = () => sample.Dispose();

			act.Should().ThrowExactly<NotImplementedException>();
		}
	}

#if HAS_ASYNCHRONOUS_DISPOSABLE
	public partial class ConditionalSampleTests
	{
		[Fact]
		public void DisposeAsync()
		{
			ConditionalSample sample = new();

			Func<Task> act = () => sample.DisposeAsync().AsTask();

			act.Should().ThrowExactlyAsync<NotImplementedException>();
		}
	}
#endif

	public partial class ConditionalSampleTests
	{
		private readonly ITestOutputHelper output;

		public ConditionalSampleTests(ITestOutputHelper output)
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

			ConditionalSample sample = new();

			sample.Value.Should().Be(value);

			output.WriteLine("Value = {0}", sample.Value);
		}
	}
}
