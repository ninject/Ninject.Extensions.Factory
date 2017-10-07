# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](http://keepachangelog.com/en/1.0.0/)
and this project adheres to [Semantic Versioning](http://semver.org/spec/v2.0.0.html).

## [Unreleased]

### Fixed
- Ninject.Extensions.Factory.FuncTests.LazyInjection fails at .NET Core 2.0 [#38](https://github.com/ninject/Ninject.Extensions.Factory/issues/38)

## [3.3.0] - 2017-10-05

### Added
- Support .NET Standard 2.0
- Added decorator support [#33](https://github.com/ninject/Ninject.Extensions.Factory/pull/33)

### Removed
- .NET 3.5, .NET 4.0 and Silverlight

## [3.2.0]

### Added
- Implementation (TypeMatchingArgumentInheritanceInstanceProvider) of IInstanceProvider creating inherited constructor arguments matching by type

## Fixed
- Fixed internal Memory leak
- Fallback now supports multiple bindings

## [3.0.1]

### Added
- Binding syntax extension method (NamedLikeFactoryMethod) for defining a named binding corresponding with a GetXYZ factory method


## [3.0.0.0]

Initial version