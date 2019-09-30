//use this pattern when multiple classes have same logic for some functions.
//AbstractClass class have three type of functions.
//1.baseOpertaion 2.RequiredOpertaion 3.OptionalOpertaion
public namespace TemplatePattern
{
    public enum FilterType
    {
        FuelType=1,
        BodyType=2,
        TransmissionType=3
        //.. add more filter here
    }
    public class Request
    {
        int filterId;
        //..add here
    }
    public class Response
    {
        int filterId;
        string carName;
        //..add here
    }
    //initlize/define all functions here
    public abstract class Base
    {
        public void TemplateMethod()
        {
            this.GetFilterResponse();
            //seo text may differ based on filter
            this.GetSeotext();
        }
        protected Response GetFilterResponse(Request carRequest)
        {
            //call other function
            return new Response();
        }
        // This operations have to be implemented in subclasses.
        protected abstract string GetSeotext();
    }
    public class BodyTypeFilter : Base 
    {
         protected override string GetSeotext()
         {
             return string.Empty;
         }
    }
    public class FuelTypeFilter : Base 
    {
         protected override string GetSeotext()
         {
             return string.Empty;
         }
    }
    //.. add other classes

     class Client
    {
        // The client code calls the template method to execute the algorithm.
        public static void ClientCode(Base baseClass)
        {
            // ...
            baseClass.TemplateMethod();
            // ...
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Client.ClientCode(new BodyTypeFilter());
            Client.ClientCode(new FuelTypeFilter());
        }
    }
}