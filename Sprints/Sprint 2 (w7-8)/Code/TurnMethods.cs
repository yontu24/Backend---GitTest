using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Catan
{
    public static class TurnMethods
    {
        public static void NotSevenRolled(Map map, int diceRoll)
        {
            List<Hex> rolledHexes = map.Hexes.Where(hex => (hex.Number == diceRoll && hex.HasRobber == false)).ToList();

            if (!(rolledHexes.Count == 0))
            {
                foreach (Hex hex in rolledHexes)
                {
                    foreach (Node node in hex.SettledNeighborNodes())
                    {
                        switch (hex.Resource)
                        {
                            case Resources.Clay:
                                node.PlayerSettled.ClayQty += (node.SettlementType == Settlements.Village) ? 1 : 2;
                                Console.WriteLine("added clay");
                                break;
                            case Resources.Sheep:
                                node.PlayerSettled.SheepQty += (node.SettlementType == Settlements.Village) ? 1 : 2;
                                Console.WriteLine("added sheep");
                                break;
                            case Resources.Stone:
                                node.PlayerSettled.StoneQty += (node.SettlementType == Settlements.Village) ? 1 : 2;
                                Console.WriteLine("added stone");
                                break;
                            case Resources.Wheat:
                                node.PlayerSettled.WheatQty += (node.SettlementType == Settlements.Village) ? 1 : 2;
                                Console.WriteLine("added wheat");
                                break;
                            case Resources.Wood:
                                node.PlayerSettled.WoodQty += (node.SettlementType == Settlements.Village) ? 1 : 2;
                                Console.WriteLine("added wood");
                                break;
                        }
                    }
                }
            }
        }
        

        public static void sevenRolled(Map map, List<Player> allPlayers, Player currentPlayer)
        {
            //TODO

            foreach(Player player in allPlayers)
            {
                int totalResourceCards = player.WheatQty + player.WoodQty + player.StoneQty + player.SheepQty + player.ClayQty;

                if (totalResourceCards > 7)
                {
                    List<Resources> discarded = new List<Resources>();
                    //somehow show to the player on the GUI that they need to discard and get the chosen discard resources as input
                    //probably make sure that on the GUI the player can't select more than what he has (e.g. can't choose to discard 4 wheat if he's only got 3)
                    player.Discard(discarded);
                }
            }


            Hex newRobberHex = map.Hexes[0]; //TEMP - get input from GUI for what hex the current player has chosen to place the robber on
            map.MoveRobber(newRobberHex);
            
            //implement stealing

        }
    }
}