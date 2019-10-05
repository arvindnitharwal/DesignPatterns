//so suppose you have 3 pages
//Home ,CarMake,CarModel and we want to show Top Articles
//on Home page we will show only Top News,Videos
//on CarMake Page we will show Top News,Expert Reviews,Reviews,Images
//on CarModel Page we will show News,Videos,Images

//sol:-create a mediator and let decide this meditor to fetch the date based on page
//similar to rabbitMq
//assume page as Key and content Type as value

public namespace MediatorPattern {
    //request
    public class Filter {
        //..request data
        public Pages PageType {get;set;}
    }
    //response
    public class Response {
        //..response data
    }
    //enum for page
    public enum Pages {
        Home = 1,
        Make = 2,
        Model = 3
    }
    //enum for content type
    public enum Content {
        News = 1,
        Video = 2,
        Reviews = 3,
        Images = 4,
        ExpertReview = 5
    }
    //mediator
    public class Mediator {
        private Dictionary<Pages, List<Content>> _pageMapping;
        private Dictionary<Content, IContent> _functionMapping;
        //to map same interface with different class we can use unity container.
        public Mediator () {
            _pageMapping = new Dictionary<Pages, List<Content>> ();
            _functionMapping=new Dictionary<Content, IContent>();
            _pageMapping.Add (Pages.Home, new List<Content> { Content.News, Content.Video });
            _pageMapping.Add (Pages.Make, new List<Content> { Content.News, Content.ExpertReview, Content.Reviews });
            _pageMapping.Add (Pages.Model, new List<Content> { Content.News, Content.Images, Content.Reviews });
        }
        public Response ContentResponse(Filter contentRequest)
        {
            //get content list
            List<Content> mappedContent=_pageMapping[contentRequest.PageType];
            List<Response> contentResponse;
            foreach(var content in mappedContent)
            {
                contentResponse.Add(_functionMapping[content](contentRequest));
            }
        }
    }
    //interface for subscribers
    public interface IContent {
        void GetContent (Filter request);
    }
    //subscribers
    public class News : IContent {
        public void GetContent (Filter request) {
            ///other functions
        }
    }
    public class Reviews : IContent {
        public void GetContent (Filter request) {
            ///other functions
        }
    }
    public class Expertreview : IContent {
        public void GetContent (Filter request) {
            ///other functions
        }
    }
    public class Video : IContent {
        public void GetContent (Filter request) {
            ///other functions
        }
    }
    public class Images : IContent {
        public void GetContent (Filter request) {
            ///other functions
        }
    }
}