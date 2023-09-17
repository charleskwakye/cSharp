namespace ExerciseDI_FeedReader
{
    public class PodcastFeedReader : IFeedReader
    {
        public PodcastFeedReader()
        {
            ReturnType = "Audio";
        }

        public string ReturnType { get; }

        public string GetSingleFeed()
        {
            return ReturnType + ":item 1";
        }
    }
}
