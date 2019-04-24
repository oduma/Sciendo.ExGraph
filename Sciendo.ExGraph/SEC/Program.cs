using System;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Sciendo.Config;
using Sciendo.Csv.Processor;
using Sciendo.Csv.Processor.Mappers;
using Sciendo.ExGraph.Process;
using Sciendo.Music.Library.Contracts;
using Serilog;

namespace SEC
{
    class Program
    {
        private static void ConfigureLog()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("log-.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }
        private static SecConfig ReadConfiguration(string[] args)
        {
            var config =
                new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile($"{AppDomain.CurrentDomain.FriendlyName}.json")
                    .AddCommandLine(args)
                    .Build();
            SecConfig wieConfig;
            try
            {
                wieConfig = new ConfigurationManager<SecConfig>().GetConfiguration(config);
                Log.Information("Configuration read Ok.");
            }
            catch (Exception e)
            {
                Log.Error(e, "Something happened here!");
                throw;
            }

            return wieConfig;
        }

        static void Main(string[] args)
        {
            ConfigureLog();
            Log.Information("Starting...");
            var secConfig = ReadConfiguration(args);
            if (!ValidateConfig(secConfig))
                return;
            switch (secConfig.ActionType)
            {
                case ActionType.GetPossibleBandMembers:
                {
                    using (var query = new GetPossibleBandMembers(secConfig.Neo4JConfig.Host, secConfig.Neo4JConfig.UserName, secConfig.Neo4JConfig.Password))
                    {
                        var results = query.GetGraphObjects();

                        IOManager.WriteWithMapper<Neo4jBandWithPossibleMember, BandWithPossibleMemberMap>(results, secConfig.OutputFile);
                    }

                    return;
                }
                case ActionType.GetComposersNotBandMemmbers:
                {
                    using (var query = new GetComposersNotBandMembers(secConfig.Neo4JConfig.Host, secConfig.Neo4JConfig.UserName, secConfig.Neo4JConfig.Password))
                    {
                        var results = query.GetGraphObjects();

                        IOManager.WriteWithMapper<Neo4jBandWithPossibleMember, BandWithPossibleMemberMap>(results, secConfig.OutputFile);
                    }

                    return;
                }
                case ActionType.GetAllBands:
                {
                    using (var query = new GetAllBands(secConfig.Neo4JConfig.Host, secConfig.Neo4JConfig.UserName, secConfig.Neo4JConfig.Password))
                    {
                        var results = query.GetGraphObjects();

                        IOManager.WriteWithMapper<Neo4jArtist, ArtistMap>(results, secConfig.OutputFile);
                    }

                    return;
                }
            }
        }

        private static bool ValidateConfig(SecConfig secConfig)
        {
            if (string.IsNullOrEmpty(secConfig.OutputFile))
            {
                Log.Error("Argument output is missing");
                return false;
            }

            if (secConfig.ActionType == ActionType.None)
            {
                Log.Error("No Action, nothing to do.");
                return false;
            }

            return true;
        }
    }
}
