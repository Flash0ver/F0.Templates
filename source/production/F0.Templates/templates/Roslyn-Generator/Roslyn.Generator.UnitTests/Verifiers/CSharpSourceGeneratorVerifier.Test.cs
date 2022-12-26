using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Testing;
#if (!Roslyn3_8 && !Roslyn3_9)
using Microsoft.CodeAnalysis.Testing;
#endif
using Microsoft.CodeAnalysis.Testing.Verifiers;

namespace Roslyn.Generator.UnitTests.Verifiers
{
	internal static partial class CSharpSourceGeneratorVerifier<TSourceGenerator>
#if (Roslyn3_8 || Roslyn3_9)
		where TSourceGenerator : ISourceGenerator, new()
#else
		where TSourceGenerator : IIncrementalGenerator, new()
#endif
	{
#if (Roslyn3_8 || Roslyn3_9)
#if (MSTest)
		public sealed class Test : CSharpSourceGeneratorTest<TSourceGenerator, MSTestVerifier>
#elif (NUnit)
		public sealed class Test : CSharpSourceGeneratorTest<TSourceGenerator, NUnitVerifier>
#else
		public sealed class Test : CSharpSourceGeneratorTest<TSourceGenerator, XUnitVerifier>
#endif
#else
#if (MSTest)
		public sealed class Test : CSharpSourceGeneratorTest<EmptySourceGeneratorProvider, MSTestVerifier>
#elif (NUnit)
		public sealed class Test : CSharpSourceGeneratorTest<EmptySourceGeneratorProvider, NUnitVerifier>
#else
		public sealed class Test : CSharpSourceGeneratorTest<EmptySourceGeneratorProvider, XUnitVerifier>
#endif
#endif
		{
			public Test()
			{
			}

			public LanguageVersion LanguageVersion { get; set; } = LanguageVersion.Default;

#if (!Roslyn3_8 && !Roslyn3_9)
			protected override IEnumerable<ISourceGenerator> GetSourceGenerators()
			{
				return new[] { new TSourceGenerator().AsSourceGenerator() };
			}

#endif
			protected override CompilationOptions CreateCompilationOptions()
			{
				CompilationOptions compilationOptions = base.CreateCompilationOptions();
				return compilationOptions.WithSpecificDiagnosticOptions(
					 compilationOptions.SpecificDiagnosticOptions.SetItems(CSharpVerifierHelper.NullableWarnings));
			}

			protected override ParseOptions CreateParseOptions()
			{
				var parseOptions = (CSharpParseOptions)base.CreateParseOptions();
				return parseOptions.WithLanguageVersion(LanguageVersion);
			}
		}
	}
}
