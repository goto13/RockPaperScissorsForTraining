using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    public abstract class Player
    {
        public string Name { get; private set; }

        protected Player(string name)
        {
            this.Name = name;
        }

        public abstract HandShape OutputHand();
    }
}
