# Directory.Build.targets

Source Code: [Directory-Build-targets](../../source/production/F0.Templates/templates/Directory-Build-targets)

|               |                              |
|---------------|------------------------------|
| Template Name | Directory.Build.targets file |
| Short Name    | `directory.build.targets`    |
| Language      |                              |
| Tags          | Config/MSBuild               |
| Type          | item                         |
| Applies to    | [0.1.0,)                     |

## Description

Creates a Directory.Build.targets file.

## Template Options

- `-e|--empty`\
Creates an empty file, which stops MSBuild from further scanning for more Directory.Build.targets.
Available since [v0.3.0][0.3.0].
- `-mlm|--multi-level-merge`\
Makes MSBuild continue scanning the directory structure upward for the next Directory.Build.targets and merges it into this file.
Available since [v0.3.0][0.3.0].
- `-dc|--define-constants`\
(Hidden) Defines a conditional compilation symbol.
Available since [v0.3.0][0.3.0].\
Includes HAS_ASYNCHRONOUS_DISPOSABLE in the generated template, defined when the 'TargetFramework' supports the [IAsyncDisposable Interface][iasyncdisposable].
For more information, see [preprocessor directives][preprocessor-if].

## Usage Examples

- Print out help for the template:\
`dotnet new directory.build.targets --help`
- Create a common _Directory.Build.targets_ file:\
`dotnet new directory.build.targets`
- Create an empty file, which stops MSBuild from further scanning for more _Directory.Build.targets_:\
`dotnet new directory.build.targets --empty`
- Include an _Import_ element to find and merge the next _Directory.Build.targets_ upward in the directory structure:\
`dotnet new directory.build.targets --multi-level-merge`

## See also

- [Customize your build](https://docs.microsoft.com/visualstudio/msbuild/customize-your-build#directorybuildprops-and-directorybuildtargets)

## History

- [0.3.0][0.3.0]
- [0.1.0](../../CHANGELOG.md#v010-2021-01-14)

[0.3.0]: ../../CHANGELOG.md#v030-2021-01-28
[iasyncdisposable]: https://docs.microsoft.com/dotnet/api/system.iasyncdisposable
[preprocessor-if]: https://docs.microsoft.com/dotnet/csharp/language-reference/preprocessor-directives/preprocessor-if
