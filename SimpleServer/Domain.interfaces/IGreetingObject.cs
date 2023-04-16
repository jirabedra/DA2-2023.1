namespace Domain.interfaces
{
    public interface IGreetingObject
    {
        string GetOnDeleteAction(string someMessage);
        string GetOnDeleteAction(string someMessage, string someOtherMessage);
        string GetOnGetAction(string someMessage);
        string GetOnPostAction(string someMessage);
        string GetOnPutAction(string someMessage, string someOtherMessage);
    }
}