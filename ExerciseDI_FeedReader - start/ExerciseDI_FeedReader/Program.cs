using ExerciseDI_FeedReader;

internal class Program
{
    private static void Main(string[] args)
    {
        FeedService service = new FeedService(new PodcastFeedReader());
        FeedService service2 = new FeedService(new YouTubeFeedReader());
        FeedService service3 = new FeedService(new BlogFeedReader());
        //string feed = servicePodcast.GetFeed();


        Console.WriteLine(service.GetFeed());
        Console.WriteLine(service2.GetFeed());
        Console.WriteLine(service3.GetFeed());

        Console.ReadLine();
    }
}