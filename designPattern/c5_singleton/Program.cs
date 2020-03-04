using System;

/*
The Singleton Pattern:

definition:
The Singleton Pattern ensures a class has only one instance, and provides a global point of access to it

lazy instantiation - singleton vs global variable/object:
global variable will be created and loaded once the app begins, even though it's not used, can affect performance
singleton can have lazy instantiation, only create the instance when first using it

multi-thread:
several options to make singleton thread safe(only create one instance in muti-threads):
- eagerly initialization, createt the instance when declare it(make it similar to global variable)
- lock the entire GetInstance() method, syncronization can lead to overhead
- lock with double check, can ahchive lazy initializatio and avoid synchornization overhead
QUES: - .net Lazy<T> data type?

*/
namespace c5_singleton
{
    /*
    Normal impelmentation of singleton class
    NOTE: It is multi-thread unsafe, if multi threads want to create
    Logger at same time, it may end up creating more than one instance
    */
    namespace normal {
        public class Logger {
            // NOTE: a private static instance of this class
            // the data type of the instance should be same as the class itself
            private static Logger logger;

            // NOTE: the constructor should be private, so outside class
            // cannot initial the instance with new() statement
            // can only create instance with member methods
            private Logger() {}

            // NOTE: a public static method to get instance
            // outside can only use this method to get instace
            public static Logger GetInstance() {
                // create new instance if it was null
                // else just return the previous instance
                if (logger == null) {
                    logger = new Logger();
                }

                return logger;
            }

            // can have other data members/methods which can be called 
            // using class instance
            public void PrintLogInfo() {
                Console.WriteLine("This is normal logger!");
            }
        }
    }

    /*
    NOTE: handle multi thread - initial the instance when declare it
    
    initial the instance when declare it, Using this approach, we rely on 
    the system to create the unique instance of the Singleton when the class 
    is loaded. The systm guarantees that the instance will be created before 
    any thread accesses the static instance variable.

    Problem: instance will be create when the app starts even though it is not
        used, can affect performance if the singleton instance is resource consuming
    */
    namespace multiThread1 {
        public class Logger {
            // NOTE: a private static instance of this class
            // initial the instance(new the instance) right away
            private static Logger logger = new Logger();


            // private constructor
            private Logger() {}

            // NOTE:just return the initialized instance
            public static Logger GetInstance() {

                return logger;
            }

            public void PrintLogInfo() {
                Console.WriteLine("This is eagerly initial logger!");
            }
        }
    }


    /*
    NOTE: handle multi thread - double check with lock/synchronization
    
    lock and synchronize the resource in GetInstance() method only for the first creation
    it achives lazy initialization, also avoid the overhead of synchronizing the entire function

    if lock the entire GetInstance() function, will do synchronization for each instance request,
    which leads to massive overhead
    */
    namespace multiThread2 {
        public class Logger {
            // NOTE: a private static instance of this class, without initialization
            private static Logger logger;


            // NOTE: a lock object that will be used to synchronize threads
            // during first access to the Singleton.
            private static readonly object _lock = new object();


            // private constructor
            private Logger() {}

            // NOTE: public static method to return instance
            public static Logger GetInstance() {
                // NOTE: first check, only lock and synchronize for the firs time(instance is null)
                //  if synchronize the entire function will cause overhead, because synchronize
                //  is time consuming
                if (logger == null) {
                    // lock the resource
                     // Now, imagine that the program has just been launched. Since
                    // there's no Singleton instance yet, multiple threads can
                    // simultaneously pass the previous conditional and reach this
                    // point almost at the same time. The first of them will acquire
                    // lock and will proceed further, while the rest will wait here.
                    lock (_lock) {
                        // NOTE: second check, for the threads waiting for the instance
                         // The first thread to acquire the lock, reaches this
                        // conditional, goes inside and creates the Singleton
                        // instance. Once it leaves the lock block, a thread that
                        // might have been waiting for the lock release may then
                        // enter this section. But since the Singleton field is
                        // already initialized, the thread won't create a new
                        // object.
                        if (logger == null) {
                            logger = new Logger();
                        }
                    }
                }

                return logger;
            }

            public void PrintLogInfo() {
                Console.WriteLine("This is lock logger!");
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            normal.Logger l0 = normal.Logger.GetInstance();
            l0.PrintLogInfo();

            multiThread1.Logger l1 = multiThread1.Logger.GetInstance();
            l1.PrintLogInfo();

            multiThread2.Logger l2 = multiThread2.Logger.GetInstance();
            l2.PrintLogInfo();
        }
    }
}
