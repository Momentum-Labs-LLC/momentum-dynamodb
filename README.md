# Using the 

# Makefile
Found at ./Makefile

The make file assumes a Windows Environment. 

There are commands to alias dotnet commands like
`make clean` (dotnet clean)
`make restore` (dotnet restore)
`make build` (dotnet build)
`make test` (dotnet test)

There is a command to create a unit test code coverage report as well, expect `reportgenerator` to be installed.
`make test-coverage`

A command to create nuget packages from your solution projects is available here.
`make pack`
This generates a version 1.0.0 nuget package for your projects in the `.\nuget` directory.
To provide a different version use: `make pack VERSION={version_value}` like:
`make pack VERSION=1.0.1-alpha`.

# Github Nuget Packages Setup
Use the `make setup-github-nuget GH_USER={username} GH_TOKEN={PAT}`
The personal access token being used must have at least read access for packages.