namespace SimpleServer
{
    public class SpanishGreetingObject : IGreetingObject
    {
        public string Greeting { get; set; } = "Hola! La accion: {0}, y el mensaje es: {1}";
        public string GetOnGetAction(string someMessage)
        {
            return string.Format(Greeting, "HTTP Get", someMessage);
        }

        public string GetOnPostAction(string someMessage)
        {
            return String.Format(Greeting, "HTTP Post", someMessage);
        }

        public string GetOnDeleteAction(string someMessage)
        {
            return String.Format(Greeting, "HTTP Delete", someMessage);
        }

        public string GetOnPutAction(string someMessage, string someOtherMessage)
        {
            return String.Format(Greeting, "HTTP Put", someMessage + " and " + someOtherMessage);
        }

        public string GetOnDeleteAction(string someMessage, string someOtherMessage)
        {
            return String.Format(Greeting, "HTTP Delete", someMessage + " and " + someOtherMessage);
        }
    }
}
