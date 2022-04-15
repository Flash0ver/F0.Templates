# Roslyn Generator

Source Code: [Roslyn-Generator](../../source/production/F0.Templates/templates/Roslyn-Generator)

|               |                           |
|---------------|---------------------------|
| Template Name | Roslyn Generator solution |
| Short Name    | `roslyngenerator`         |
| Language      | [C#]                      |
| Tags          | Roslyn/Generator          |
| Type          | solution                  |
| Applies to    | [0.4.0,)                  |

## Description

Creates a Roslyn Generator solution.

## Template Options

- `-f|--framework`\
(Hidden) .NET analyzers, such as generators, must always target _.NET Standard 2.0_.
This multitarget framework for the generator project is used to include the nullable annotations of the BCL.
- `-r|--roslyn`\
The version of Roslyn to use.
Greater versions of Roslyn (i.e. the _Microsoft.CodeAnalysis[.*]_ packages) require consuming projects to be built with greater versions of the .NET SDK.
  - `3.8`
    - Uses Roslyn 3.8.0
    - Produces an [ISourceGenerator][isourcegenerator] with an [ISyntaxReceiver][isyntaxreceiver]
    - Requires .NET SDK 5.0.100
  - `3.9`
    - Uses Roslyn 3.9.0
    - Produces an [ISourceGenerator][isourcegenerator] with an [ISyntaxContextReceiver][isyntaxcontextreceiver] and registers **PostInitialization**
    - Requires .NET SDK 5.0.200
  - `4.0` (default)
    - Roslyn 4.0.1
    - Produces an [IIncrementalGenerator][iincrementalgenerator] and registers **PostInitialization**
    - Requires .NET SDK 6.0.100
- `-tf|--testing-framework`\
The unit testing framework to use.
  - `MSTest` (default)
    - Uses [MSTest V2][testfx]
  - `NUnit`
    - Uses [NUnit 3][nunit]
  - `xUnit`
    - Use [xUnit.net v2][xunit]
- `no-restore`\
Disables implicit restore.
[dotnet restore][dotnet-restore] explicitly restores the dependencies of the projects.

## Usage Examples

- Print out help for the template:\
`dotnet new roslyngenerator --help`
- Create a Roslyn Generator solution, based on Roslyn 4.0.1, using MSTest, and restoring the dependencies of the projects:\
`dotnet new roslyngenerator`
- Create a Roslyn Generator solution, based on Roslyn 3.8.0, using NUnit, without restoring the dependencies of the projects:\
`dotnet new roslyngenerator --roslyn 3.8 --testing-framework NUnit --no-restore`

## Third-Party Notices

See [Roslyn-Generator.NOTICE.md](./Roslyn-Generator.NOTICE.md).

## See also

- [Source Generators](https://docs.microsoft.com/dotnet/csharp/roslyn-sdk/source-generators-overview)
- [Source Generators Cookbook](https://github.com/dotnet/roslyn/blob/main/docs/features/source-generators.cookbook.md)

## History

- [0.4.0](../../CHANGELOG.md#v040-2022-04-15)

[isourcegenerator]: https://docs.microsoft.com/dotnet/api/microsoft.codeanalysis.isourcegenerator
[isyntaxreceiver]: https://docs.microsoft.com/dotnet/api/microsoft.codeanalysis.isyntaxreceiver
[isyntaxcontextreceiver]: https://docs.microsoft.com/dotnet/api/microsoft.codeanalysis.isyntaxcontextreceiver
[iincrementalgenerator]: https://docs.microsoft.com/dotnet/api/microsoft.codeanalysis.iincrementalgenerator
[testfx]: https://github.com/microsoft/testfx
[nunit]: https://github.com/nunit/nunit
[xunit]: https://github.com/xunit/xunit
[dotnet-restore]: https://docs.microsoft.com/dotnet/core/tools/dotnet-restore
