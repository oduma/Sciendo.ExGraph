using System;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Sciendo.BandMembers.Processor;
using Sciendo.Config;
using Sciendo.Csv.Processor;
using Sciendo.Csv.Processor.Mappers;
using Sciendo.Music.Library.BusinessLogic;
using Sciendo.Music.Library.Contracts;
using Sciendo.Wiki.Processor;
using Serilog;
using Serilog.Core;

namespace WIE
{
    class Program
    {
        private const string KnowledgeBaseFolder = "knowledgebase";
        private static void ConfigureLog()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("log-.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }

        private static WieConfig ReadConfiguration(string[] args)
        {
            var config =
                new ConfigurationBuilder()
                    .AddCommandLine(args)
                    .Build();
            WieConfig wieConfig;
            try
            {
                wieConfig = new ConfigurationManager<WieConfig>().GetConfiguration(config);
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
            var wieConfig = ReadConfiguration(args);
            if (!ValidateConfig(wieConfig))
                return;
            switch (wieConfig.ProcessType)
            {
                case ProcessType.FindWikiPageIds:
                {
                    try
                    {
                        var inputData = IOManager.ReadWithMapper<Artist, ArtistMap>(wieConfig.InputFile).ToList();
                        IOManager.WriteWithMapper<BandWithExternalInfo, BandWithExternalInfoMap>(
                            inputData.Select(b=>b.LoadWikiPageId()), wieConfig.OutputFile);
                    }
                    catch (Exception e)
                    {
                        Log.Error(e, "Cannot read file {0}, possibly not suitable format for action: {1}",
                            wieConfig.InputFile, wieConfig.ProcessType);
                        return;
                    }
                    break;
                }
                case ProcessType.GetBandMembers:
                {
                    try
                    {
                        var inputData = IOManager.ReadWithMapper<BandWithExternalInfo, BandWithExternalInfoMap>(wieConfig.InputFile).ToList();
                        IOManager.WriteWithMapper<BandWithExternalInfo, BandWithExternalInfoMap>(
                            inputData.Select(b=>b.LoadWikiPageMembers(KnowledgeBaseFolder)), wieConfig.OutputFile);
                    }
                    catch (Exception e)
                    {
                        Log.Error(e, "Cannot read file {0}, possibly not suitable format for action: {1}",
                            wieConfig.InputFile, wieConfig.ProcessType);
                        return;
                    }
                    break;
                }
                case ProcessType.CleanExistingMembers:
                {
                    try
                    {
                        var inputData = IOManager.ReadWithMapper<BandWithExternalInfo, BandWithExternalInfoMap>(wieConfig.InputFile).ToList();
                        IOManager.WriteWithMapper<BandWithPossibleMember, BandWithPossibleMemberMap>(
                            inputData.SelectMany(b=>b.CleanWikiPageMembers(KnowledgeBaseFolder,wieConfig.SimpleWordsSeparator)).OrderBy(b => b.Member.Name), wieConfig.OutputFile);
                    }
                    catch (Exception e)
                    {
                        Log.Error(e, "Cannot read file {0}, possibly not suitable format for action: {1}",
                            wieConfig.InputFile, wieConfig.ProcessType);
                        return;
                    }
                    break;
                }
                case ProcessType.FullProcess:
                {
                    try
                    {
                        var inputData = IOManager.ReadWithMapper<Artist, ArtistMap>(wieConfig.InputFile).ToList();
                        IOManager.WriteWithMapper<BandWithPossibleMember, BandWithPossibleMemberMap>(
                            inputData.SelectMany(b => b.LoadWikiPageId().LoadWikiPageMembers(KnowledgeBaseFolder).CleanWikiPageMembers(KnowledgeBaseFolder,wieConfig.SimpleWordsSeparator)), wieConfig.OutputFile);
                    }
                    catch (Exception e)
                    {
                        Log.Error(e, "Cannot read file {0}, possibly not suitable format for action: {1}",
                            wieConfig.InputFile, wieConfig.ProcessType);
                        return;
                    }
                    break;
                }
                default:
                {
                    Log.Error("Invalid action {0}",wieConfig.ProcessType);
                    break;
                }
            }
        }

        private static bool ValidateConfig(WieConfig wieConfig)
        {
            if (string.IsNullOrEmpty(wieConfig.InputFile))
            {
                Log.Error("Argument missing. CSV input file.");
                return false;
            }

            if (!File.Exists(wieConfig.InputFile))
            {
                Log.Error("CSV input file {0} not found.", wieConfig.InputFile);
                return false;
            }

            if (string.IsNullOrEmpty(wieConfig.OutputFile))
            {
                Log.Error("Argument missing. CSV output file.");
                return false;
            }

            if (wieConfig.ProcessType == ProcessType.None)
            {
                Log.Error("Nothing to do here.");
                return false;
            }

            return true;
        }

    }
}
