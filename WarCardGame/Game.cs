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
        }
    }
}
