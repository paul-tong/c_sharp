using System;

/*
NOTE: Strategy Pattern:
defines a family of algorithms, encapsulates each one, and makes them interchangeable.
Strategy lets the algorithm vary independently from clients that use it
*/
namespace c1_intro_strategy {

    /*
    NOTE: design principle -> dentify the aspects of your application that vary 
        and separate them from what stays the same.
    Encapsulate behaviors/algrithms in seperate class
    Because these behaviors may change frequently, we need to
    let them independent from the clients that use them
    */
    // NOTE: Design principle-> program to interface, instead of implementation
    // provide interface of this behavior
    public interface FlyBehavior { 
        void Fly();
    }

    // implement the behavior, can have different implementations
    // whenever new requirement added, we can simply creat a new class
    // that implement the interface
    public class FlyWithWings: FlyBehavior {
        public void Fly() {
            Console.WriteLine("I am flying with wings!");
        }
    }

    public class FlyNoWay: FlyBehavior {
        public void Fly() {
            Console.WriteLine("Sorry, I cann't fly!");
        }
    }

   public class FlyWithRocket: FlyBehavior {
        public void Fly() {
            Console.WriteLine("I am flying with rocket!");
        }
    }
    


    /*
    The abstract Client that composites the behaviors
    It is relatively unchanged (remain the same)
    It is an abstract class:
    -it contains the behavior as data member, the behavior is an interface,  
       we need to specify the specific class of the behavior in the specific client
    - it can contain some impelmented common methods
    - it can contain some abstract common methods, that need to be impelmened by subclass
    */
    public abstract class Duck {
        // composite the behavior as a data member
        // NOTE: design principle -> prefer composition(HAS A) to inheritence(IS A)
        // NOTE: design Principle -> program to interface instead of implementation. 
        //      data type should be the interface, instead of specific class
        protected FlyBehavior fb;

        // NOTE: design principle -> code open to extenstion ,close to change
        //  method to set the behavior, so we can modify it in the runtime
        //  make the program more flexible, extendable
        public void SetFlyBehavior(FlyBehavior fb) {
            this.fb = fb;
        }

        // a public method that invokes function inside the behavior
        // it doesn't need to know the actual impelmentation, and 
        // doesn't need to know the actual class type of FlyBehavior
        public void PerformFly() {
            fb.Fly();
        }

        // an implemented method that can be directly used by subclass
        public void Swim() {
            Console.WriteLine("I am swimming");
        }

        // an abstract method that needs to be overriden by subclass
        public abstract void Display();
    }

    /*
    A specific Client that inherites from the abstract client
    it should have specific class for the behaviors
    */
    public class MallardDuck: Duck {
        // specify the class of behavior
        public MallardDuck() {
            fb = new FlyWithWings();
        }

        // override the abstract methods
        public override void Display() {
            Console.WriteLine("I am a Mallard Duck...");
        }
    }

    public class RubberDuck: Duck {
        public RubberDuck() {
            fb = new FlyNoWay();
        }

        public override void Display() {
            Console.WriteLine("I am a Rubber Duck...");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Duck d1 = new MallardDuck(); // create a new duck ,data type is abstract class
            d1.Display();
            d1.Swim();
            d1.PerformFly();

            Duck d2 = new RubberDuck();
            d2.Display();
            d2.Swim();
            d2.PerformFly();
            d2.SetFlyBehavior(new FlyWithRocket()); // change the fly behavior at run time
            d2.PerformFly();
        }
    }
}
