using System;

namespace Lab01_JocelydeLeon_1305619
{
    class Program
    {
        static void Main(string[] args)
        {
            string regexp = Console.ReadLine();
            Parser parser = new Parser();
            double final=parser.Parse(regexp);
            Console.WriteLine("Expresión OK " + final);
            Console.ReadLine();
        } //MAIN
    }
}
