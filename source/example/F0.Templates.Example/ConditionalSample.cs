using System;
using System.Diagnostics;
#if HAS_ASYNCHRONOUS_DISPOSABLE
using System.Threading.Tasks;
#endif

namespace F0.Templates.Example
{
	public sealed partial class ConditionalSample : IDisposable
	{
		public void Dispose()
		{
			throw new NotImplementedException();
		}
	}

#if HAS_ASYNCHRONOUS_DISPOSABLE
	public sealed partial class ConditionalSample : IAsyncDisposable
	{
		public ValueTask DisposeAsync()
		{
			throw new NotImplementedException();
		}
	}
#endif

	public sealed partial class ConditionalSample
	{
		public int Value { get; private set; }

		public ConditionalSample()
		{
			Value = 1;
			ConditionalIncrement();
		}

		[Conditional("HAS_ASYNCHRONOUS_DISPOSABLE")]
		private void ConditionalIncrement()
		{
			Value++;
		}
	}
}
