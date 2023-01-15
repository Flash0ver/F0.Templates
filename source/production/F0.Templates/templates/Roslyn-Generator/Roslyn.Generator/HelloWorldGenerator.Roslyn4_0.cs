#if (Roslyn4_0 || Roslyn4_2)
using System.Collections.Immutable;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

namespace Roslyn.Generator
{
	[Generator(LanguageNames.CSharp)]
	internal sealed partial class HelloWorldGenerator : IIncrementalGenerator
	{
		public void Initialize(IncrementalGeneratorInitializationContext context)
		{
			context.RegisterPostInitializationOutput(PostInitializationCallback);

			IncrementalValueProvider<(ImmutableArray<MethodDeclarationSyntax> Left, Compilation Right)> provider = context.SyntaxProvider
				.CreateSyntaxProvider(SyntaxProviderPredicate, SyntaxProviderTransform)
				.Where(static method => method is not null)
				.Collect()
				.Combine(context.CompilationProvider)!;

			context.RegisterSourceOutput(provider, SourceOutputAction);
		}

		private static void PostInitializationCallback(IncrementalGeneratorPostInitializationContext context)
		{
			context.AddSource("HelloWorldAttribute.g.cs", SourceText.From(helloWorldAttribute, Encoding.UTF8));
		}

		private static void SourceOutputAction(SourceProductionContext context, (ImmutableArray<MethodDeclarationSyntax> Left, Compilation Right) candidates)
		{
			if (candidates.Left.IsEmpty)
			{
				return;
			}

			foreach ((string typeName, string source) in GenerateSourceCode(candidates.Left, candidates.Right, context.CancellationToken))
			{
				context.AddSource($"{typeName}.HelloWorld.g.cs", source);
			}
		}
	}
}
#endif
