using System;

/*
The Factory Method Pattern:
Instead of directly using NEW to create an object, the Abstract 
creator delares an abstract method to create object, then
use behaviors of the object; Concrete creater extends the abstract 
creator, implement the abstract method to create concrete object.

Factory Method relies on inheritance: object creation is delegated 
to subclasses which implement the factory method to create objects.

The intent of Factory Method is to allow a class to defer
instantiation to its subclasses. So we can promote loose coupling 
by reducing the dependency of our application on concrete classes
*/
namespace factoryMethod
{
    // pizza store is an abstract class, it has an abstract method to create pizza
    // it doesn't care about what type of the pizza it can get from creating method
    // it doesn't know how to create pizza, defer the piazza creation to its subclass
    public abstract class PizzaStore {
        public Pizza OrderPizza(string type) {
            // instead of using new Piazza(), use an abstract method to create piazza
            // NOTE: Pizza is an interface/abstract class
            Pizza pizza = createPizza(type);

            // NOTE: make use of the abstract pizza, just need to know which
            // behaviors it support, dosen't need to know the concrete type of the pizza
            pizza.prepare();
            pizza.cut();

            return pizza;
        }

        // NOTE: abstract method
        // an abstract method to create piazza, the store has no idea about what
        // concrete pizza it will get, it defers the creating of pizza to its subclass
        public abstract Pizza createPizza(string type);
    }

    // NOTE: concrete class extends abstract class,
    // implement abstract method to create concrete pizza
    // different store can create different pizza
    // NOTE: concrete store create concrete pizza (though the data type of pizza is still abstract)
    public class NYPizzaStore: PizzaStore {
        // implement abstract method to create concrete pizza
        public override Pizza createPizza(string type) {
            switch(type) {
                case "cheese": 
                    return new NYStyleCheesePizza();
                case "veggie": 
                    return new NYStyleVeggiePizza();
                default: 
                    return null;
            }
        }
    }

    public class CAPizzaStore: PizzaStore {
        public override Pizza createPizza(string type) {
            switch(type) {
                case "cheese": 
                    return new CAStyleCheesePizza();
                case "veggie": 
                    return new CAStyleVeggiePizza();
                default: 
                    return null;
            }
        }
    }    


    // abstract class to represent the product
    public abstract class Pizza {
        protected string name;

        public void prepare() {
            Console.WriteLine("Preparing {0} ...", name);
        }

        public abstract void cut();
    }

    // concrete classes extends the product with some different impelmentations
    public class NYStyleCheesePizza: Pizza {
        public NYStyleCheesePizza() {
            this.name = "NY style cheese pizza";
        }

        // different concrete class may implement the method differently
        public override void cut() {
            Console.WriteLine("Cut pizza into round pieces");
        }
    }

    public class NYStyleVeggiePizza: Pizza {
        public NYStyleVeggiePizza() {
            this.name = "NY style Veggie pizza";
        }

        public override void cut() {
            Console.WriteLine("Cut pizza into round pieces");
        }
    }    

    public class CAStyleCheesePizza: Pizza {
        public CAStyleCheesePizza() {
            this.name = "CA style cheese pizza";
        }

        public override void cut() {
            Console.WriteLine("Cut pizza into square pieces");
        }
    }

    public class CAStyleVeggiePizza: Pizza {
        public CAStyleVeggiePizza() {
            this.name = "CA style Veggie pizza";
        }

        public override void cut() {
            Console.WriteLine("Cut pizza into square pieces");
        }
    }  


    class Program
    {
        static void Main(string[] args)
        {
            // create different stores
            PizzaStore nyStore = new NYPizzaStore();
            nyStore.OrderPizza("cheese");

            PizzaStore caStore = new CAPizzaStore();
            caStore.OrderPizza("veggie");
        }
    }
}
