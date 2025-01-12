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

        private int num_fight = 0;

        public void Play()
        {
            deck.Shuffle();
            deck.Deal(player1, player2);

            while (player1.cards.Count != 0 && player2.cards.Count != 0)
            {
                num_fight++;
                Fight(player1, player2);
                Console.WriteLine("Fight number: " + num_fight);
            }

            if (player1.cards.Count == 0)
            {
                Console.WriteLine("Player 2 Wins!");
            }
            else
            {
                Console.WriteLine("Player 1 Wins!");
            }
        }

        public void Fight(Player p1, Player p2)
        {
            Stack<Card> p1Cards = p1.cards;
            Stack<Card> p2Cards = p2.cards;

            //These are the cards being played
            Stack<Card> cardsInPlay = new Stack<Card>();
            Card c1 = p1Cards.Pop();
            Card c2 = p2Cards.Pop();

            //Add the 2 top cards from each players deck to the pile
            //Use peek not pop so the cards arent removed; we still need to compare the cards
            cardsInPlay.Push(c1);
            cardsInPlay.Push(c2);

            Console.WriteLine("Fight: ");
            Console.WriteLine(c1.ToString() + " vs " + c2.ToString());

            //Compare cards
            if (c1.number > c2.number)  //If p1 has a higher card than p2
            {
                Console.WriteLine(c1.ToString() + " Wins!");

                foreach (Card card in cardsInPlay)
                {
                    //Add the cards to the players hand, then shuffle them
                    p1.cards.Push(card);
                    p1.Shuffle();
                    return;
                }
            }
            else if (c2.number > c1.number) //If p2 has a higher card than p1
            {
                Console.WriteLine(c2.ToString() + " Wins!");

                foreach (Card card in cardsInPlay)
                {
                    //Add the cards to the players hand, then shuffle them
                    p2.cards.Push(card);
                    p2.Shuffle();
                    return;
                }
            }
            else //If p1's card is equal to p2's card
            {
                //if one players hand is empty
                //return the cards to each player
                //shuffle their hands
                if (p1Cards.Count == 0 || p2Cards.Count == 0)
                {
                    p1Cards.Push(c1);
                    p2Cards.Push(c2);
                    p1.Shuffle();
                    p2.Shuffle();
                }
                else
                {
                    Console.WriteLine("Cards are equal...");
                    Console.WriteLine("Next Cards...");
                    Fight(p1, p2, cardsInPlay);
                }
            }
        }

        //If the cards in the fight are equal, call this function
        public void Fight(Player p1, Player p2, Stack<Card> cards)
        {
            Stack<Card> p1Cards = p1.cards;
            Stack<Card> p2Cards = p2.cards;

            //These are the cards being played
            Stack<Card> cardsInPlay = cards;
            Card c1 = p1Cards.Pop();
            Card c2 = p2Cards.Pop();

            //Add the 2 top cards from each players deck to the pile
            cardsInPlay.Push(c1);
            cardsInPlay.Push(c2);

            Console.WriteLine(c1.ToString() + " vs " + c2.ToString());

            //Compare cards
            if (c1.number > c2.number)  //If p1 has a higher card than p2
            {
                Console.WriteLine(c1.ToString() + " Wins!");

                foreach (Card card in cardsInPlay)
                {
                    //Add the cards to the players hand, then shuffle them
                    p1.cards.Push(card);
                    p1.Shuffle();
                    return;
                }
            }
            else if (c2.number > c1.number) //If p2 has a higher card than p1
            {
                Console.WriteLine(c2.ToString() + " Wins!");

                foreach (Card card in cardsInPlay)
                {
                    //Add the cards to the players hand, then shuffle them
                    p2.cards.Push(card);
                    p2.Shuffle();
                    return;
                }
            }
            else //If p1's card is equal to p2's card
            {
                Console.WriteLine("Cards are equal...");
                Console.WriteLine("Next Cards...");
                Fight(p1, p2, cardsInPlay);
            }
        }
    }
}
