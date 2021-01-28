# F0.Templates
CHANGELOG

## vNext
### Directory.Build.props
- Added option `-e|--empty`.
- Added option `-mlm|--multi-level-merge`.
- Added option `-wae|--warnings-as-errors` (hidden).

### Directory.Build.targets
- Added option `-e|--empty`.
- Added option `-mlm|--multi-level-merge`.
- Added option `-dc|--define-constants` (hidden).

## v0.2.0 (2021-01-22)
### Template pack
- Suppressed package dependencies, fixing NuGet Warning NU5128.

### Directory.Packages.props
- Fixed inconsistent formatting.

## v0.1.0 (2021-01-14)
- Added `Directory.Build.props` (MSBuild) item template.
- Added `Directory.Build.targets` (MSBuild) item template.
- Added `Directory.Packages.props` (NuGet) item template.
