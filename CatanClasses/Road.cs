using System;
using System.Collections.Generic;
using System.Text;

namespace Catanv3
{
    class Road
    {
        private Node node1;

        public Node Node1
        {
            get
            {
                return this.node1;
            }
            set
            {
                this.node1 = value;
            }
        }
        public Node node2;

        public Node Node2
        {
            get
            {
                return this.node1;
            }
            set
            {
                this.node1 = value;
            }
        }
        private Player owner = new Player();
        public Player Owner
        {
            get 
            {
                return this.owner;
            }
        }

    }
}
