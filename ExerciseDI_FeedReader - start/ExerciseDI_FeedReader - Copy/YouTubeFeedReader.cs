namespace ExerciseDI_FeedReader
{
    public class YouTubeFeedReader : IFeedReader
    {

        public YouTubeFeedReader()
        {
            ReturnType = "Video";
        }

        public string ReturnType { get; }

        public string GetSingleFeed()
        {
            return ReturnType + ":item 1";
        }
    }
}
