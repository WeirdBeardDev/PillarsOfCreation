# Changelog
Commit messages should use [conventional commits](https://www.conventionalcommits.org/en/v1.0.0/) with the descriptors listed below.  For the scope please use the name of the feature.

Breaking changes **must** contain a line prefixed with `BREAKING CHANGE:` so versionize recognizes a breaking change.  Breaking changes can use any commit type.

| Desriptor | Definition                                                                                          |
| :-------- | :-------------------------------------------------------------------------------------------------- |
| build:    | changes that effect the build system or external dependencies (scopes: npm, dotnet)                 |
| chore:    | miscellaneous commits, (ex: modifying `.gitignore`, etc)                                            |
| ci:       | changes to the CI configuration files and scripts                                                   |
| docs:     | documentation only changes                                                                          |
| feat:     | a new feature (these bump the MINOR version number)                                                 |
| fix:      | a bug fix (these bump the PATCH version number)                                                     |
| perf:     | a code change that improves performance                                                             |
| refactor: | a code change that neither fixes a bug nor adds a feature, instead it improves the flow of the code |
| style:    | changes that do not effect the meaning of the code (ex: whitespace, formatting, etc.)               |
| test:     | adding missing tests or correcting existing test                                                    |

## Update Version
Use [Versionize](https://www.nuget.org/packages/Versionize/) to automatically update the project's verison.

To preview the changelog run `versionize -di --skip-dirty`; otherwise run the following to update the version.

1. `versionize -i`  
1. `git push --follow-tags origin main`

# Prerelease Work
## July 2023
* [upd] Update Bootstrap to v5.3.0




<a name="0.0.0"></a>
## [0.0.0](https://www.github.com/WeirdBeardDev/PillarsOfCreation/releases/tag/v0.0.0) (2023-8-13)

### Bug Fixes

* **UI:** Update CSS to use start instead of left ([7b276bd](https://www.github.com/WeirdBeardDev/PillarsOfCreation/commit/7b276bd6cd33c05dd5d03b69f2c0a7cddba38ffe))

### Documentation

* Add versionize instructions ([54a2938](https://www.github.com/WeirdBeardDev/PillarsOfCreation/commit/54a2938c148e71c8d47d4abf5c55f7a5e1c339ae))
* Update changelog to better describe the versioning system ([5d46bb4](https://www.github.com/WeirdBeardDev/PillarsOfCreation/commit/5d46bb499777a81af19e53ab9a2d4c40669ebf2a))

