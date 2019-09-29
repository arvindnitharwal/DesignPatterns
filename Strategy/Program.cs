public namespace StrategyPattern
{
    //client will pass this or you can map the request in controller
    public class FilterRequest
    {
        public int MaxPrice {get;set;}
        public int MinPrice {get;set;}
        public int FilterId {get;set;}
        //.. add here
    }
    //response
    public class FilterResponse
    {
        string CarName {get;set;}
        string CarImage  {get;set;}
        //...add here 
    }
    public enum CarFilters
    {
        Invalid=0,
        BodyTypeCars = 1,
        FuelTypeCars = 2,
        TransmissionTypeCars = 3,
        BudgetTypeCars = 4
    }
    public interface ICarType
    {
        CarDetails GetCarDetails(FilterRequest filterRequest);
        //...add other functions here
    }
    public class FuleTypeCars : ICarType
    {
        public FilterResponse GetCarDetails(FilterRequest filterRequest)
        {
            //call other service 
            return new FilterResponse();
        }
        //...add other functions here
    }
    public class BudgetTypeCars : ICarType
    {
        public FilterResponse GetCarDetails(FilterRequest filterRequest)
        {
            //call other service 
            return new FilterResponse();
        }
        //...add other functions here
    }
    public class TransmissionTypeCars : ICarType
    {
        public FilterResponse GetCarDetails(FilterRequest filterRequest)
        {
            //call other service 
            return new FilterResponse();
        }
        //...add other functions here
    }
    //..add more classes
    //so we have create differnet-2 classes for each filter type car
    //single interface for all classes
    public class CarFilterManager
    {
        //map all classes to enum
        private  static Dictionary _filterMapping;
        public CarFilterManager()
        {
            _filterMapping=new Dictionary<CarFilters,ICarType>();
            //if you are using dependency injection then map using Resolve(parameter) or other tech
            //else you can cresting new object
            _filterMapping.Add(CarFilters.FuelTypeCars,new FuleTypeCars());
        }
        public FilterResponse GetFilteredCars(FilterRequest filterRequest)
        {
            return _filterMapping[(CarFilters)filterRequest.FilterId].GetCarDetails(filterRequest)
        }
    }
    public interface ICarType
    {
        CarDetails GetFilterDetails(FilterRequest filterRequest);
    }
}