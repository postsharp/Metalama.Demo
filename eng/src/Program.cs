// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using PostSharp.Engineering.BuildTools;
using PostSharp.Engineering.BuildTools.Build.Model;
using PostSharp.Engineering.BuildTools.Dependencies.Model;
using Spectre.Console.Cli;
using System.Collections.Immutable;

namespace BuildCaravela
{
    internal static class Program
    {
        private static int Main( string[] args )
        {
       
            var product = new Product
            {
                ProductName = "My.Product",
                Solutions = ImmutableArray.Create<Solution>( new DotNetSolution( "src\\My.Product.sln" ) ),
                PublicArtifacts = Pattern.Create( "My.Product.$(PackageVersion).nupkg" ),
                Dependencies = ImmutableArray.Create( Dependencies.PostSharpEngineering, Dependencies.Metalama )
            };

            var commandApp = new CommandApp();
            commandApp.AddProductCommands( product );

            return commandApp.Run( args );
        }
    }
}