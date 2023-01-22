#if (Roslyn3_8 || Roslyn3_9)
using System.Diagnostics;
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

		private static bool DoesReturnString(MethodDeclarationSyntax method, SemanticModel semanticModel, CancellationToken cancellationToken)
		{
			IMethodSymbol? methodSymbol = semanticModel.GetDeclaredSymbol(method, cancellationToken);

			if (methodSymbol is null)
			{
				return false;
			}

#if (Roslyn3_8 || Roslyn3_9)
			Debug.Assert(methodSymbol.Parameters.IsEmpty);
#else
			Debug.Assert(methodSymbol.IsPartialDefinition);
#endif

			return methodSymbol.ReturnType.SpecialType == SpecialType.System_String;
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
