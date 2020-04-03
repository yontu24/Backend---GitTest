using System;
using System.Collections.Generic;
using System.Text;

namespace Catanv3
{
    class Hex
    {
        public int id { get; set; }
        public Resources resource { get; set; }
        public int number { get; set; }
        public bool hasRobber { get; set; }
        public List<Node> nodeNeighbors { get; set; }
        //public List<Hex> hexNeighbors { get; set; } 


        public Hex(int id, Resources resource, int number)
        {
            this.id = id;
            this.resource = resource;
            this.number = number;
            this.hasRobber = false;
        }

        public Hex(int id)
        {
            this.id = id;
            this.resource = Resources.Ocean;
            this.number = -1;
            this.hasRobber = false;
        }
    }
}
