using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    public class UserPlayer : Player
    {
        public UserPlayer(string name) : base(name)
        {
        }

        public override bool Equals(object obj)
        {
            return obj is UserPlayer player;
        }

        public override int GetHashCode()
        {
            return ("User" + Name).GetHashCode();
        }

        public override HandShape OutputHand()
        {
            var intHand = Utils.ReadInputNumber(
                $"Hi {Name}, please input hand shape number. (1: Rock, 2: Paper, 3: Scissors)",
                "The input value should be integer from 1 to 3.",
                i => 0 < i && i < 4);
            return Utils.ConvertToHandShape(intHand);
        }
    }
}
