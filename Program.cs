using System;

namespace Cards
{
    class Program
    {
        static void Main(string[] args)
        {
           
            Wood w = new Wood(10, 3);
            Console.WriteLine("Hello World!" + "\n" + w.GetResourceQuantity() + "\n" + w.GetResourceType());
        }
    }
}
