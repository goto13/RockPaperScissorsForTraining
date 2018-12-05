using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new RPSGame();
            game.DoGame();
            //Console.WriteLine(HandShape.Rock.ToJapaneseName());
            Console.ReadLine();
        }
    }
}
