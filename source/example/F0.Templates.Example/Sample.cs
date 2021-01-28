using System;
using System.Diagnostics;
#if HAS_ASYNCHRONOUS_DISPOSABLE
using System.Threading.Tasks;
#endif

namespace F0.Templates.Example
{
	public sealed partial class Sample : IDisposable
	{
		[Obsolete("Deprecated", false)]
		public string Deprecated()
		{
			return "Deprecated";
		}

		public void Dispose()
		{
			throw new NotImplementedException();
		}
	}

#if HAS_ASYNCHRONOUS_DISPOSABLE
	public sealed partial class Sample : IAsyncDisposable
	{
		public ValueTask DisposeAsync()
		{
			throw new NotImplementedException();
		}
	}
#endif

	public sealed partial class Sample
	{
		public int Value { get; private set; }

		public Sample()
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
