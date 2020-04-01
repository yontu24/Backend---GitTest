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
        

        public Player(string name)
        {
            Nickname = name;
            ID++;

        }

        public int DiceRoll()
        {
            Random dice = new Random();
            return dice.Next(1, 12);
        }

        public void PlayDevelopmentCard(int type)
        {
            //play(type);
        }

        public void EndTurn()
        {
            //player endTurn();
        }

        public void TradeWithPlayer(int id)
        {
            //trade(id);
        }

        public void TradeWithBand()
        {
            //TradeWithBand();
        }

        public bool BuyDevelopmentCard()
        {
            //check for resources;
            //BuyDevelopmentCard();
            return true;
        }

        public bool Build(int type)
        {
            //build(type);
            return true;
        }

        public bool CheckForPort()
        {
            //ChekcForPort
            //update player bank ratio
            return true;
        }

        public bool TradeAccept()
        {
            return true;
        }
    }
}
