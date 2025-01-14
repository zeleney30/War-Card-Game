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

            Console.WriteLine(c1.ToString() + " vs " + c2.ToString());

            //Compare cards
            if (c1.number > c2.number)  //If p1 has a higher card than p2
            {
                Console.WriteLine(c1.ToString() + " Wins!");

                foreach (Card card in cardsInPlay)
                {
                    //Add the cards to the players hand, then shuffle them
                    p1.drawCard(card);
                }

                p1.Shuffle();
            }
            else if (c2.number > c1.number) //If p2 has a higher card than p1
            {
                Console.WriteLine(c2.ToString() + " Wins!");

                foreach (Card card in cardsInPlay)
                {
                    //Add the cards to the players hand, then shuffle them
                    p2.drawCard(card);
                }

                p2.Shuffle();
            }
            else //If p1's card is equal to p2's card
            {
                //if one players hand is empty
                //return the cards to each player
                //shuffle their hands
                if (p1Cards.Count == 0 || p2Cards.Count == 0)
                {
                    p1.drawCard(c1);
                    p2.drawCard(c2);
                    p1.Shuffle();
                    p2.Shuffle();
                }
                else
                {
                    Console.WriteLine("Cards are equal...");
                    Console.WriteLine("Going to war...");
                    War(p1, p2, cardsInPlay);
                }
            }
        }



        //If the cards in the fight are equal, call this function
        public void War(Player p1, Player p2, Stack<Card> cards)
        {
            Stack<Card> p1Cards = p1.cards;
            Stack<Card> p2Cards = p2.cards;

            //These are the cards being played
            Stack<Card> cardsInPlay = cards;

            //Make sure both players have enough cards for a war
            if (p1Cards.Count >= 4 && p2Cards.Count >= 4)
            {
                //Since we are going to war (the previous cards were equal)
                //The next 3 cards from each player's hand are added to the pile, the 4th card determines who wins all the cards
                for (int i = 0; i < 3; i++)
                {
                    cardsInPlay.Push(p1Cards.Pop());
                    cardsInPlay.Push(p2Cards.Pop());
                }
            }
            else
            {
                //whoever has the least amount of cards, is how many cards we will play
                // -1 because the last card will be used to determine who wins
                int cardsToPlay = Math.Min(p1Cards.Count, p2Cards.Count) - 1;

                for (int i = 0; i < cardsToPlay; i++)
                {
                    cardsInPlay.Push(p1Cards.Pop());
                    cardsInPlay.Push(p2Cards.Pop());
                }
            }

            Card c1 = p1Cards.Pop();
            Card c2 = p2Cards.Pop();

            //Add the 2 top cards from each players deck to the pile
            //These are the 4th cards which determine the winner of the war
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
                    p1.drawCard(card);
                }

                p1.Shuffle();
            }
            else if (c2.number > c1.number) //If p2 has a higher card than p1
            {
                Console.WriteLine(c2.ToString() + " Wins!");

                foreach (Card card in cardsInPlay)
                {
                    //Add the cards to the players hand, then shuffle them
                    p2.drawCard(card);
                }

                p2.Shuffle();
            }
            else //If p1's card is equal to p2's card, go to war again
            {
                //If both players have enough cards for another war
                if (p1Cards.Count >= 0 && p2Cards.Count >= 0)
                {
                    Console.WriteLine("Cards are equal...");
                    Console.WriteLine("Going to war again...");
                    War(p1, p2, cardsInPlay);
                }
                else
                {
                    for (int i = cardsInPlay.Count; i > 0; i--)
                    {
                        //Player 2's card was the last card played, so it will be on top
                        if (i % 2 == 0) //Player 2
                        {
                            p2.drawCard(cardsInPlay.Pop());
                        }
                        else //Player 1
                        {
                            p1.drawCard(cardsInPlay.Pop());
                        }
                    }

                    p1.Shuffle();
                    p2.Shuffle();
                }
            }
        }
    }
}
