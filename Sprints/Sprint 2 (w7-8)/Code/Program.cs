using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Catan
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Player> players = new List<Player>() {new Player("player1"), new Player("player2"), new Player("player3")};
            GameState gs = new GameState(players);

            /*foreach (Player player in gs.Players)
            {
                Console.WriteLine(player.ToString());
            }*/

            /*JsonSerializer serializer = new JsonSerializer();
            serializer.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
            serializer.Formatting = Formatting.Indented;
            serializer.MaxDepth = 4;

            using (StreamWriter sw = new StreamWriter(@"d:\gamestatejson.txt"))
            using (JsonWriter writer= new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, gs);
            }*/

            gs.Map.Nodes[10].SettlePlayer(players[0], Settlements.City);
            gs.Map.Nodes[11].SettlePlayer(players[1], Settlements.Village);
            
            gs.Map.Hexes[4].Number = 5;
            gs.Map.Hexes[4].Resource = Resources.Wheat;
            gs.Map.Hexes[1].Number = 5;

            foreach (Hex hex in gs.Map.Nodes[10].HexNeighbors)
            {
                Console.WriteLine(hex.ToString());
            }

            TurnMethods.NotSevenRolled(gs.Map, 5);
            players[0].PrintResources();
            players[1].PrintResources();

            Console.WriteLine(gs.Map.Nodes[10].ToString());
        }
    }
}