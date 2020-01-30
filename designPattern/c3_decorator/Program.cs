using System;

/*
NOTE: Decorator pattern

Definition: 
- The Decorator Pattern attaches additional responsibilities to an object dynamically.
Decorators provide a flexible alternative to subclassing for extending functionality.

A decoration is added to something to make it more attractive, in the same spirit, 
the decorator pattern adds new functionality to objects without modifying their defining classes.

The decorator pattern can be thought of as a wrapper or more formally a way to 
enhance or extend the behavior of an object dynamically. The pattern provides an 
alternative to subclassing when new functionality is desired.

The strategy is to wrap the existing object within a decorator object that usually 
implements the same interface as the wrapped object. This allows the decorator to invoke 
the methods on the wrapped object and then add any additional behavior. Usually, the decorator
adds behavior to the existing functionality of the wrapped object i.e. the decorator takes 
action either before or after invoking some method on the wrapped object.

Key points:
- Decorators have the same supertype as the objects they decorate.
- You can use one or more decorators to wrap an object.
- Given that the decorator has the same supertype as the object it decorates, we can pass
around a decorated object in place of the original (wrapped) object.
- The decorator adds its own behavior either before and/or after delegating to the object it
decorates to do the rest of the job.
- Objects can be decorated at any time, so we can decorate objects dynamically at runtime
with as many decorators as we like.

- decorator extends/impelements from wrapped class(decrorated class) -> ensure to have same super type, will have same methods as wrapped class
- decorator has an instance (eg, member) of wrapped class as data member -> can get behaviors from composition (like recursion, 套娃)
- decorator calls the bahavior functions of data member(decorated class), then decorate it with some new behaviors
    eg, testFun(){member.testFun() + some new behaviors} 
- besides the existed methods, decorators can also add new behaviors(methods)

Pros:
- reating flexible designs and staying true to the Open-Closed Principle 
    open to extension (add new codes):
        we can add new functionlities by adding new operations on new decorators
    close to change (modify existed codes):
        by adding decorator, we don't need to modify the existed classes, just need to add operations on the decorator
- we can usually insert decorators transparently and the client never has to know it’s 
    dealing with a decorator because they have same supertype and interface
- we can add decorator at runtime which makes program more flexible


Cons:
- we may end up with too many classes as the number of decorators grows.
- sometimes can be hard to understand the code
- make instantiation more difficult, need to wrap classes layer by layer, like Java I/O
QUES: have problem if codes are dependent on specific types?
    if we want to take a specific action based on the concrete type of the plane,
    we may not be able to do so. Once the concrete object is wrapped inside a 
    decorator the reference to the object is through the abstract type and not 
    the concrete type anymore.

Example:
Java I/O classes: eg, FileInputStream, BudfferedInputStream, LineNumberInputStream...
*/
namespace c3_decorator
{
    // an interface component that needs to be decorated
    // NOTE: pinciple -> program to interface
    public interface Beverage {
        string GetDescription();

        double GetCost();
    }

    // concrete classes that implements the component
    public class Espresso: Beverage {
        public string GetDescription() {
            return "Espresso";
        }

        public double GetCost() {
            return 1.99;
        }
    }

    public class Latte: Beverage {
        public string GetDescription() {
            return "Latte";
        }

        public double GetCost() {
            return 0.89;
        }
    }

    /* An abstract decorator class that implements the component interface
    The decorator pattern requires an abstract decorator class that 
    implements the abstract interface for the object being wrapped.
    NOTE: the decorator class has same super type as decorated class
    QUES: decorator must have an abstract class?
    */
    public abstract class CondimentDecorator: Beverage {
        // need to implement the method, but can declare it as abstract method,
        // so that we don't need to write actual implementation
        // any concrete decorator extends this class needs to implement the method
        public abstract string GetDescription(); 

        public abstract double GetCost();
    }


    // concrete decorators that implements the abstract decorator class
    // NOTE: the concrete decorator has same super class type as the decorated class
    public class Mocha: CondimentDecorator {
        // NOTE: has the decorated(wrapped) compoment as data member
        // so that we can call the method of the wrapped component
        // it has the same super type as this decorator
        protected Beverage beverage;

        // NOTE: initial the wrapped component in constructor
        public Mocha(Beverage beverage) {
            this.beverage = beverage;
        }

        // NOTE: implement the methods, invoke the same method in the wrapped compoment,
        // then do some additional operations -> like a recursion
        // we can extends the functionality of the wrapped component by adding additional operations
        public override string GetDescription() {
            return beverage.GetDescription() + ", Mocha";
        }

        public override double GetCost() {
            return beverage.GetCost() + 0.20;
        }
    }

    public class Chocolate: CondimentDecorator {
        protected Beverage beverage;

        public Chocolate(Beverage beverage) {
            this.beverage = beverage;
        }

        public override string GetDescription() {
            return beverage.GetDescription() + ", Chocolate";
        }

        public override double GetCost() {
            return beverage.GetCost() + 0.15;
        }
    }

    
    class Program
    {
        static void Main(string[] args)
        {
            Beverage b1 = new Espresso();
            Console.WriteLine($"beverage: {b1.GetDescription()}, {b1.GetCost()}");

            Beverage b2 = new Latte(); // create an instance that needs decoration
            b2 = new Mocha(b2); // NOTE: decorate the instance by wrapping it into a decoretor class
            b2 = new Chocolate(b2); // they all have the the same supertype -> Beverage
            Console.WriteLine($"beverage: {b2.GetDescription()}, {b2.GetCost()}");
        }
    }
}
