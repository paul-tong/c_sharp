using System;

/*
Abstract Factory Pattern:
that Abstract Factory allows a client to use an abstract interface to create 
a set of related products without knowing (or caring) about the concrete products that
are actually produced. In this way, the client is decoupled from any of the 
specifics of the concrete products

Abstract Factory relies on object composition: object creation is implemented 
in methods exposed in the factory interface. Class that consumes the factory needs
to have an factory instance.

The intent of Abstract Factory is to create families of related products without 
having to depend on their concrete classes. Each product should have an abstract super class.

All factory patterns promote loose coupling by reducing the dependency of your 
application on concrete classes. 
NOTE: factory patterns enhench princples -> program to interface/abstraction, 
      loosely coupled, and Dependcy Inversion

- Simple factory:
seperate object intantiationg in another class. The Simple Factory isn’t 
actually a Design Pattern; it’s more of a programming idiom.

- Factory Method:
has abstract method to create object, depends on extends,
subclass implements abstract method to create concrete object

- Abstrat Factory:
like simple factory, but has an abstract factory to explose all creation methods
    then has concrete factory to implement methods to create concrete objects
involve the facotry method concepts, basically each abstract method in the facotry
    interface is a factory method, because it also needs subclass to implement creation

*/
namespace abstractFactory
{

    // NOTE: an abstract factory, provide interface to create bunch of related products
    public interface PizzaIngredientFactory {

        // each method is a abstract method, the subclass needs to create concrete product
        // NOTE: it is quite similar to Factory Method
        string CreateDough(); 

        string CreateSauce();
    }

    // NOTE: concrete class to implement factory interface, crate concrete products
    public class NYPizzaIngredientFactory: PizzaIngredientFactory {
        public string CreateDough() { // create product, the data type should be a abstract class
            return "NY dough";        // or interface; just use string here to simplify the code
        }

        public string CreateSauce() {
            return "NY sauce";
        }
    }

    public class CAPizzaIngredientFactory: PizzaIngredientFactory {
        public string CreateDough() {
            return "CA dough";
        }

        public string CreateSauce() {
            return "CA sauce";
        }
    }

    // a client to consume the factory
    // NOTE: this is an abstract class (program to interface principle)
    public abstract class Pizza {
        protected string name;
        protected string dough;
        protected string sauce;

        public abstract void AddGredient();

        public void Cut() {
            Console.WriteLine("Cutting the pizza to slices");
        }
    }

    // NOTE: concrete class that utilize factory to build products
    public class VeggiPizza: Pizza {

        // NOTE: has a factory instance, data type is abstract factory
        // note concrete factory, thus it is decoupled with concrete class
        private PizzaIngredientFactory factory;

        // NOTE: assign factory in constructor
        // can dynamically assign factory in runtime, make program more flexible
        public VeggiPizza(PizzaIngredientFactory f) {
            name = "Viggi Pizza";
            factory = f;
        }

        // NOTE: use factory to create concrete bunch of products
        // to be loosely coupled, the dough and sauce should have abstract data type
        // (in this example, just all use string data type)
        public override void AddGredient() {
            dough = factory.CreateDough();
            sauce = factory.CreateSauce();
            
            Console.WriteLine("{0}, \nAdding ingredients: {1}, {2}", name, dough, sauce);
        }
    }

    public class MeatPizza: Pizza {
        private PizzaIngredientFactory factory;

        public MeatPizza(PizzaIngredientFactory f) {
            name = "Meat Pizza";
            factory = f;
        }

        public override void AddGredient() {
            dough = factory.CreateDough();
            sauce = factory.CreateSauce();

            Console.WriteLine("{0}, \nAdding ingredients: {1}, {2}", name, dough, sauce);
        }
    }


    /* NOTE: Pizza store to create pizza -> it is unrelated to the abstract factory pattern,
             thus command it out to make the code easier to understand
    */
    // public abstract class PizzaStore {
    //     public void orderPizza(string type) {
    //         Pizza p = CreatePizza(type);

    //         p.AddGredient();
    //         p.Cut();
    //     }

    //     protected abstract Pizza CreatePizza(string type);
    // }

    // public class NYPizzaStore: PizzaStore {
    //     protected override Pizza CreatePizza(string type) {
    //         PizzaIngredientFactory factory = new NYPizzaIngredientFactory();

    //         switch(type) {
    //             case "veggi":
    //                 return new VeggiPizza(factory);
    //             case "meat":
    //                 return new MeatPizza(factory);
    //             default:
    //                 return null;
    //         }
    //     }
    // }

    // public class CAPizzaStore: PizzaStore {
    //     protected override Pizza CreatePizza(string type) {
    //         PizzaIngredientFactory factory = new CAPizzaIngredientFactory();

    //         switch(type) {
    //             case "veggi":
    //                 return new VeggiPizza(factory);
    //             case "meat":
    //                 return new MeatPizza(factory);
    //             default:
    //                 return null;
    //         }
    //     }
    // }    

    class Program
    {
        static void Main(string[] args)
        {
            // PizzaStore nyStore = new NYPizzaStore();
            // nyStore.orderPizza("veggi");

            // PizzaStore caStore = new CAPizzaStore();
            // caStore.orderPizza("meat");


            // create concrete factory (data type is abstract class)
            // pass the factory to the object that cosumes the factory
            PizzaIngredientFactory cf = new CAPizzaIngredientFactory();
            Pizza cp = new VeggiPizza(cf);
            cp.AddGredient();
            cp.Cut();


            PizzaIngredientFactory nf = new CAPizzaIngredientFactory();
            Pizza np = new VeggiPizza(nf);
            np.AddGredient();
            np.Cut();            
        }
    }
}
