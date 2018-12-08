using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    public static class Utils
    {
        public static int ReadInputNumber(string inputMessage, string continueMessage, Func<int, bool> isValid)
        {
            int num = 0;
            bool parsed = false;
            while (true)
            {
                Console.WriteLine(inputMessage);
                var input = Console.ReadLine();
                parsed = int.TryParse(input, out num);

                if (parsed && isValid(num))
                    break;

                Console.WriteLine(continueMessage);
            }

            return num;
        }

        public static HandShape ConvertToHandShape(int num)
        {
            switch (num)
            {
                case 1:
                    return HandShape.Rock;
                case 2:
                    return HandShape.Paper;
                case 3:
                    return HandShape.Scissors;
                default:
                    throw new ArgumentException("To convert to HandShape, the number must be from 1 to 3.");
            }
        }
    }
}
