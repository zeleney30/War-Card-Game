using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarCardGame
{
    internal class Player
    {
        public Stack<Card> cards = new Stack<Card>();

        public void drawCard(Card card)
        {
            cards.Push(card);
        }

        public void printHand()
        {
            foreach (Card card in cards)
            {
                Console.WriteLine(card.ToString());
            }
        }
    }
}
