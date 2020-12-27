public class ArticleLogic 
{ 
 public GetArticle(string typeOfArticle)
 {
    if(typeOfArticle == "news")
    { 
        return new NewsLogic();
    }
    else if(typeOfArticle == "expertreview")
    { 
        return new ExpertReviewLogic();
    }
    else if(typeOfArticle == "images")
    { 
        return new ImagesLogic();
    }
    else if(typeOfArticle == "videos")
    {
        return new VideosLogic();
    }
 }
}
