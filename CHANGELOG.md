# F0.Templates
CHANGELOG

## vNext

## v0.3.1 (2021-02-02)
### Directory.Build.props
- Fixed option `-wae|--warnings-as-errors`, additionally treating warning _CS0612_ (Type or member is obsolete) not as error.

## v0.3.0 (2021-01-28)
### Directory.Build.props
- Added option `-e|--empty`.
- Added option `-mlm|--multi-level-merge`.
- Added option `-wae|--warnings-as-errors` (hidden), which treats all warnings as errors except for _CS0618_ (Type or member is obsolete).

### Directory.Build.targets
- Added option `-e|--empty`.
- Added option `-mlm|--multi-level-merge`.
- Added option `-dc|--define-constants` (hidden).

### Directory.Packages.props
- Added option `-oo|--opt-out`.
- Added option `-e|--empty`.

## v0.2.0 (2021-01-22)
### Template pack
- Suppressed package dependencies, fixing NuGet Warning NU5128.

### Directory.Packages.props
- Fixed inconsistent formatting.

## v0.1.0 (2021-01-14)
- Added `Directory.Build.props` (MSBuild) item template.
- Added `Directory.Build.targets` (MSBuild) item template.
- Added `Directory.Packages.props` (NuGet) item template.
