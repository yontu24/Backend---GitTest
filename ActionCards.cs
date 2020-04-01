using System;
using System.Collections.Generic;
using System.Text;

namespace Cards
{
    interface ActionCards
    {
        int GetCardType();
        int GetResourceQuantity();
        string Action();
    }
}
