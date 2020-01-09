/*
 using namespace, so we can use System.Console.println() 
 as Console.println() instead of 'System.COnsole.println()'
 Build prject under a folder: dotnet new console
 Run program: dotnet run
 */
using System; // has `;`, case sensetive

// Program start class
class Name
{
    /*
      Main begins program execution.
      normally: Can only has one Main class in the folder
      you can have multiple main methods, but need to specify
      which one to use when running the program
     */ 
    static void Main() // class and method starts with upper case
    {
      // Write to console
      Console.WriteLine("Please enter your name:");

      // Read from console
      string name = Console.ReadLine(); // string is small case?
      int age = 22;

      // writing the string and additional argument to console 
      Console.WriteLine("Hello, {0}, {1}", name, age); // {0} to embed variable in string
    }
}