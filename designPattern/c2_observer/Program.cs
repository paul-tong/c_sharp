using System;

/*
NOTE: The Observer Pattern defines a one-to-many dependency between objects so that when one
object changes state, all of its dependents are notified and updated automatically
real life example:
news subscriber(observer) get nodification from publisher(subject) when news come out
*/
namespace c2_observer
{
    public interface Subject {
        void registerObserver(Observer o);
        void removeObserver(Observer o);

        void notifyObservers();
    }

    public interface Observer {
        void update(float temp, float humidity, float pressure);
    }

    public interface DisplayElement {
        void display();
    }


  public class WeatherData : Subject
  {
      List<Observer> observers = new ArrayList<Observer>;
  }

  class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
