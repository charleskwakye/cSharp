

namespace ExerciseDI_FeedReader
{
    public class FeedService
    {
        IFeedReader _reader;



        public FeedService(IFeedReader Reader)
        {
            _reader = Reader;
        }

        public String GetFeed()
        {
            return _reader.GetSingleFeed();
        }


    }
}
