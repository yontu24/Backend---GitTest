using System;

namespace Catan
{
  class Dice
    {
        public
        Random dice1 = new Random();
        Random dice2 = new Random();

         public  int Roll()
        {
            return dice1.Next(1, 6)+dice2.Next(1,6);
        }     
    }
}
  
