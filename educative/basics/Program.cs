using System; // NOTE: System is a namespace
using System.Collections.Generic;

/* NOTE: name convention
The two main Capitalizations are called camelCase and PascalCase.
The basic rules are:

Class use PascalCase
properties and methods always use PascalCase
public members (fields, consts) use PascalCase
interface use pascalCase with I in front: eg, IMyInterface
local variables use camelCase
parameters use camelCase

And although the documentation states that "Internal and private fields are not covered by guidelines" there are some clear conventions:
private fields use camelCase
QUES: ? private fields that back a property prefix a _
*/

/*
NOTE: namespace can be used to organize classes
     control the scope of class and method names in larger programming projects
*/
namespace basics
{       
    class Program
    {
        static void Main(string[] args)
        {
            ///////////////////////////////////////////////////////////////////
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
            


            ///////////////////////////////////////////////////////////////////
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



            ///////////////////////////////////////////////////////////////////
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
            var c3 = 12; // QUES: has var data type?
            Console.WriteLine((c3 > 10) ? "ternary branch1" : "ternary branch2");


            ///////////////////////////////////////////////////////////////////
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
            foreach(string s in l2) { // NOTE: foreach and in
                Console.WriteLine(s);
            }

            //  NOTE: jump statement: break, continue, return (for function), throw (throw exception)



            ///////////////////////////////////////////////////////////////////
            /*
            Arrays:
             */
            Console.WriteLine("\nArrays:");

            // NOTE: static array, allocate in complie time, in memory stack
            int[] arr1 = {1, 2, 3}; 
            foreach (var num in arr1) { // NOTE: foreach + use var
                Console.WriteLine("arr1: " + num);
            }

            // NOTE: dynamic array, allocate in run time, in memory head 
            int[] arr2 = new int[3]; // NOTE: initial value is 0
            for (int i = 0; i < arr2.Length; i++) {
                Console.WriteLine("arr2: " + arr2[i]);
            }

            /*
            NOTE: static array inital: int[] arr = {1, 3}
            dynamic array inital: int[] arr = new int[]{1, 3}
            */
            int[] arr3 = new int[]{5, 6, 7}; // dynamic initialize
            foreach (int num in arr3) {
                Console.WriteLine("arr3: " + num);
            }
            
            /* mutile dimension array
            QUES: size must be fixed, array in the same dimension has same length?
            QUES: how to iterate it?
            */
            int[,] arr4 = new int[2, 2] {{1, 2}, {3, 4}};
            arr4[1, 1] = 5;
            Console.WriteLine(arr4[0, 0]);
            Console.WriteLine(arr4[1, 1]);

            // NOTE: total length, number of all elements. Not number of dimensions
            int totalLength = arr4.Length; 
            Console.WriteLine("lenth: " + totalLength);

            // NOTE: iterate multiDimensional array: arry.Rank, arr.GetLength(i)
            for (int i = 0; i < arr4.Rank; i++) { // for each dimension
                int dimensionLength = arr4.GetLength(i); // NOTE: length of this dimension
                for (int j = 0; j < dimensionLength; j++) {
                    Console.WriteLine("arr4: " + arr4[i, j]);
                }
            }

            /*jagged array: is array of arrays
            NOTE: multidimensional arrays are limited to a fixed number of rows and columns, 
            while jagged arrays, every row can have a different number of columns.
            */
            // NOTE: new int[2][3] is invalid, second length cannot be fixed
            // NOTE: arr5[0] = {1, 2} is invalid, must use new int[]{} when initailization (dymamic array)
            int[][] arr5 = new int[2][]; 
            arr5[0] = new int[]{1,2 ,3};
            arr5[1] = new int[]{4, 5};

            /*NOTE: int[][] arr6 = new int[][] is invalid, first length must be given, 
            unless we inital it right away like below
            */
            int[][] arr6 = new int[][] {
                new int[]{1,2},
                new int[]{3, 4, 5},
                new int[]{6}
            };

            // NOTE: for jogged array, Length is the elements(rows, subarrays) in it
            Console.WriteLine(arr6.Length);

            // NOTE: iterate jogged array, same as java, just need to get length of 
            // each subarray because they may have different length
            for (int i = 0; i < arr6.Length; i++) {
                for (int j = 0; j < arr6[i].Length; j++) {
                    Console.WriteLine("arr6: " + arr6[i][j]);
                }
            }


            
            ///////////////////////////////////////////////////////////////////
            /*
            string: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/strings/
             */
            Console.WriteLine("\nString:");

            // NOTE: regular string literal, support escape sequence for special chars
            // eg, \\ for \, \n, \r
            string s1 = "c:\\File\\test.txt\n seconde line"; 
            Console.WriteLine(s1);

            // NOTE: verbatime string literal, has @ in front of ""
            // the characters between the delimiters are interpreted verbatim
            // don't support escape sequence, can support multiple lines
            // ofen used for file path, quate mark needs twice
            string s2 = @"c:\File\text.txt
            seconde line ""quote mark needs double"" ";
            Console.WriteLine(s2);
            
            // string is alias for System.String
            // use new string() only when initial it with char array
            System.String s3 = new string(new char[]{'a', 'b', 'c'});
            Console.WriteLine(s3);

            // NOTE: like java, string is immutable, modification will create
            // a new string, then assign to s3
            s3 += "def";

            // format string- string interpolation
            // use $"{variable} lalala" to insert variables into string
            var tp = (firstName: "peng", lastName: "tong"); // QUES: what's this? like js object?
            Console.WriteLine($"{tp.firstName} {tp.lastName} is a good student");

            // format string - comosite formatting
            // use ("{0} lala", vriable) to insert variable into string
            Console.WriteLine("{0} {1} is a good student", tp.firstName, tp.lastName);

            // Substring[strtIndex, length]
            Console.WriteLine(s3.Substring(1, 3));

            // access char in string
            Console.WriteLine(s3[0]);

            // StringBuilder
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("hello ");
            sb.Append("Tong");
            Console.WriteLine(sb.ToString());

            // String.Empty, not use ""?
            string s4 = string.Empty;
            string s5 = ""; // QUES: not use "" because it can be written as " " be mistake?
            Console.WriteLine(s4 == s5);
            Console.WriteLine(s4.Equals(s5));

            // QUES: Compare string, == and equals are the same in string?
            // Normally, == compares two objects(references)
            // Equals also compares two objects, unless it has be overriden to compare values
            Console.WriteLine("123".Equals("123"));
            Console.WriteLine("123" == "123"); // QUES: why also return true?


            ///////////////////////////////////////////////////////////////////
            /*
            Namespace: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/namespaces/using-namespaces
             */
            Console.WriteLine("\nNamespace:");
            SampleNameSpace1.SamepleClass.SampleMethod(); // call methods in different namespace
            SampleNameSpace2.SamepleClass.SampleMethod();





            ///////////////////////////////////////////////////////////////////
            /*
            List: https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1?view=netframework-4.8
            List<T> in c# is arrayList in java
            LinkedList<T> in c# is linkedList in java
            ArrayList in c# is deprecate, should avoid using it (it has no data type, stores object referece)
             */
            Console.WriteLine("\nList:");

            // create
            // NOTE: list can directly use int type
            List<int> list1 = new List<int>();

            // add
            list1.Add(1);
            list1.Add(2);
            list1.Add(3);
            list1.Add(4);

            // get
            Console.WriteLine(list1[0]);

            // modify
            list1[0] = 0;

            // contain
            Console.WriteLine(list1.Contains(0));
            Console.WriteLine(list1.Contains(1));

            // remove
            list1.RemoveAt(3);

            // iterate
            foreach (int i in list1) {
                Console.WriteLine("i: {0}", i);
            }
        }
            
    }

    // NOTE: in different namespace can have class, method with same names
    namespace SampleNameSpace1 {
        class SamepleClass {
            public static void SampleMethod() {
                Console.WriteLine("name space method1");
            }
        }
    }
    
    namespace SampleNameSpace2 {
        class SamepleClass {
            public static void SampleMethod() {
                Console.WriteLine("name space method2");
            }
        }
    }    
}
