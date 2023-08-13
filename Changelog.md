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


