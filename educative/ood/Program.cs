using System;

/*
NOTE: static class
all the methods, members in side the class need to be static
cannot create instance for the static class 
only have one copy for the members of this class (eg, A modify AClass.age, B get AClass.age will also be changed)

NOTE: Access Modifier 
url: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/access-modifiers

public
The type or member can be accessed by any other code in the same assembly or another assembly that references it.
QUES: what is assembly? namespace? or like packege in java?

private
The type or member can be accessed only by code in the same class or struct.

protected
The type or member can be accessed only by code in the same class, or in a class that is derived from that class.

internal(like default in Java)
The type or member can be accessed by any code in the same assembly, but not from another assembly.

protected internal (protected + internal)
The type or member can be accessed by any code in the assembly in which it is declared, or from within a derived class in another assembly.

private protected 
The type or member can be accessed only within its declaring assembly, by code in the same class or in a type that is derived from that class.
QUES: private + pretected + internal?


- class/struct - directly within namespace, not nested
can be public or internal, don't have private and protect (which only valid for members inside the class/struct)
default is internal

- class member(include nested class/struct)
has all 6 access modifiers
default is private

- struct member(include nested class/struct)
don't have protected related modifier (because struct cannot be derived)
has all other 4 access modifiers
default is private

- interface
interface need to declared direclty within a namespace
can be public or internal like class, default is internal
interface members are always public, and no access modifiers can be applied

- Enumeration
members are always public, and no access modifiers can be applied

- Delegate
Delegates behave like classes and structs. 
when declared directly within namespace, is internal by default
when nested, has private access by default
QUES: what is Delegate?

note: 
- derived class cannot have greater accsibility than base class
- struct members doesn't have protected modifier, because it cannot be derived

*/
namespace ood
{

    // class: member, method, property, virtual method/override, hide method/new
    class Car {

        // a public field
        public string Brand;

        // a protected field, accessable to derived classes
        protected int Price = 1000;

        // a private field, with set and get methods, same as java
        private string model;

        public string GetModel() {
            return model;
        }

        public void SetModel(String model) {
            this.model = model;
        }

        // a private field, with propertiy to get or set its value
        // NOTE: A property is a member that provides a flexible mechanism to read, write, or compute the value of a private field. 
        private int _year; // NOTE: back field for property name convention: _camelCase

        /*
        NOTE: Property
        A property is a member that provides a flexible mechanism to read, write, 
        or compute the value of a private field. Properties can be used as if 
        they are public data members, but they are actually special methods called accessors. 
        */

        // property used as accessor method: to get/ set value of a private field
        public int Year {
            get {
                return _year;
            }

            set {
                _year = value; // NOTE: value is the keyword for set
            }
        }

        // NOTE: property used as public data member
        // basicly same as public data member, eg, public int Mile
        public int Mile { get; set; } // can read, write value
        public string Color { get; } // read only: can only get value

        // a public method (need to be hidden if need to overriden in derived class)
        public void SayHello() {
            Console.WriteLine("I am car");
        }

        /* NOTE: a public method need to be override in drived class
        must be virtual so that it can be overriden
        it has implementation(not abstruct class, which has no implementation)
        */
        public virtual void SayHelloVirtual() {
            Console.WriteLine("I am car virtual");
        }

        // constructor, same as java
        public Car() { 
            Console.WriteLine("car constructor1");
        }

        public Car(String brand) {
            this.Brand = brand;
            Console.WriteLine("car constructor2");
        }

        // destructor, same as java, called automaticlly
        // is not necessary
        ~Car(){
            Console.WriteLine("car class destructor");
        }
    }


    // inheritance (extends the car class)
    class Toyota: Car {
        /*
        NOTE: will automatically call Car's constructor(no parameters) first
        if all Car's constructor needs parameter, it will have error
        */
        // public Toyota() {
        //     Console.WriteLine("toyota constructor1");
        // }

        /*
        NOTE: explictly call base class's construcor with base(arguments)
        */
        public Toyota(): base("Toyota") {
            Console.WriteLine("toyota constructor2");
        }

        // add new method, and access to base class's protected field
        public int GetPrice() {
            return Price;
        }

        /* NOTE: cannot override base class's non-virual method -> will have warning
           but can use new keyword to hide base class's method
        */
        public new void SayHello() {
            Console.WriteLine("I am Toyota");
        }

