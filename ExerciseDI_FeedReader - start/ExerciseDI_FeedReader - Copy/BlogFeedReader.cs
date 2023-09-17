namespace ExerciseDI_FeedReader
{
    public class BlogFeedReader : IFeedReader
    {
        public BlogFeedReader()
        {
            ReturnType = "Blog";
        }

        public string ReturnType { get; }

        public string GetSingleFeed()
        {
            return ReturnType + ":item 1"; ;
        }


    }
}
