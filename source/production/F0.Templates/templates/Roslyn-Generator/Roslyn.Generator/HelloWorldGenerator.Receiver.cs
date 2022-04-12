#if (Roslyn3_8 || Roslyn3_9)
using Microsoft.CodeAnalysis;
#if (Roslyn3_8)
using Microsoft.CodeAnalysis.CSharp;
#endif
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Roslyn.Generator
{
	internal partial class HelloWorldGenerator
	{
#if (Roslyn3_8)
		private sealed class HelloWorldReceiver : ISyntaxReceiver
#else
		private sealed class HelloWorldReceiver : ISyntaxContextReceiver
#endif
		{
#if (Roslyn3_8)
			internal static ISyntaxReceiver Create()
#else
			internal static ISyntaxContextReceiver Create()
#endif
			{
				return new HelloWorldReceiver();
			}

			internal List<MethodDeclarationSyntax>? CandidateMethods { get; private set; }

#if (Roslyn3_8)
			public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
#else
			public void OnVisitSyntaxNode(GeneratorSyntaxContext context)
#endif
			{
#if (Roslyn3_8)
				if (syntaxNode is MethodDeclarationSyntax method
					&& IsCandidateMethod(method))
#else
				if (context.Node is MethodDeclarationSyntax method
					&& IsCandidateMethod(method)
					&& DoesReturnString(method, context.SemanticModel, CancellationToken.None)
					&& HasHelloWorldAttribute(method, context.SemanticModel, CancellationToken.None))
#endif
				{
					CandidateMethods ??= new List<MethodDeclarationSyntax>();
					CandidateMethods.Add(method);
				}
			}
		}
	}
}
#endif
