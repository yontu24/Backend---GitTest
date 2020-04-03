using System;
using System.Collections.Generic;
using System.Text;

namespace Catanv3
{
    class Hex
    {
        private int id;
        private int number;
        private bool hasRobber;
        private List<Node> nodeNeighbors = new List<Node>();
        private List<Hex> hexNeighbors = new List<Hex>();
        private Resources resource;

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
        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }
        public int Number
        {
            get
            {
                return this.number;
            }
            set
            {
                this.number = value;
            }
        }
        public bool HasRobber
        {
            get
            {
                return this.hasRobber;
            }
            set
            {
                this.hasRobber = value;
            }
        }
        public List<Node> NodeNeighbors
        {
            get
            {
                return this.nodeNeighbors;
            }
        }

        public List<Hex> HexNeighbors
        {
            get
            {
                return this.hexNeighbors;
            }
        }

        public Resources Resource
        {
            get
            {
                return this.resource;
            }
            set
            {
                this.resource = value;
            }
        }
    }
}
