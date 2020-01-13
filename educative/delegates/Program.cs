using System;

/*
NOTE: delegates, just like the pointer of function
        can contains methods, call the delegate will call the methods inside the delegate
        often used for events handling, can be passed as parameter
*/
namespace delegates // TODO: study namespace
{
    using System;

    // Define a custom delegate that has a string parameter and returns void.
    // NOTE: methods put into the delegate should have the same parameters and return type as the delegate
    delegate void Del(string s);

    class CustomerClass {

        /* take delegate as an parameter
        delegate can be used as callback function
        call the delegate after some operations, just like trigger an event
        */
        public void MethodWithCallBack(Del callback) {
            // do some operation
            string name = "tong";

            // call the delegate(callback) after some operation
            callback(name);
        }
    }

    class TestClass
    {
        // Define two methods that have the same signature as CustomDel.
        static void Hello(string s)
        {
            Console.WriteLine($"  Hello, {s}!"); // TODO: study string template
        }

        static void Goodbye(string s)
        {
            Console.WriteLine($"  Goodbye, {s}!");
        }

        public void HowAreYou(string s) 
        {
            Console.WriteLine($"  How are you, {s}!");
        }

        static void Main()
        {
            // Declare instances of the custom delegate.
            Del hiDel, byeDel, multiDel, multiMinusHiDel;

            // In this example, you can omit the custom delegate if you 
            // want to and use Action<string> instead.
            //Action<string> hiDel, byeDel, multiDel, multiMinusHiDel;

            // Create the delegate object hiDel that references the
            // method Hello.
            hiDel = TestClass.Hello; // NOTE: add static method into delegate

            // Create the delegate object byeDel that references the
            // method Goodbye.
            byeDel = Goodbye; // NOTE: can ignore the Class. because the main method is inside this class

            // The two delegates, hiDel and byeDel, are combined to 
            // form multiDel. 
            multiDel = hiDel + byeDel; // NOTE: multicast, put multiple methods into delegate

            TestClass tc = new TestClass();
            multiDel += tc.HowAreYou; // NOTE: can add non-static method -> need to create an class instance first
            

            // Remove hiDel from the multicast delegate, leaving byeDel,
            // which calls only the method Goodbye.
            multiMinusHiDel = multiDel - hiDel; // remove method from delegate

            Console.WriteLine("Invoking delegate hiDel:");
            hiDel("A"); // call delegate
            Console.WriteLine("Invoking delegate byeDel:");
            byeDel("B");
            Console.WriteLine("Invoking delegate multiDel:");
            multiDel("C");
            Console.WriteLine("Invoking delegate multiMinusHiDel:");
            multiMinusHiDel("D");

            // pass delegate as parameter
            Console.WriteLine("Pass delegate as parameter:");
            CustomerClass cc = new CustomerClass();
            cc.MethodWithCallBack(hiDel);
        }
    }
    /* Output:
    Invoking delegate hiDel:
    Hello, A!
    Invoking delegate byeDel:
    Goodbye, B!
    Invoking delegate multiDel:
    Hello, C!
    Goodbye, C!
    Invoking delegate multiMinusHiDel:
    Goodbye, D!
    */
}
