/*
NOTE: Resouces
https://www.educative.io/courses/software-design-patterns-best-practices
http://best-practice-software-engineering.ifs.tuwien.ac.at/patterns.html
https://javarevisited.blogspot.com/2018/07/10-object-oriented-design-principles.html
Book: first head design patterns

NOTE: What and Why
Why do we need patterns? 
The blunt answer is we don't want to reinvent the wheel! 
Problems that occur frequently enough in tech life usually have 
well-defined solutions, which are flexible, modular and more understandable. 
These solutions when abstracted away from the tactical details become design patterns. 


NOTE: Types:
Design patterns for object orientated programs are divided into three broad categories listed below. These are the same categories used 
by GoF in their seminal work on design patterns.
    Creational
    Structural
    Behavioural
Each of these are explained below

-Creational:
Creational design patterns relate to how objects are constructed from classes. 
    Builder Pattern
    Prototype Pattern
    Singleton Pattern
    Abstract Factory Pattern

-Structural:
Structural patterns are concerned with the composition of classes i.e. 
how the classes are made up or constructed. These include:
    Adapter Pattern
    Bridge Pattern
    Composite Pattern
    Decorator Pattern
    Facade Pattern
    Flyweight Pattern
    Proxy Pattern

-Behavioral:
Behavioral design patterns dictate the interaction of classes and
objects amongst eachother and the delegation of responsibility. These include:
    Interpreter Pattern
    Template Pattern
    Chain of Responsibility Pattern
    Command Pattern
    Iterator Pattern
    Mediator Pattern
    Memento Pattern
    Observer Pattern
    State Pattern
    Strategy Pattern
    Visitor Pattern

Most important pattern for intervew:
For folks, who are rushing through the course for an upcoming interview, 
I would suggest going through all the creational design patterns, 
decorator, proxy, iterator, observer and visitor patterns.
*/
using System;

namespace introduction
{
    class Program
    {
        public void test() {
            for (int i = 0; i < 10; i++) {
                Console.WriteLine("this is world");
                Console.WriteLine("this is world");

            }
        }

        private void test2() {

        }
        
        static void Main(string[] args)
        {
            
        }
    }
}
