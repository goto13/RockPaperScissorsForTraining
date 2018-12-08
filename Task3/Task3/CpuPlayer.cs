using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    public class CpuPlayer : Player
    {
        private readonly Random random;

        public CpuPlayer(string name) : base(name)
        {
            random = new Random(name.GetHashCode() + DateTime.Now.Millisecond);
        }

        public override bool Equals(object obj)
        {
            return obj is CpuPlayer player;
        }

        public override int GetHashCode()
        {
            return ("CPU" + Name).GetHashCode();
        }

        public override HandShape OutputHand()
        {
            var cpuHand = random.Next(1, 4);
            return Utils.ConvertToHandShape(cpuHand);
        }


    }
}
