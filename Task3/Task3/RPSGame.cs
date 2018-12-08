using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task3
{
    public class RpsGame
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
            var players = new List<Player>();
            players.AddRange(InitUsers());
            players.AddRange(InitCpus());
            if (players.Count < 2)
            {
                Console.WriteLine("The number of players must be more than 1.");
                return;
            }

            while (true)
            {
                var snapShot = new Dictionary<Player, HandShape>();
                foreach (var player in players)
                {
                    snapShot.Add(player, player.OutputHand());
                }

                // show all hands
                foreach (var kv in snapShot)
                {
                    Console.WriteLine($"{kv.Key.Name}'s handshape is {kv.Value.ToEnglishName()}");
                }

                var winners = JudgeManyHand(snapShot);
                if (!winners.Any())
                {
                    Console.WriteLine("DRAW! Let's try again.");
                    continue;
                }

                // show the winners
                foreach (var winner in winners)
                {
                    Console.WriteLine($"{winner.Name} won! Conglatulation!");
                }
                break;
            }
        }

        /// <summary>
        /// judge the win-lose by the algorithm of following.
        /// https://boardgamegeek.com/boardgame/99675/massive-multiplayer-rock-paper-scissors
        /// </summary>
        /// <param name="snapShot"></param>
        private List<Player> JudgeManyHand(Dictionary<Player, HandShape> snapShot)
        {
            var rNum = snapShot.Count(kv => kv.Value == HandShape.Rock);
            var pNum = snapShot.Count(kv => kv.Value == HandShape.Paper);
            var sNum = snapShot.Count(kv => kv.Value == HandShape.Scissors);

            // If there is only 1 handshape, draw
            if ((rNum == 0 && pNum == 0) || (pNum == 0 && sNum == 0) || (sNum == 0 && rNum == 0))
                return new List<Player>();

            var rPts = rNum == 0 ? 0 : sNum;
            var pPts = pNum == 0 ? 0 : rNum;
            var sPts = sNum == 0 ? 0 : pNum;

            // The 1 handshape's points is greater than others, the handshape is winner.
            if (rPts > pPts && rPts > sPts)
                return snapShot.Where(kv => kv.Value == HandShape.Rock).Select(kv => kv.Key).ToList();
            else if (pPts > sPts && pPts > rPts)
                return snapShot.Where(kv => kv.Value == HandShape.Paper).Select(kv => kv.Key).ToList();
            else if (sPts > pPts && sPts > rPts)
                return snapShot.Where(kv => kv.Value == HandShape.Scissors).Select(kv => kv.Key).ToList();
            else
                return new List<Player>();
        }

        private List<Player> InitCpus()
        {
            var numOfPlayers = Utils.ReadInputNumber(
                "Please input the number of CPUs. (0 to 5)",
                "The input value should be integer from 0 to 5.",
                i => 0 <= i && i <= 5);

            var cpus = new List<Player>();
            for (int i = 0; i < numOfPlayers; i++)
            {
                cpus.Add(new CpuPlayer("CPU" + (i + 1)));
            }
            return cpus;
        }

        private List<Player> InitUsers()
        {
            var numOfPlayers = Utils.ReadInputNumber(
                "Please input the number of users. (0 to 5)",
                "The input value should be integer from 0 to 5.",
                i => 0 <= i && i <= 5);

            var users = new List<Player>();
            for (int i = 0; i < numOfPlayers; i++)
            {
                users.Add(new UserPlayer("User" + (i + 1)));
            }
            return users;
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
