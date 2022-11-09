#if (Roslyn3_8 || Roslyn3_9)
using System.Diagnostics;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace Roslyn.Generator
{
#if (Roslyn3_8)
	[Generator]
#else
	[Generator(LanguageNames.CSharp)]
#endif
	internal sealed partial class HelloWorldGenerator : ISourceGenerator
	{
		public void Initialize(GeneratorInitializationContext context)
		{
#if (!Roslyn3_8)
			context.RegisterForPostInitialization(PostInitializationCallback);
#endif
			context.RegisterForSyntaxNotifications(HelloWorldReceiver.Create);
		}

		public void Execute(GeneratorExecutionContext context)
		{
#if (Roslyn3_8)
			context.AddSource("HelloWorldAttribute.g.cs", SourceText.From(helloWorldAttribute, Encoding.UTF8));

#endif
#if (Roslyn3_8)
			if (context.SyntaxReceiver is not HelloWorldReceiver receiver || receiver.CandidateMethods is null)
#else
			if (context.SyntaxContextReceiver is not HelloWorldReceiver receiver || receiver.CandidateMethods is null)
#endif
			{
				return;
			}

			Debug.Assert(receiver.CandidateMethods.Count > 0);

			foreach ((string typeName, string source) in GenerateSourceCode(receiver.CandidateMethods, context.Compilation, context.CancellationToken))
			{
				context.AddSource($"{typeName}.HelloWorld.g.cs", source);
			}
		}
#if (!Roslyn3_8)

		private static void PostInitializationCallback(GeneratorPostInitializationContext context)
		{
			context.AddSource("HelloWorldAttribute.g.cs", SourceText.From(helloWorldAttribute, Encoding.UTF8));
		}
#endif
	}
}
#endif
