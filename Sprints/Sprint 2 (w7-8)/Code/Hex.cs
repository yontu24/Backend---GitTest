using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Catan
{
    public class Hex
    {
        private int id;
        private int number;
        private bool hasRobber = false;
        private List<Node> nodeNeighbors = new List<Node>();
        private List<Hex> hexNeighbors = new List<Hex>();
        private Resources resource;

        // CONSTRUCTOR
        public Hex(int id, Resources resource, int number)
        {
            this.id = id;
            this.resource = resource;
            this.number = number;
            this.hasRobber = false;
        }

        // CONSTRUCTOR
        public Hex(int id)
        {
            this.id = id;
        }

        // METHODS
        public void setDetails(Resources resource, int number)
        {
            this.resource = resource;
            this.number = number;
        }

        public override string ToString()
        {
            StringBuilder final = new StringBuilder();
            final.Append("Hex ID: " + id.ToString() + ", resource: " + Resource.ToString() + ", number: " + Number.ToString());
           
            final.Append(", HexNeighbors: ");
            StringBuilder hNeighbors = new StringBuilder();
            foreach (Hex hex in HexNeighbors)
            {
                hNeighbors.Append(hex.Id.ToString() + ", ");
            }
            final.Append(hNeighbors);

            final.Append(", NodeNeighbors: ");
            StringBuilder nNeighbors = new StringBuilder();
            foreach (Node node in NodeNeighbors)
            {
                nNeighbors.Append(node.Id.ToString() + ", ");
            }
            final.Append(nNeighbors);

            final.Append(", HasRobber: " + HasRobber);
            return final.ToString();
        }

        public List<Node> SettledNeighborNodes()
        {
            return this.NodeNeighbors.Where(node => node.HasPlayer == true).ToList();
        }

        // GETTERS AND SETTERS
        public int Id { get{return this.id;} set{this.id = value;} }
        public int Number { get{return this.number;} set {this.number = value;} }
        public bool HasRobber { get{return this.hasRobber;} set{this.hasRobber = value;} }
        public List<Node> NodeNeighbors { get{return this.nodeNeighbors;} set{this.nodeNeighbors = value;} }
        public List<Hex> HexNeighbors { get{return this.hexNeighbors;} set{this.hexNeighbors = value;} }
        public Resources Resource { get{return this.resource;} set{this.resource = value;} }
    }
}
