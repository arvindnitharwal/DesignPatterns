//this pattern works like publisher-subscriber tech.
//we have 4 platforms(Mobile,Desktop,IOS,Android).now po want to send to notifications to each platforms
//based on some conditions like she can send to all combinations of platforms.
public namespace ObserverPattern {
    public enum Platforms {
        All = 0,
        Desktop = 1,
        Mobile = 2,
        Android = 3,
        IOS = 4
    }
    public class Request {
        public Platforms PlatformId { get; set; }
        //..add other parameters here
    }
    public interface ISubscriber {
        void Update (Request request);
    }
    public class Desktop : ISubscriber {
        public void Update (Request request) {
            if (request.PlatformId == Platforms.All || request.PlatformId == Platforms.Desktop) {
                //send notification
            }
        }
    }
    public class Mobile : ISubscriber {
        public void Update (Request request) {
            if (request.PlatformId == Platforms.All || request.PlatformId == Platforms.Mobile) {
                //send notification
            }
        }
    }
    public class Android : ISubscriber {
        public void Update (Request request) {
            if (request.PlatformId == Platforms.All || request.PlatformId == Platforms.Android) {
                //send notification
            }
        }
    }
    public class IOS : ISubscriber {
        public void Update (Request request) {
            if (request.PlatformId == Platforms.All || request.PlatformId == Platforms.IOS) {
                //send notification
            }
        }
    }
    public interface IPublisher {
        // Attach an Subscriber to the publisher.
        void Attach (ISubscriber observer);
        // Detach an Subscriber from the publisher.
        void Detach (ISubscriber observer);
        // Notify all Subscriber about an event.
        void Notify ();
    }
    public class Publisher : IPublisher {
        private List<ISubscriber> _observers = new List<ISubscriber> ();

        // The subscription management methods.
        public void Attach (ISubscriber observer) {
            this._observers.Add (observer);
        }

        public void Detach (ISubscriber observer) {
            this._observers.Remove (observer);
        }

        // Trigger an update in each subscriber.
        public void Notify () {
            foreach (var observer in _observers) {
                observer.Update (this);
            }
        }
    }
}