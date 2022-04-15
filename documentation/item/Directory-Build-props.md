# Directory.Build.props

Source Code: [Directory-Build-props](../../source/production/F0.Templates/templates/Directory-Build-props)

|               |                            |
|---------------|----------------------------|
| Template Name | Directory.Build.props file |
| Short Name    | `directory.build.props`    |
| Language      |                            |
| Tags          | Config/MSBuild             |
| Type          | item                       |
| Applies to    | [0.1.0,)                   |

## Description

Creates a Directory.Build.props file.

## Template Options

- `-e|--empty`\
Creates an empty file, which stops MSBuild from further scanning for more Directory.Build.props.
Available since [v0.3.0][0.3.0].
- `-mlm|--multi-level-merge`\
Makes MSBuild continue scanning the directory structure upward for the next Directory.Build.props and merges it into this file.
Available since [v0.3.0][0.3.0].
- `-wae|--warnings-as-errors`\
(Hidden) Treats warnings as errors when 'Configuration' is 'Release', except for obsolete warnings (CS0612 and CS0618).
Available since [v0.3.0][0.3.0].\
Both obsolete warnings [CS0612][cs0612] (without alternative workaround message) and [CS0618][cs0618] (with alternative workaround message) keep generating compiler warnings in the generated template.
Likewise, the obsolete error [CS0619][cs0619] continues to issue a compiler error.
For more information on marking program elements as obsolete, see [ObsoleteAttribute Class][obsoleteattribute].

## Usage Examples

- Print out help for the template:\
`dotnet new directory.build.props --help`
- Create a common _Directory.Build.props_ file:\
`dotnet new directory.build.props`
- Create an empty file, which stops MSBuild from further scanning for more _Directory.Build.props_:\
`dotnet new directory.build.props --empty`
- Include an _Import_ element to find and merge the next _Directory.Build.props_ upward in the directory structure:\
`dotnet new directory.build.props --multi-level-merge`

## See also

- [Customize your build](https://docs.microsoft.com/visualstudio/msbuild/customize-your-build#directorybuildprops-and-directorybuildtargets)

## History

- [0.3.0][0.3.0]
- [0.1.0](../../CHANGELOG.md#v010-2021-01-14)

[0.3.0]: ../../CHANGELOG.md#v030-2021-01-28
[cs0612]: https://docs.microsoft.com/dotnet/csharp/misc/cs0612
[cs0618]: https://docs.microsoft.com/dotnet/csharp/language-reference/compiler-messages/cs0618
[cs0619]: https://docs.microsoft.com/dotnet/csharp/misc/cs0619
[obsoleteattribute]: https://docs.microsoft.com/dotnet/api/system.obsoleteattribute
