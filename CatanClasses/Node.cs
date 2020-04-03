using System;
using System.Collections.Generic;
using System.Text;

namespace Catanv3
{
    class Node
    {
        private int id;

        public int Id {

            get
            {
                return this.id;
            }

            set
            {
                this.id = value;
            }

        }
        private List<Node> nodeNeighbors = new List<Node>();

        public List<Node> NodeNeighbors{
            get
            {
                return this.nodeNeighbors;
            }
        }

        private List<Node> hasRoadWith = new List<Node>();

        public List<Node> HasRoadWith
        {
            get
            {
                return this.hasRoadWith;

            }
        }

        private List<Hex> hexNeighbors = new List<Hex>();

        public List<Hex> HexNeighbors
        {
            get
            {
                return this.hexNeighbors;
            }
        }

        private bool hasPort;
        public bool HasPort
        {
            get
            {
                return hasPort;
            }
            private set
            {
                hasPort = value;
            }
        }
        // private Resources portTradedResource { get; set; }

        private bool hasSettlement;

        public bool HasSettlement
        {
            get
            {
                return this.hasSettlement;
            }
            set
            {
                this.hasSettlement = value;
            }
        }
        private Player playerSettled = new Player();
        public Player PlayerSettled
        {
            get
            {
                return this.playerSettled;
            }
        }
        private Settlements settlementType = new Settlements();

        public Settlements SettlementType
        {
            get { 
                return this.settlementType;
            }
        }

        



        public Node(int id)
        {
            this.id = id;
            //completat cu restul atributelor default (gen hassettlement false etc)

        }
    }
}
