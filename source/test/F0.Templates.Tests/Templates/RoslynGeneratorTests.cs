using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Boxed.DotnetNewTest;
using Xunit;

namespace F0.Tests.Templates
{
	public class RoslynGeneratorTests : IAsyncLifetime
	{
		private const string templateName = "roslyngenerator";

		public Task InitializeAsync()
		{
			return DotnetNew.InstallAsync<RoslynGeneratorTests>("F0.Templates.sln");
		}

		public Task DisposeAsync()
		{
			return DotnetNew.UninstallAsync<RoslynGeneratorTests>("F0.Templates.sln");
		}

		[Theory]
		[InlineData("Default")]
		[InlineData("Roslyn3_8_MSTest", "roslyn=3.8", "testing-framework=mstest", "no-restore=false")]
		[InlineData("Roslyn3_9_NUnit", "roslyn=3.9", "testing-framework=nunit", "no-restore=false")]
		[InlineData("Roslyn4_0_xUnit", "roslyn=4.0", "testing-framework=xunit", "no-restore=false")]
		[InlineData("Roslyn4_2_MetadataReferencesProvider", "roslyn=4.2")]
		public async Task DotnetNew_Async(string projectName, params string[] arguments)
		{
			await using (var tempDirectory = TempDirectory.NewTempDirectory())
			{
				IDictionary<string, string> dictionary = ToArguments(arguments);

				Project project = await tempDirectory.DotnetNewAsync(templateName, projectName, dictionary);

				await project.DotnetRestoreAsync();
				await project.DotnetBuildAsync();
				await project.DotnetTestAsync();
			}
		}

		private static IDictionary<string, string> ToArguments(string[] arguments)
		{
			return arguments
				.Select(x => x.Split('=', StringSplitOptions.RemoveEmptyEntries))
				.ToDictionary(x => x.First(), x => x.Last());
		}
	}
}
