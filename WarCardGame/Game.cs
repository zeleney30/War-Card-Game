using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarCardGame
{
    internal class Game
    {
        public Player player1 = new Player();
        public Player player2 = new Player();
        public Deck deck = new Deck();

        public void Play()
        {
            deck.Shuffle();
            deck.Deal(player1, player2);
            Fight(player1, player2);
        }

        public void Fight(Player p1, Player p2)
        {
            Stack<Card> p1Cards = p1.cards;
            Stack<Card> p2Cards = p2.cards;

            Deck cardsInPlay = new Deck();

            Deck deck1Copy = new Deck();
            Deck deck2Copy = new Deck();

            cardsInPlay.cards.Push(p1Cards.Pop());
            cardsInPlay.cards.Push(p2Cards.Pop());

            if (p1.cards.Pop().number > p2.cards.Pop().number)
            {
                foreach (Card card in cardsInPlay.cards)
                {
                    p1.cards.Push(card);
                }
            }
            else
            {
                foreach (Card card in cardsInPlay.cards)
                {
                    p2.cards.Push(card);
                }
            }
        }
    }
}
