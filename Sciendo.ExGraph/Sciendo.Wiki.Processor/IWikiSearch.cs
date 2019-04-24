namespace Sciendo.Wiki.Processor
{
    public interface IWikiSearch
    {
        void Search(string text);
        string BatchComplete { get; set; }
        PageInfo PageInfo { get; set; }
        Query Query { get; set; }
    }
}