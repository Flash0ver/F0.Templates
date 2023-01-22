#if (Roslyn3_8 || Roslyn3_9)
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
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

#if (Roslyn3_8)
			internal List<MethodDeclarationSyntax>? CandidateMethods { get; private set; }
#else
			internal List<(MethodDeclarationSyntax node, IMethodSymbol symbol)>? CandidateMethods { get; private set; }
#endif

#if (Roslyn3_8)
			public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
#else
			public void OnVisitSyntaxNode(GeneratorSyntaxContext context)
#endif
			{
#if (Roslyn3_8)
				if (syntaxNode is MethodDeclarationSyntax method
					&& IsCandidateMethod(method))
				{
					CandidateMethods ??= new List<MethodDeclarationSyntax>();
					CandidateMethods.Add(method);
				}
#else
				if (context.Node is MethodDeclarationSyntax method
					&& IsCandidateMethod(method))
				{
					IMethodSymbol? methodSymbol = context.SemanticModel.GetDeclaredSymbol(method, CancellationToken.None);

					if (methodSymbol is not null
						&& methodSymbol.ReturnType.SpecialType == SpecialType.System_String
						&& HasHelloWorldAttribute(method, context.SemanticModel, CancellationToken.None))
					{
						CandidateMethods ??= new List<(MethodDeclarationSyntax node, IMethodSymbol symbol)>();
						CandidateMethods.Add((method, methodSymbol));
					}
				}
#endif
			}

			private static bool IsCandidateMethod(MethodDeclarationSyntax method)
			{
				return method is
					{
						AttributeLists.Count: > 0,
						ParameterList.Parameters.Count: 0,
					}
					&& method.Modifiers.Any(SyntaxKind.PartialKeyword);
			}
		}

#if (Roslyn3_8)
		private static bool HasHelloWorldAttribute(MethodDeclarationSyntax method)
		{
			foreach (AttributeListSyntax attributeList in method.AttributeLists)
			{
				foreach (AttributeSyntax attribute in attributeList.Attributes)
				{
					IdentifierNameSyntax? name = attribute.Name switch
					{
						QualifiedNameSyntax { Right: IdentifierNameSyntax right } => right,
						IdentifierNameSyntax identifier => identifier,
						_ => null,
					};

					if (name is not null
						&& IsHelloWorldAttribute(name))
					{
						return true;
					}
				}
			}

			return false;

			static bool IsHelloWorldAttribute(IdentifierNameSyntax name)
			{
				return name.Identifier.ValueText.EndsWith("HelloWorld", StringComparison.Ordinal)
					|| name.Identifier.ValueText.EndsWith("HelloWorldAttribute", StringComparison.Ordinal);
			}
		}
#else
		private static bool HasHelloWorldAttribute(MethodDeclarationSyntax method, SemanticModel semanticModel, CancellationToken cancellationToken)
		{
			const string helloWorldAttributeName = "Roslyn.Generated.HelloWorldAttribute";

			foreach (AttributeListSyntax attributeList in method.AttributeLists)
			{
				foreach (AttributeSyntax attribute in attributeList.Attributes)
				{
					if (semanticModel.GetSymbolInfo(attribute, cancellationToken).Symbol is IMethodSymbol attributeSymbol)
					{
						string fullName = attributeSymbol.ContainingType.ToDisplayString();

						if (fullName.Equals(helloWorldAttributeName, StringComparison.Ordinal))
						{
							return true;
						}
					}
				}
			}

			return false;
		}
#endif
	}
}
#endif
