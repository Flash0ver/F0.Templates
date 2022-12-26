using System.Reflection;

namespace Roslyn.Generator
{
	internal partial class HelloWorldGenerator
	{
		private static readonly AssemblyName assemblyName = typeof(HelloWorldGenerator).Assembly.GetName();
		private static readonly string generatedCodeAttribute = $@"global::System.CodeDom.Compiler.GeneratedCodeAttribute(""{assemblyName.Name}"", ""{assemblyName.Version}"")";

		private static readonly string helloWorldAttribute = $@"// <auto-generated/>
#nullable enable

namespace Roslyn.Generated
{{
	[{generatedCodeAttribute}]
	[global::System.AttributeUsage(global::System.AttributeTargets.Method, AllowMultiple = false)]
	internal sealed class HelloWorldAttribute : global::System.Attribute
	{{
	}}
}}
";
	}
}