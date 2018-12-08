using System;

namespace Task3
{
    static class Program
    {
        static void Main(string[] args)
        {
            var game = new RpsGame();
            game.DoGame();
            Console.ReadLine();
        }
    }
}
