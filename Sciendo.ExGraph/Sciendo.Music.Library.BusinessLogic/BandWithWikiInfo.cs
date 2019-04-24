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

        public BandWithExternalInfo LoadExternalInfoIdFromSource(Artist artist, IWikiSearch wikiSearch)
        {
            if (artist==null || string.IsNullOrEmpty(artist.Name))
                return null;
            wikiSearch.Search(artist.Name);
            if (wikiSearch.Query.SearchInfo.TotalHits > 0)
            {
                foreach (var hit in wikiSearch.Query.SearchResults)
                {
                    if (hit.Title.ToLower() == artist.Name)
                    {
                        Log.Information("Band found {0} in WikiPedia with pageId {1}", artist.Name, hit.PageId);
                        var band = new BandWithExternalInfo(artist);
                        band.ExternalInfoIdentifier = hit.PageId;
                        return band;
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

        public BandWithExternalInfo CleanMembers(BandWithExternalInfo band, ProcessingRulesEngine processingRulesEngine)
        {
            if (!band.Members.Any())
                return band;
            var newBand = new BandWithExternalInfo(band);
            newBand.ExternalInfoIdentifier = band.ExternalInfoIdentifier;
            newBand.Members= new List<Artist>();
            foreach (var existingArtist in band.Members)
            {
                foreach (var cleanedArtistName in processingRulesEngine.ApplyAllRules(existingArtist.Name))
                {
                    Log.Information("Cleaned member: {0}", cleanedArtistName);
                    newBand.Members.Add(new Artist { Name = cleanedArtistName });
                }
            }
            return newBand;
        }
    }
}
