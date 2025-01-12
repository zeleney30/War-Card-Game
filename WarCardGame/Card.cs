using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarCardGame
{
    internal class Card
    {
        public enum Suit
        {
            Spades,
            Clubs,
            Diamonds,
            Hearts
        }

        public enum Number
        {
            Ace = 1,
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5,
            Six = 6,
            Seven = 7,
            Eight = 8,
            Nine = 9,
            Ten = 10,
            Jack = 11,
            Queen = 12,
            King = 13,
        }

        public Suit suit { get; private set; }
        public Number number { get; private set; }

        public Card(Suit suit, Number number)
        {
            this.suit = suit;
            this.number = number;
        }

        public string ToString()
        {
            return this.number + " of " + this.suit;
        }
    }
}
