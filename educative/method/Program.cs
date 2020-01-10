using System;

/*
NOTE: method notes

- Method template
AccessModifier OptionalModifier ReturnType MethodName(InputParameters)
{
 //Method body
}

- AccessModifier can be public, protected, private or by default internal.

- OptionalModifier can be static, abstract, virtual, override, new or sealed.

- ReturnType can be void for no return or can be any type from the basic ones, as int to complex classes.

QUES:what is assembly -> a c# project?

- Method Access and Optional modifier example
// static: is callable on a class even when no instance of the class has been created
public static void MyMethod()
  
// virtual: can be called or overridden in an inherited class
public virtual void MyMethod()
  
// internal: access is limited within the current assembly
internal void MyMethod()
  
//private: access is limited only within the same class
private void MyMethod()
  
//public: access right from every class / assembly
public void MyMethod()
  
//protected: access is limited to the containing class or types derived from it
protected void MyMethod()
  
//protected internal: access is limited to the current assembly or types derived from the containing class.
protected internal void MyMethod()


- Parameters
can have default values (eg, int age = 22)
*/


namespace method
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();

            // NOTE: method with default value
            p.sayHello("tong", 11);
            p.sayHello("peng");

            // NOTE: pass by value and reference
            int num1 = 11;
            int num2 = 11; // num2 is changed because we pass its reference to function
            p.changeValue(num1, ref num2);
            Console.WriteLine("num1: {0}, num2: {1}", num1, num2);

            // NOTE: array as parameter are passing its reference
            // even though we didn't explictly pass it as ref
            int[] arr1 = new int[]{1};
            p.changeArrayValue(arr1);
            Console.WriteLine(arr1[0]);

            // NOTE: method overloading, methods with same name but has different
            // - Number of Arguments or Type of arguments
            // can have different Return Type, but if only has diffrent return type
            //   and have exactly same parameters is not allowed (cannot diffirention them when calling it)
            Console.WriteLine(Area(2));
            Console.WriteLine(Area(2.0));

            // recursion
            Console.WriteLine(Factorial(4));
        }

        // age has default value
        public void sayHello(String name, int age = 22) {
            Console.WriteLine("hello " + name + "! You are: " + age);
        }

        // pass by value and reference
        public void changeValue(int num1, ref int num2) {
            num1 = 22;
            num2 = 22;
        }

        // change array's value
        public void changeArrayValue(int[] arr) {
            arr[0] = 22;
        }

        // methods overloading
         public static string Area(int value1) //computing area of square
        {
            return String.Format("Area of Square is {0}", value1 * value1); 
        }
        public static double Area(double value1) //computing area of circle
        {
            return 3.14 * Math.Pow(value1,2); //using Pow to calculate the power of 2 of value1
        }
        public static string Area(double value1, double value2) //computing area of rectangle 
        {
            return String.Format("Area of Rectangle is {0}", value1 * value2);
        }

        // NOTE: recursion
        public static int Factorial(int number)
        {
            if(number == 1 || number == 0) // if number equals 1 or 0 we return 1
            {
                return 1;
            }
            else
            {
                return number*Factorial(number-1); //recursively calling the function if n is other then 1 or 0
            }
        }

    }
}
