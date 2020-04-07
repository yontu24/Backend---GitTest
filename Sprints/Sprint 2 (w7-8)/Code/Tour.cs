using System;
using System.Collections.Generic;
using System.Text;

namespace Catan
{
    class Tour
    {
        private Player currentPlayer;

        public Player CurrentPlayer{    get { return this.currentPlayer; }  set { this.currentPlayer = value; } }

        public Tour(Player player, List<Player> players)
        {
            Console.WriteLine("tura jucatorului " + player.Name);

            //RollDice();

            //check dice number...

            //  if(diceNumber != 7)
            //recieveResources();
            //else

            Rober(players);

       
            //trade
            //developmentcard
            //build
        }

        /*
        public int RollDice()
        {
            //return zaruri
        }
        */

        //public void recieveResources() { }


        public void Rober(List<Player> players)
        {
            Console.WriteLine("Dice shows 7");
            
            foreach(Player player in players)
            {
                int totalResourceCards = player.WheatQty + player.WoodQty + player.StoneQty + player.SheepQty + player.ClayQty;

                if(totalResourceCards > 7)
                {
                    //discard
                }
            }


        }

    }
}
