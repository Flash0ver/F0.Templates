using System;

namespace F0.Templates.Example
{
	public sealed class ObsoleteSample
	{
		[Obsolete]
		public string CS0612()
		{
			return "CS0612";
		}

		[Obsolete("Warning")]
		public string CS0618()
		{
			return "CS0618";
		}

		[Obsolete("Error", true)]
		public string CS0619()
		{
			return "CS0619";
		}
	}
}