        // NOTE: override a virtural method, need to have override keyword -> will have warning
        public override void SayHelloVirtual() {
            Console.WriteLine("I am Toyota virtual");
        }
    }

    /* NOTE: struct
    - Basically has the same syntax as class
    - are light version of classes
    - instances of structs are values while instancs of classes are refereces
    */
    public struct Point
    {
        public double X, Y;

        public Point(double pointX, double pointY)
        {
            X = pointX;
            Y = pointY;
        }

        // QUES: public methods and fields start with Capital letter?
        public void PrintPoint() {
            Console.WriteLine("x: {0}, y: {1}", X, Y);
        }
    }


    // interface
    interface Animal {
        // NOTE: can't have access modifier, automatically be public
        void MakeSound(); // has the same method as Pet interface

        void EatFood();
    }

    interface Pet {
        void MakeSound();

        void GetPrice();
    }

    class Dog: Animal, Pet {
        /* NOTE: implement method from interface, must be public
         don’t need explicit implementations if multiple interfaces 
         share the same method, but a common implementation is acceptable
         will call this method if instance is created by: Dog d = new Dog()
        */
        public void MakeSound() {
            Console.WriteLine("Dog, Wow");
        }

        // NOTE: explixitly implement common methods in multiple interface
        // will call this method if instance is created by: Animal a = new Dog()
        // cannot add public modifier or it will have error(though it is default to be public)
        void Animal.MakeSound() {
            Console.WriteLine("Animal, Wow");
        }

        // will call this method if instance is created by: Pet p = new Dog()
        void Pet.MakeSound() {
            Console.WriteLine("Pet, Wow");
        }

        // need to impelment all methods in the interfaces
        public void EatFood() {
            Console.WriteLine("dog eat meat");
        }

        public void GetPrice() {
            Console.WriteLine("dog price is 2200");
        }
    }

    /* NOTE: abstract class: a class that has abstract method, cannot be initalized
        The purpose of an abstract class is to provide a common definition of a base class that multiple derived classes can share. 
      abstract method vs virtual method
        virtual method is inside a normal class, has implementation, derived class can override it(but not mendatory)
        abstract method is inside a abstract class, has no implementation, derived class must implement it(or the derived class will also be abstract class)
      abstract class vs interface
        can only extends one abstract class, can implement multiple interface
        abstract class has at least one abstract method, all the methods in interface has no implementation
        abstract class cannot be initalized, eg, cannot new AbstractClass(). QUES: can be used as type? -> yes
        same as abstract class, interface cannot be initalized, but can be used as type, eg, List<String> l = new ArrayList<>()
    */
    abstract class Food {
        public string price = "22.2";

        // a abstract method(no implementation)
        public abstract void FoodType();

        // a normal method shared by all derived class
        public void FoodSayHello() {
            Console.WriteLine("This is Food!");
        }
    }

    // class extends food
    class Apple: Food {
        // must override abstract method
        public override void FoodType() {
            Console.WriteLine("Food type is fruit");
        }

        // define new methods besides base class
        public void GetPrice() {
            Console.WriteLine("Food price is 22");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Car c1 = new Car("toyota");
            
            // directly access public field
            Console.WriteLine("brand: {0}", c1.Brand);

            // access private filed through get/set
            c1.SetModel("t22");
            Console.WriteLine("model: {0}", c1.GetModel());

            // access private field through property
            c1.Year = 2020;
            Console.WriteLine("year: {0}", c1.Year);
            
            // create struct instance
            Point p1 = new Point(1.2, 2.3);
            p1.PrintPoint();

            // inheritance
            Toyota t1 = new Toyota();
            t1.SayHello();
            t1.SayHelloVirtual();
            Console.WriteLine("price: " + t1.GetPrice());

            // interface
            // Animal a1 = new Animal(); // cannot create instance of interface
            Dog d1 = new Dog();
            Animal a1 = new Dog();
            Pet pet1 = new Dog();
            d1.MakeSound(); // call different impelmentation of the same method
            a1.MakeSound();
            pet1.MakeSound();


            // abstract
            // Food f1 = new Food(); // cannot create instance of abstract class
            Food f1 = new Apple();
            f1.FoodSayHello();
            f1.FoodType();
            //f1.GetPrice(); // type is Food, cannot call method that is new defined in Apple

            Apple apple1 = new Apple();
            apple1.GetPrice();
            
        }
    }
}
