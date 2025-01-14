using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WarCardGame.Card;

namespace WarCardGame
{
    internal class Deck
    {
        public static Random random = new Random();

        //private List<Card> cards;
        public Stack<Card> cards = new Stack<Card>();

        public Deck()
        {
            cards = new Stack<Card>();
            //For each number in each suit, add a new card
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Number rank in Enum.GetValues(typeof(Number)))
                {
                    cards.Push(new Card(suit, rank));
                }
            }
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

            Console.WriteLine("Shuffling...");

            foreach (var card in array)
            {
                cards.Push(card);
            }
        }

        public void Deal(Player p1, Player p2)
        {
            var cards_copy = cards.ToArray();

            Console.WriteLine("Dealing...");

            for (int i = 0; i < cards_copy.Length; i++)
            {
                if (i % 2 == 0)
                {
                    p1.drawCard(cards.Pop());
                }
                else
                {
                    p2.drawCard(cards.Pop());
                }
            }
        }

        public void ToString()
        {
            foreach(Card card in cards)
            {
                Console.WriteLine(card.ToString());
            }
        }
    }
}
