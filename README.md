# Pillars Of Creation
Pillars of Creation is a web-based idle game based on Eve Online set in a time when humanity is just leaving the Sol system and exploring the galaxy.

There's no public documentation on implementation right now, mainly because there is no game right now. 🙂  I'm using the game as a way to learn Blazor WebAssembly in my spare time.

---

## Setup and Deployment
### Prerequisites
TBD

1. Need to install libman by running `dotnet tool install -g Microsoft.Web.LibraryManager.Cli`


See this [article](https://learn.microsoft.com/en-us/aspnet/core/client-side/libman/libman-cli?view=aspnetcore-9.0) to learn more about LibMan.

### Project Setup
TBD

1. run `libman restore` in the `src/Pillars` directory to pull the libraries

### Project Versioning
Use [Versionize](https://www.nuget.org/packages/Versionize/) to automatically update the project's verison.

To preview the changelog run `versionize -di --skip-dirty`; otherwise run the following to update the version.

1. `versionize -i`  
1. `git push --follow-tags origin main`

Help getting all the commit messages since the last tag I created an alias in my `.bashrc` file.  Add the following line to the file.
`git log $(git describe --tags --abbrev=0)..HEAD --all --pretty=format:"%s"`
Then on bash use `git-loglasttag` with a `> commit_message.txt` to outut the commit messages to a file.

---

## Implementation Information
### Technologies
* [.NET](https://dotnet.microsoft.com) 9
* [Blazor WebAssembly](https://docs.microsoft.com/en-us/aspnet/core/blazor/?view=aspnetcore-9.0) 9
* [Blazored - LocalStorage](https://www.nuget.org/packages/Blazored.LocalStorage/) v4.5.0
* [Bootstrap](https://getbootstrap.com) v5.3.3 (via LibMan)
* [popper.js](https://popper.js.org/docs/v2/) v2.11.8 (via LibMan)

### Reading the Commit History
Commit messages should use [conventional commits](https://www.conventionalcommits.org/en/v1.0.0/) with the descriptors listed below.  For the scope please use the name of the feature.

Breaking changes **must** contain a line prefixed with `BREAKING CHANGE:` so [versionize](https://www.nuget.org/packages/Versionize/) recognizes a breaking change.  Breaking changes can use any commit type.

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

# Icons
<a target="_blank" href="https://icons8.com/icon/362/trash-can">Trash Can</a> icon by <a target="_blank" href="https://icons8.com">Icons8</a>

