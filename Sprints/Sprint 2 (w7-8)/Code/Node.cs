using System;
using System.Collections.Generic;
using System.Text;

namespace Catan
{
    class Node
    {
        private int id;
        private List<Node> nodeNeighbors = new List<Node>();
        private List<Node> hasRoadWith = new List<Node>();
        private List<Hex> hexNeighbors = new List<Hex>();
        private bool hasPlayer = false; 
        private Player playerSettled = new Player();
        private bool hasSettlement = false;
        private Settlements settlementType = new Settlements();
        private bool hasPort = false;
        private Ports portType = new Ports();

        // CONSTRUCTOR
        public Node(int id) { this.id = id; }//completat cu restul atributelor default (gen hassettlement false etc)} 

        // METHODS
        public override string ToString()
        {
            StringBuilder final = new StringBuilder();
            final.Append("Node ID: " + id.ToString());

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
            final.Append(", HasPort: " + HasPort);
            if(HasPort)
                final.Append(", Port: " + PortType);
            //final.Append(", HasPlayer: " + HasPlayer);
            //final.Append(", HasSettlement: " + HasSettlement);
            return final.ToString();
        }

        // GETTERS AND SETTERS
        public int Id { get{return this.id;} set{this.id = value;} }
        public List<Node> NodeNeighbors { get{return this.nodeNeighbors;} set { this.nodeNeighbors = value; } }
        public List<Node> HasRoadWith { get{return this.hasRoadWith;} set { this.hasRoadWith = value; } }
        public List<Hex> HexNeighbors { get{return this.hexNeighbors;} set { this.hexNeighbors = value; } }
        public bool HasPlayer { get { return this.hasPlayer; } set { this.hasPlayer = value; } }
        public Player PlayerSettled { get { return this.playerSettled; } set { this.playerSettled = value; } }
        public bool HasSettlement { get { return this.hasSettlement; } set { this.hasSettlement = value; } }
        public Settlements SettlementType { get { return this.settlementType; } set { this.settlementType = value; } }
        public bool HasPort { get { return hasPort; } set { hasPort = value; } }
        public Ports PortType { get { return this.portType; } set { this.portType = value; } }
    }
}
