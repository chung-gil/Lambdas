using System;

namespace BasicLambdas
{
    public delegate int MyDelegate(int x);
    public delegate void MyDelegate2(int x, string prefix);
    public delegate bool ExprDelegate(int x);

    class Program
    {
        static void Main(string[] args)
        {
            MyDelegate foo = (x) => x * x;
            Console.WriteLine($"The result of foo is: {foo(5)}");

            foo = (x) => x * 10;
            Console.WriteLine($"The result of foo is: {foo(5)}");

            MyDelegate2 bar = (x, y) =>
            {
                Console.WriteLine($"The two-arg lambda {x * 10}, {y}");
            };

            bar(25, "Some string");

            ExprDelegate baz = (x) => x > 10;
            Console.WriteLine($"Calling baz with 5: {baz(5)}");
            Console.WriteLine($"Calling baz with 15: {baz(15)}");
        }
    }
}
