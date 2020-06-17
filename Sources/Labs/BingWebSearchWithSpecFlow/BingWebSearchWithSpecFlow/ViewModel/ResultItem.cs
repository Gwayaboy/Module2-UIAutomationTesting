namespace BingWebSearchWithSpecFlow.ViewModel
{
    public class ResultItem
    {
        public string Title { get; }
        public string Url { get; }

        public ResultItem(string title, string url)
        {
            Title = title;
            Url = url;
        }
    }
}