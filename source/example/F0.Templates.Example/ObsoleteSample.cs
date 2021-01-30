using System;

namespace F0.Templates.Example
{
	public sealed class ObsoleteSample
	{
		[Obsolete("Deprecated", false)]
		public string Deprecated()
		{
			return "Deprecated";
		}
	}
}
