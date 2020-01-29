using System;

/*
NOTE: Decorator pattern

Definition: 
- The Decorator Pattern attaches additional responsibilities to an object dynamically.
Decorators provide a flexible alternative to subclassing for extending functionality.

Key points:
- Decorators have the same supertype as the objects they decorate.
- You can use one or more decorators to wrap an object.
- Given that the decorator has the same supertype as the object it decorates, we can pass
around a decorated object in place of the original (wrapped) object.
- The decorator adds its own behavior either before and/or after delegating to the object it
decorates to do the rest of the job.
- Objects can be decorated at any time, so we can decorate objects dynamically at runtime
with as many decorators as we like.

- decorator extends/impelements from main class(decrorated class) -> ensure to have same class type, will have same methods as main class
- decorator has an instance (eg, member) of main class as data member -> can get behaviors from composition (like recursion, 套娃)
- decorator calls the bahavior functions of data member(decorated class), then decorate it with some new behaviors
    eg, testFun(){member.testFun() + some new behaviors} 
- can decorate class with addition new behaviors(methods)

Pros:
- reating flexible designs and staying true to the Open-Closed Principle (open to extension, close to change existed codes)
- you can usually insert decorators transparently and 
    the client never has to know it’s dealing with a decorator

Cons:
- sometimes can be hard to understand
- make instantiation more difficult
QUES: have problem if codes are dependent on specific types?

Example:
Java I/O classes: eg, FileInputStream, BudfferedInputStream, LineNumberInputStream...
*/
namespace c3_decorator
{
    public abstract class Beverage {
        protected string description = "Unkown Beverage";

        public string GetDescription() {
            return description;
        }

        public abstract double GetCost();
    }

    public class Espresso: Beverage {
        public Espresso () {
            description = "Espresso";
        }

        public override double GetCost() {
            return 1.99;
        }
    }

    public class Latte: Beverage {
        public Latte() {
            description = "Latte";
        }

        public override double GetCost() {
            return 0.89;
        }
    }

    public abstract class CondimentDecorator: Beverage {
        public new abstract string GetDescription();
    }


    public class Mocha: CondimentDecorator {
        protected Beverage beverage;

        public Mocha(Beverage beverage) {
            this.beverage = beverage;
        }

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
            Console.WriteLine($"beverage: {b1.GetDescription()}, ${b1.GetCost()}");
        }
    }
}
