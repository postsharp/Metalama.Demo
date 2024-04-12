 # Run git status and capture the output
 $gitStatus = $(git status --porcelain)

 # Check if the output indicates uncommitted changes
 if (-not [string]::IsNullOrWhiteSpace($gitStatus)) {
     # Throw an exception if uncommitted changes are found
     throw "Uncommitted changes detected. Please commit or stash your changes. >>$gitStatus<<"
 }

 # Create a new branch
 $currentTimestamp  = Get-Date -Format "yyyyMMdd-HHmmss"
 $branchName = "divorce-$currentTimestamp"
 git checkout -b $branchName

 # Format code
 dotnet format

 # Commit
 git commit -a -m "Formatting the code before Metalama divorce."

 # Enable code formatting for Metalama
$env:MetalamaEmitCompilerTransformedFiles="true"
$env:MetalamaFormatOutput="true"

# Rebuild
dotnet build /t:rebuild

# Write generated code back to the source code
metalama divorce

## Format
dotnet format