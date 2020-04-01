using System;
using System.Collections.Generic;
using System.Text;

namespace Cards
{
    public class Wood : ResourceCards
    {
        int quantityOfCards;
        int type;

        public Wood(int newquantity, int newtype)
        {
            quantityOfCards = newquantity;
            type = newtype;
        }
        public int GetResourceQuantity()
        {
            return quantityOfCards;
        }
        public int GetResourceType()
        {
            return type;
        }
    }

    public class Clay : ResourceCards
    {
        int quantityOfCards;
        int type;

        public Clay(int newquantity, int newtype)
        {
            quantityOfCards = newquantity;
            type = newtype;
        }
        public int GetResourceQuantity()
        {
            return quantityOfCards;
        }
        public int GetResourceType()
        {
            return type;
        }
    }

    public class Sheep : ResourceCards
    {
        int quantityOfCards;
        int type;

        public Sheep(int newquantity, int newtype)
        {
            quantityOfCards = newquantity;
            type = newtype;
        }
        public int GetResourceQuantity()
        {
            return quantityOfCards;
        }
        public int GetResourceType()
        {
            return type;
        }
    }

    public class Stone : ResourceCards
    {
        int quantityOfCards;
        int type;

        public Stone(int newquantity, int newtype)
        {
            quantityOfCards = newquantity;
            type = newtype;
        }
        public int GetResourceQuantity()
        {
            return quantityOfCards;
        }
        public int GetResourceType()
        {
            return type;
        }
    }

    public class Wheat : ResourceCards
    {
        int quantityOfCards;
        int type;

        public Wheat(int newquantity, int newtype)
        {
            quantityOfCards = newquantity;
            type = newtype;
        }
        public int GetResourceQuantity()
        {
            return quantityOfCards;
        }
        public int GetResourceType()
        {
            return type;
        }
    }
}
