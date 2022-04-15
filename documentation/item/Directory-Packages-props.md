# Directory.Packages.props

Source Code: [Directory-Packages-props](../../source/production/F0.Templates/templates/Directory-Packages-props)

|               |                               |
|---------------|-------------------------------|
| Template Name | Directory.Packages.props file |
| Short Name    | `directory.packages.props`    |
| Language      |                               |
| Tags          | Config/NuGet                  |
| Type          | item                          |
| Applies to    | [0.1.0,)                      |

## Description

Creates a Directory.Packages.props file.

## Template Options

- `-oo|--opt-out`\
Opt-out of Central Package Version Management; otherwise, opt-in explicitly.
Available since [v0.3.0][0.3.0].
- `-e|--empty`\
No 'PackageVersion' elements are defined.
Available since [v0.3.0][0.3.0].

## Usage Examples

- Print out help for the template:\
`dotnet new directory.packages.props --help`
- Create a common _Directory.Packages.props_ file, with explicit opt-in to Central Package Version Management:\
`dotnet new directory.packages.props`

## See also

- [Centrally managing NuGet package versions](https://github.com/NuGet/Home/wiki/Centrally-managing-NuGet-package-versions)

## History

- [0.3.0][0.3.0]
- [0.1.0](../../CHANGELOG.md#v010-2021-01-14)

[0.3.0]: ../../CHANGELOG.md#v030-2021-01-28
