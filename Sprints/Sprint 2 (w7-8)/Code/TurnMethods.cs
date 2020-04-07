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
                    //
                }
            }
        }
    }
}