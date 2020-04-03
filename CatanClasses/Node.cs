using System;
using System.Collections.Generic;
using System.Text;

namespace Catanv3
{
    class Node
    {
        public int id { get; set; }
        public List<Node> nodeNeighbors { get; set; }
        public List<Node> hasRoadWith { get; set; }
        public List<Hex> hexNeighbors { get; set; }

        private bool hasPort;
        /*public bool HasPort
        {
            get
            {
                return hasPort;
            }
            private set
            {
                hasPort = value;
            }
        }*/
        public Resources portTradedResource { get; set; }

        public bool hasSettlement { get; set; }
        public Player playerSettled;
        public Settlements settlementType { get; set; }



        public Node(int id)
        {
            this.id = id;
            //completat cu restul atributelor default (gen hassettlement false etc)

        }
    }
}
