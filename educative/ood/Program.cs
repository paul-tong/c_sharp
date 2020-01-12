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

    class Car {

        // a public field
        public string brand;


        // a private field, with set and get methods, same as java
        private string model;

        public string getModel() {
            return model;
        }

        public void setModel(String model) {
            this.model = model;
        }



        // a private field, with propertiy to get or set its value
        // NOTE: A property is a member that provides a flexible mechanism to read, write, or compute the value of a private field. 
        private int year;

        // property to get/ set value of a private field
        public int Year {
            get {
                return year;
            }

            set {
                year = value; // NOTE: value is the keyword for set
            }
        }


        // constructor, same as java
        public Car(String brand) {
            this.brand = brand;
        }

        // destructor, same as java, called automaticlly
        // is not necessary
        ~Car(){
            Console.WriteLine("car class destructor");
        }
    }


    /* NOTE: struct
    - Basically has the same syntax as class
    - are light version of classes
    - instances of structs are values while instancs of classes are refereces
    */
    public struct Point
    {
        public double x, y;

        public Point(double pointX, double pointY)
        {
            x = pointX;
            y = pointY;
        }

        // QUES: public methods and fields start with Capital letter?
        public void PrintPoint() {
            Console.WriteLine("x: {0}, y: {1}", x, y);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Car c1 = new Car("toyota");
            
            // directly access public field
            Console.WriteLine("brand: {0}", c1.brand);

            // access private filed through get/set
            c1.setModel("t22");
            Console.WriteLine("model: {0}", c1.getModel());

            // access private field through property
            c1.Year = 2020;
            Console.WriteLine("year: {0}", c1.Year);
            
            // create struct instance
            Point p1 = new Point(1.2, 2.3);
            p1.PrintPoint();
        }
    }
}
