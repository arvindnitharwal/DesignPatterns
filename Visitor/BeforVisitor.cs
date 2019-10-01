//suppose we have 3 classes
//1.News 2.Expertreview 3.RoadTest
//these classes have different-2 interfaces
//now product want to show seo text for each class
//one solution is we can add GetSeotext function to each interface and class also.
//this can break our existing functionally or for new requirement we have to add
//new function
public namespace BeforVisitor
{
    #region current
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
    //existing classes
    public class News:INews
    {
        public void GetNews(int id)
        {

        }
        //.. other functions
    }
    public class ExpertReview:IExpertReview
    {
        void GetExpertReview(int id)
        {

        }
        //.. other functions
    }
    public class RoadTest:IRoadTest
    {
        void GetRoadTest(int id)
        {

        }
        //.. other functions
    }
    #endregion
}