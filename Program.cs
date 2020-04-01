using System;

namespace IP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Player Alex=new Player("Alex");
            Console.WriteLine(Alex.DiceRoll());
        }
    }

    class Player
    {
        public
        string Nickname;
        static int ID;
        int skin;
        int Points;
        int RoadsLeft;
        int VillagesLeft;
        int PlayerType;
        

        private Player(string name)
        {
            Nickname = name;
            ID++;

        }

        private int DiceRoll()
        {
            Random dice = new Random();
            return dice.Next(1, 12);
        }

        private void PlayDevelopmentCard(int type)
        {
            //play(type);
        }

        private void EndTurn()
        {
            //player endTurn();
        }

        private void TradeWithPlayer(int id)
        {
            //trade(id);
        }

        private void TradeWithBand()
        {
            //TradeWithBand();
        }

        private bool BuyDevelopmentCard()
        {
            //check for resources;
            //BuyDevelopmentCard();
            return true;
        }

        private bool Build(int type)
        {
            //build(type);
            return true;
        }

        private bool CheckForPort()
        {
            //ChekcForPort
            //update player bank ratio
            return true;
        }

        private bool TradeAccept()
        {
            return true;
        }
    }
}
