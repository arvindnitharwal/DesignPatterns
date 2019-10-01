public namespace AfterVisitor
{
    //existing interfaces
    public interface INews
    {
        void GetNews(int id);
        //.. other functions
    }
    public interface IExpertReview
    {
        void GetExpertReview(int id);
        //.. other functions
    }
    public interface IRoadTest
    {
        void GetRoadTest(int id);
        //.. other functions
    }
    //new interface
    public interface IContentPart
    {
        void accept(IContentVisitor ContentVisitor);
    }
    //existing classes
    public class News : INews, IContentPart
    {
        public void Accept(IContentVisitor visitor)
        {
            visitor.SeoText(this);
        }
        public void GetNews(int id)
        {

        }
        //.. other functions
    }
    public class ExpertReview : IExpertReview, IContentPart
    {
        public void Accept(IContentVisitor visitor)
        {
            visitor.SeoText(this);
        }
        void GetExpertReview(int id)
        {

        }
        //.. other functions
    }
    public class RoadTest : IRoadTest, IContentPart
    {
        public void Accept(IContentVisitor visitor)
        {
            visitor.SeoText(this);
        }
        void GetRoadTest(int id)
        {

        }
        //.. other functions
    }
    //new interface
    public interface IContentVisitor
    {
        string SeoText(News news);
        string SeoText(ExpertReview news);
        string SeoText(RoadTest news);
    }
    public class ContentVisitor : IContentVisitor
    {
        public string SeoText(News news)
        {
            return "news";
        }
        public string SeoText(ExpertReview news)
        {
            return "ExpertReview";
        }
        public string SeoText(RoadTest news)
        {
            return "RoadTest";
        }
    }
    //call this ContentVisitor via original classes
    public class client 
    {
        //list of all objects
        List<object> list =new List{INews,IExpertReview,IRoadTest};
        //call visitor
    }
}