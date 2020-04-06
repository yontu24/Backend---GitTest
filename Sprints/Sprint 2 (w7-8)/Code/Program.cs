using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catan
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Player> players = new List<Player>() {new Player("player1"), new Player("player2"), new Player("player3") };
            GameState gs = new GameState(players);

            foreach (Player player in gs.Players)
            {
                Console.WriteLine(player.ToString());
            }
        }
    }
}