using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarCardGame
{
    internal class Player
    {
        private Random random = new Random();

        public Stack<Card> cards = new Stack<Card>();

        public void drawCard(Card card)
        {
            cards.Push(card);
        }

        public void Shuffle()
        {
            var array = cards.ToArray();

            for (int i = array.Length - 1; i > 0; i--)
            {
                int j = random.Next(0, i + 1);

                var temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }

            cards.Clear();

            foreach (var card in array)
            {
                cards.Push(card);
            }
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
