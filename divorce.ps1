 # Run git status and capture the output
 $gitStatus = git status

 # Check if the output indicates uncommitted changes
 if ($gitStatus -like '*Changes not staged for commit:*' -or $gitStatus -like '*Changes to be committed:*' -or $gitStatus -like '*Untracked files*') {
     # Throw an exception if uncommitted changes are found
     throw 'Uncommitted changes detected. Please commit or stash your changes.'
 }

$env:MetalamaEmitCompilerTransformedFiles="true"
$env:MetalamaFormatOutput="true"
dotnet build /t:rebuild
metalama divorce