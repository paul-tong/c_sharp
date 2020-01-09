using System;

namespace basics
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            variable:
            1.like a box with name, complier connects variable name with memory address
            2.variable name can use a-z, A-Z, 0-9, must starts with letter
            3.int(assigned int) has 4 bytes(32 bit), range -2^31 -> 2^31-1
              unint(unsigned int), range 0 -> 2^32 - 1
             */
            Console.WriteLine("\nVariables:");
            string vs = "10";
            int vi = int.Parse(vs); // Parse to convert string to given type
            double vd = double.Parse("10.5");
            Console.WriteLine("vi: {0}, vd: {1}", vi, vd);
            
            /*
            Operators:
             */
            Console.WriteLine("\nOperators:");
            int a = 4;
            int b = 3;
            Console.WriteLine("a / b = {0}", a / b); // resut of / is int if both a and b are int
            Console.WriteLine("(float)a / b = {0}", (float)a / b);

            a += 6; // a = a + 6;
            Console.WriteLine(a);

            /* 
            Conditions:
            */
            Console.WriteLine("\nConditions:");

            // if else
            int c1 = 10;
            if (c1 == 8) {
                Console.WriteLine("branch1");
            }
            else if (c1 == 9) {
                Console.WriteLine("branch2");
            }
            else {
                Console.WriteLine("branch3");
            }

            // cannot directly use interger to decide condition 
            /*if (c1) {
                Console.WriteLine("can use interger as condition");
            }*/

            // switch
            int c2 = 10;
            switch (c2) {
                case 8: // case must be a constant
                    Console.WriteLine("branch1");
                    break; // jump statement, can be break, continue, goto, return?
                case 9:
                    Console.WriteLine("branch2");
                    break;
                case 10:
                    Console.WriteLine("branch3");
                    break;
                default:
                    Console.WriteLine("default");
                    break;
            }

            // ternary condition
            var c3 = 12; // TODO: has var data type?
            Console.WriteLine((c3 > 10) ? "ternary branch1" : "ternary branch2");


            /*
            Loops:
             */
            Console.WriteLine("\nLoops:");

            // while
            int l1 = 0;
            while (l1 < 3) {
                Console.WriteLine(l1++);
            }

            // for 
            for (int i = 100; i < 103; i++) {
                Console.WriteLine(i);
            }

            // foreach
            string[] l2 = {"a", "b", "c"};
            foreach(string s in l2) { // TODO: foreach and in
                Console.WriteLine(s);
            }

            //  TODO: jump statement: break, continue, return (for function), throw (throw exception)


            /*
            Arrays:
             */
            Console.WriteLine("\nArrays:");
        }
    }
}
