// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using PostSharp.Engineering.BuildTools;
using PostSharp.Engineering.BuildTools.Build;
using PostSharp.Engineering.BuildTools.Build.Model;
using PostSharp.Engineering.BuildTools.Build.Publishers;
using PostSharp.Engineering.BuildTools.Build.Solutions;
using PostSharp.Engineering.BuildTools.Dependencies.Model;
using Spectre.Console.Cli;

namespace BuildCaravela
{
    internal static class Program
    {
        private static int Main(string[] args)
        {
            var product = new Product(new DependencyDefinition("Metalama.Demo", VcsProvider.GitHub, "Metalama.Demo", false))
            {
                Solutions = new[] { new DotNetSolution("Metalama.Demo.sln") },
                Dependencies = new[] { Dependencies.PostSharpEngineering, Dependencies.Metalama },
                Configurations = Product.DefaultConfigurations
                    .WithValue(BuildConfiguration.Public, Product.DefaultConfigurations.Public with { PublicPublishers = new Publisher[] { new MergePublisher() } })
            };

            var commandApp = new CommandApp();
            commandApp.AddProductCommands(product);

            return commandApp.Run(args);
        }
    }
}