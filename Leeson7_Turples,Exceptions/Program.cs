using System;
using System.Collections.Generic;
namespace Leeson7_Turples_Exceptions
//Tuples
{
    class Program
    {
        class Test
        {
            public int id;
            public Test(int id)
            {
                this.id = id;
            }
            public override string ToString()
            {
                return $"{id}";
            }
        }
        static void Main(string[] args)
        {
            (int, string, int) lol = (22, "boriks",33);
            Tuple <int , string> t = new Tuple<int, string>(100, "Olena");
            Console.WriteLine(lol);
            var new_tuple = t.ToValueTuple();
            new_tuple.Item1 = 200;
            Test test = new Test(0);
            Test test2 = test;
            test.id = 2; //ref
            test2.id = 5; // => test.id = 5;
            Console.WriteLine(test);
            // Boxing, Unboxing
            object[] arr = { 100, 12.5, "line", 'A', true, 34 };
            double sum = 0;
            foreach (var item in arr)
            {

                Console.WriteLine(item);
                if (item.GetType().Name == "Int32")
                {
                    sum += (int)item;
                }
                else if (item is double)
                {
                    sum += (double)item;
                }
                
            }
            Console.WriteLine($"Sum: {sum}");
            Console.WriteLine($"Second road");
            sum = 0;
            foreach (var item in arr)
            {

                Console.WriteLine(item);
                switch (item)
                {
                    case int i:
                        sum += i;
                        break;
                    case double i:
                        sum += i;
                        break;
                }

            }
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
