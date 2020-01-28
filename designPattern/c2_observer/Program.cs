using System;
using System.Collections.Generic;


/*
NOTE: The Observer Pattern defines a one-to-many dependency between objects so that when one
object changes state, all of its dependents are notified and updated automatically
- subject and observers are ONE to MANY relationship
    subject has a list of observers as data member
    observer has a subject as data member
- real life example:
    news subscriber(observers) get nodification from publisher(subject) when breaking news come out
*/
namespace c2_observer
{
    // NOTE: principle -> program to interface
    //  subject interface that declares behaviors of subject
    public interface Subject {
        void RegisterObserver(Observer o); // add an observer
        void RemoveObserver(Observer o); // remove an observer

        void NotifyObservers(); // notify changes to all observers
    }


    //  Observer interface that declares behaviors of observer
    public interface Observer {
        void Update(float temp, float humidity, float pressure);
    }

    // an interface that declares other behaviors of observer
    // not directly related to Observer Pattern ,just to follow the 
    // 'program to interface' pinciple
    public interface DisplayElement {
        void Display();
    }


  // specific class that implements the subject interface
  public class WeatherData : Subject
  {
       // NOTE: one to many relationship
      //    subject has list of observers as data member
      // NOTE: principle -> loose coupling
      //    the data type of observer is an interface, thus the subject
      //    doesn't need to know any implemenation details except the interface behaviors
      private List<Observer> observers = new List<Observer>();

      private float temp;
      private float humidity;
      private float pressure;

      public void RegisterObserver(Observer o) {
          observers.Add(o);
      }

      public void RemoveObserver(Observer o) {
          int i = observers.IndexOf(o);
          if (i >= 0) {
              observers.RemoveAt(i);
          }
      }

      // notify users the newest change, send the data to observer
      public void NotifyObservers() {
          foreach (Observer o in observers) {
              o.Update(temp, humidity, pressure); // call observer to update
          }
      }

      // notify observers when data changed
      public void MeasurementsChanged() {
          NotifyObservers();
      }

      public void SetMeasurements(float temp, float humidity, float pressure) {
          this.temp = temp;
          this.humidity = humidity;
          this.pressure = pressure;

          MeasurementsChanged();
      }
  }

  // specific class that implements the observer interface
  public class CurrentConditionsDisplay: Observer, DisplayElement {
      // NOTE: one to many relationship
      //    oberser has a subject as data member
      // NOTE: principle -> loose coupling
      //    the data type of subject is an interface, thus the observer
      //    doesn't need to know any implemenation details except the interface behaviors
      // QUES: why need the subject data member in this observer?
      //    can invoke the subject to remove this observer
      //    can request to pull data from subject. besides waiting for the notification(push) from subject
      private Subject weatherData;

      private float temp;
      private float humidity;
      private float pressure;


      // create the observer, register the observer to the subject
      public CurrentConditionsDisplay(WeatherData w) {
          weatherData = w;
          weatherData.RegisterObserver(this); // register this observer to the weatherData subject
      }

    
      // update function which will be invocated by subject
      // do something when the subject notify change to this observer
      public void Update(float temp, float humidity, float pressure) {
          this.temp = temp;
          this.humidity = humidity;
          this.pressure = pressure;

          // do something to react to the change
          Display();
      }

      public void Display() {
          Console.WriteLine($"Current Condition Display: temp {temp}, humidity {humidity}, presure {pressure}");
      }
  }

  // specific class that implements the observer interface
  public class ForecastDisplay: Observer, DisplayElement {
      private Subject weatherData;

      private float temp;
      private float humidity;
      private float pressure;

      public ForecastDisplay(WeatherData w) {
          weatherData = w;
          weatherData.RegisterObserver(this); // register this observer to the weatherData subject
      }

      public void Update(float temp, float humidity, float pressure) {
          this.temp = temp;
          this.humidity = humidity;
          this.pressure = pressure;

          Display();
      }

      public void Display() {
          Console.WriteLine($"Forecast Display: temp {temp + 1}, humidity {humidity + 1}, presure {pressure + 1}");
      }
  }
  class Program
    {
        static void Main(string[] args)
        {
            // create subject and observers, register observers
            WeatherData w = new WeatherData();
            CurrentConditionsDisplay cd = new CurrentConditionsDisplay(w);
            ForecastDisplay fd = new ForecastDisplay(w);

            // change data in subject, notify observers changes
            w.SetMeasurements(1, 2 , 3);

            // remove a observer from subject
            w.RemoveObserver(cd);
            w.SetMeasurements(5, 6, 7);
        }
    }
}
