using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    public class RPSGame
    {
        public void DoGame()
        {
            Start();
            Game();
            End();
        }
        private void Start()
        {
            Console.WriteLine("Start Rock-Paper-Scissors Game.");
        }


        private void Game()
        {
            do
            {
                DoRPS();
            } while (ContinueGame());
        }

        private void DoRPS()
        {
            while (true)
            {
                var userHand = Utils.ReadInputNumber(
                    "Please input hand shape number. (1: Rock, 2: Paper, 3: Scissors)",
                    "The input value should be integer from 1 to 3.",
                    i => 0 < i && i < 4);
                var random = new Random();
                var cpuHand = random.Next(1, 3);

                ShowHands(userHand, cpuHand);
                var winnerName = JudgeHand(userHand, cpuHand);
                if (winnerName != null)
                {
                    Console.WriteLine($"{winnerName} won!");
                    break;
                }

                Console.WriteLine("The game is draw.");
            }
        }

        /// <summary>
        /// Judge the win-lose of game.
        /// Returns winner's name. In case of draw, return null.
        /// </summary>
        /// <param name="userHand"></param>
        /// <param name="cpuHand"></param>
        /// <returns></returns>
        private string JudgeHand(int userHand, int cpuHand)
        {
            var userHandShape = Utils.ConvertToHandShape(userHand);
            var cpuHandShape = Utils.ConvertToHandShape(cpuHand);
            if (userHandShape == HandShape.Rock)
            {
                if (cpuHandShape == HandShape.Paper)
                    return "CPU";
                else if (cpuHandShape == HandShape.Scissors)
                    return "User";
                else
                    return null;
            }
            else if (userHandShape == HandShape.Paper)
            {
                if (cpuHandShape == HandShape.Scissors)
                    return "CPU";
                else if (cpuHandShape == HandShape.Rock)
                    return "User";
                else
                    return null;
            }
            else if (userHandShape == HandShape.Scissors)
            {
                if (cpuHandShape == HandShape.Rock)
                    return "CPU";
                else if (cpuHandShape == HandShape.Paper)
                    return "User";
                else
                    return null;
            }
            return null;
        }

        private void ShowHands(int userHand, int cpuHand)
        {
            Console.WriteLine($"User's hand is {Utils.ConvertToHandShape(userHand).ToEnglishName()}");
            Console.WriteLine($"CPU's hand is {Utils.ConvertToHandShape(cpuHand).ToEnglishName()}");
        }

        private bool ContinueGame()
        {
            var num = Utils.ReadInputNumber(
                "Do you want to continue game? (1: continue, 0: exit)",
                "The input value should be integer 1 or 0.",
                i => i == 0 || i == 1);
            return num == 1;
        }

        private void End()
        {
            Console.WriteLine("Rock-Paper-Scissors Game Finished. See you next time.");
        }
    }
}
