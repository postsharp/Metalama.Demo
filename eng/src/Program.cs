// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.


using PostSharp.Engineering.BuildTools;
using PostSharp.Engineering.BuildTools.Build;
using PostSharp.Engineering.BuildTools.Build.Model;
using PostSharp.Engineering.BuildTools.Build.Publishers;
using PostSharp.Engineering.BuildTools.Build.Solutions;
using PostSharp.Engineering.BuildTools.ContinuousIntegration;
using PostSharp.Engineering.BuildTools.Dependencies.Definitions;
using PostSharp.Engineering.BuildTools.Dependencies.Model;
using Spectre.Console.Cli;
using MetalamaDependencies = PostSharp.Engineering.BuildTools.Dependencies.Definitions.MetalamaDependencies.V2024_2;

var teamCityConfiguration = TeamCityHelper.CreateConfiguration( TeamCityHelper.GetProjectId( "Metalama.Demo" ) );

var product = new Product(new DependencyDefinition( MetalamaDependencies.Family, "Metalama.Demo", "dev", "master", new GitHubRepository("Metalama.Demo" ), teamCityConfiguration, false))
{
    Solutions = new[] { new DotNetSolution("Metalama.Demo.sln") },
    Dependencies = new[] { DevelopmentDependencies.PostSharpEngineering.ToDependency(), MetalamaDependencies.MetalamaPatterns },
    Configurations = Product.DefaultConfigurations
        .WithValue(BuildConfiguration.Public, Product.DefaultConfigurations.Public with { PublicPublishers = new Publisher[] { new MergePublisher() } })
};

var commandApp = new CommandApp();
commandApp.AddProductCommands(product);

return commandApp.Run(args);
 