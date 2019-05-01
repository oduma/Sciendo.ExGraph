using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sciendo.BandMembers.Processor;
using Sciendo.Music.Library.Contracts;
using Sciendo.Wiki.Processor;
using Serilog;

namespace Sciendo.Music.Library.BusinessLogic
{
    public class BandWithWikiInfo:IBandWithExternalInfoComponent
    {

        public BandWithExternalInfo LoadExternalInfoFromSource(Artist artist, Dictionary<LanguageType,IWikiSearch> wikiSearches)
        {
            if (artist==null || string.IsNullOrEmpty(artist.Name))
                return null;
            foreach (var language in wikiSearches.Keys)
            {
                wikiSearches[language].Search(artist.Name);
                if (wikiSearches[language].Query.SearchInfo.TotalHits > 0)
                {
                    foreach (var hit in wikiSearches[language].Query.SearchResults)
                    {
                        if (hit.Title.ToLower() == artist.Name)
                        {
                            Log.Information("Band found {0} in WikiPedia with pageId {1} in language {2}", artist.Name, hit.PageId, language);
                            var band = new BandWithExternalInfo(artist);
                            band.ExternalInfoIdentifier = hit.PageId;
                            band.LanguageType = language;
                            return band;
                        }
                    }
                }

            }
            Log.Information("Band not found {0} in WikiPedia", artist.Name);
            return new BandWithExternalInfo(artist);
        }

        public BandWithExternalInfo LoadMembersFromSource(BandWithExternalInfo band, IWikiPageText wikiPageText,ProcessingRulesEngine processingRulesEngine)
        {
            if (band.ExternalInfoIdentifier == 0)
                return band;
            wikiPageText.LoadPage(band.ExternalInfoIdentifier);
            band.Members = new List<Artist>();
            foreach (var artistName in processingRulesEngine.ApplyAllRules(wikiPageText.ParsedPage.WikiText.AllText))
            {
                Log.Information("Found member: {0}", artistName);
                band.Members.Add(new Artist { Name = artistName });
            }
            return band;
        }

        public IEnumerable<BandWithPossibleMember> CleanMembers(BandWithExternalInfo band, ProcessingRulesEngine processingRulesEngine)
        {
            if (band.Members.Any())
            {
                foreach (var existingArtist in band.Members)
                {
                    foreach (var cleanedArtistName in processingRulesEngine.ApplyAllRules(existingArtist.Name))
                    {
                        Log.Information("Cleaned member: {0}", cleanedArtistName);
                        yield return new BandWithPossibleMember
                        {
                            Band = new Artist {ArtistId = band.ArtistId, Name = band.Name},
                            Member = new Artist {ArtistId = Guid.Empty, Name = cleanedArtistName}
                        };
                    }
                }
            }
        }
    }
}
