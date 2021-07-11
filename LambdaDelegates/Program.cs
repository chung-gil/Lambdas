using System;

namespace LambdaDelegates
{
    public delegate void myEventHandler(string value);

    class MyClass
    {
        private string theVal;
        public event myEventHandler valueChanged;

        public string Val
        {
            set
            {
                this.theVal = value;
                this.valueChanged(theVal);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyClass obj = new MyClass();

            obj.valueChanged += (x) =>
            {
                Console.WriteLine($"The value changed to {x}");
            };

            string str;
            do
            {
                str = Console.ReadLine();
                if (!str.Equals("exit"))
                {
                    obj.Val = str;
                }
            }
            while (!str.Equals("exit"));

            Console.WriteLine("Good bye!");
        }
    }
}
