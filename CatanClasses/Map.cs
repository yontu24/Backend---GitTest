using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Catanv3;

namespace Catanv3
{
    class Map
    {
        private List<Node> nodes = new List<Node>();
        private List<Hex> hexes = new List<Hex>();
        private static List<Resources> resourceTiles = new List<Resources>() {Resources.Desert, Resources.Clay, Resources.Clay, Resources.Clay, Resources.Wood, Resources.Wood, Resources.Wood, Resources.Wood, Resources.Stone, Resources.Stone, Resources.Stone, Resources.Sheep, Resources.Sheep, Resources.Sheep, Resources.Sheep, Resources.Wheat, Resources.Wheat, Resources.Wheat, Resources.Wheat};
        public List<Node> Nodes
        {
            get
            {
                return this.nodes;
            }
        }

        public List<Hex> Hexes
        {
            get { return this.hexes; }
        }

        public Map()
        {
            initHexes();
            hexesToHexesNbors();
            generateHexDetails();

            foreach (Hex hex in hexes)
            {
                Console.WriteLine(hex.ToString());
            }

            // initNodes();
            // hexesToNodesNbors();
            // makePorts();
        }

        //create all new nodes, add to list
        private void initNodes()
        {
            //loop 1..54 generare cu constructorul doar cu id, restul se intampla in connect
            for (int i = 1; i <= 54; i++)
            {
                Node item = new Node(i);
                nodes.Add(item);
            }
        }
        private void initHexes()
        {
            hexes.Add(new Hex(-1000));
            for (int i = 1; i <= 19; i++) 
            {
                Hex hex = new Hex(i);
                hexes.Add(hex);
            }
            for (int i = 1; i <= 18; i++)
            {
                Hex hex = new Hex(0 - i);
                hexes.Add(hex);
            }
        }

        private void hexesToHexesNbors() 
        {
            hexes[1].HexNeighbors = new List<Hex> {hexes[20], hexes[21], hexes[37], hexes[2], hexes[5], hexes[4]};
            hexes[2].HexNeighbors = new List<Hex> {hexes[21], hexes[22], hexes[1], hexes[5], hexes[6], hexes[3]};
            hexes[3].HexNeighbors = new List<Hex> {hexes[22], hexes[23], hexes[24], hexes[6], hexes[7], hexes[2]};
            hexes[4].HexNeighbors = new List<Hex> {hexes[36], hexes[37], hexes[5], hexes[8], hexes[1], hexes[9]};
            hexes[5].HexNeighbors = new List<Hex> {hexes[1], hexes[2], hexes[6], hexes[10], hexes[9], hexes[4]};
            hexes[6].HexNeighbors = new List<Hex> {hexes[2], hexes[3], hexes[5], hexes[7], hexes[10], hexes[11]};
            hexes[7].HexNeighbors = new List<Hex> {hexes[3], hexes[6], hexes[11], hexes[12], hexes[24], hexes[25]};
            hexes[8].HexNeighbors = new List<Hex> {hexes[34], hexes[35], hexes[36], hexes[4], hexes[9], hexes[13]};
            hexes[9].HexNeighbors = new List<Hex> {hexes[4], hexes[5], hexes[8], hexes[10], hexes[13], hexes[14]};
            hexes[10].HexNeighbors = new List<Hex> {hexes[5], hexes[6], hexes[11], hexes[9], hexes[14], hexes[15]};
            hexes[11].HexNeighbors = new List<Hex> {hexes[6], hexes[7], hexes[12], hexes[16], hexes[15], hexes[10]};
            hexes[12].HexNeighbors = new List<Hex> {hexes[25], hexes[26], hexes[27], hexes[7], hexes[11], hexes[16]};
            hexes[13].HexNeighbors = new List<Hex> {hexes[33], hexes[34], hexes[8], hexes[9], hexes[14], hexes[17]};
            hexes[14].HexNeighbors = new List<Hex> {hexes[9], hexes[10], hexes[15], hexes[18], hexes[17], hexes[13]};
            hexes[15].HexNeighbors = new List<Hex> {hexes[10], hexes[11], hexes[16], hexes[19], hexes[18], hexes[14]};
            hexes[16].HexNeighbors = new List<Hex> {hexes[27], hexes[28], hexes[11], hexes[12], hexes[15], hexes[19]};
            hexes[17].HexNeighbors = new List<Hex> {hexes[32], hexes[33], hexes[31], hexes[13], hexes[14], hexes[18]};
            hexes[18].HexNeighbors = new List<Hex> {hexes[30], hexes[31], hexes[17], hexes[14], hexes[15], hexes[19]};
            hexes[19].HexNeighbors = new List<Hex> {hexes[28], hexes[29], hexes[30], hexes[15], hexes[16], hexes[18]}; 
        }



        private void generateHexDetails() 
        {
            //List<Resources> resourceTiles = new List<Resources>() {Resources.Desert, Resources.Clay, Resources.Clay, Resources.Clay, Resources.Wood, Resources.Wood, Resources.Wood, Resources.Wood, Resources.Stone, Resources.Stone, Resources.Stone, Resources.Sheep, Resources.Sheep, Resources.Sheep, Resources.Sheep, Resources.Wheat, Resources.Wheat, Resources.Wheat, Resources.Wheat};
            List<int> numberPieces = new List<int>() {2, 3, 3, 4, 4, 5, 5, 6, 6, 8, 8, 9, 9, 10, 10, 11, 11, 12};

            //oceans
            for (int i = 20; i <= 37; i++)
            {
                hexes[i].setDetails(Resources.Ocean, -1);
            }

            List<Resources> shuffledTiles = Shuffler.Shuffle(resourceTiles);
            foreach (Resources tile in shuffledTiles)
            {
                Console.WriteLine(tile.ToString());
            }
            List<int> shuffledNumberPiecesNo68 = Shuffler.Shuffle(numberPieces).FindAll(e => e != 6 && e != 8);
            for (int i = 0; i < shuffledNumberPiecesNo68.Count; i++)
            {
                Console.Write(shuffledNumberPiecesNo68[i].ToString() + " ");
            }
            Console.WriteLine();

            //tiles that are not deserts will have numbers on them
            List<Hex> possibilities = new List<Hex>();

            //randomize the resource tiles on the map
            for (int i = 0; i < 19; i++)
            {
                hexes[i+1].Resource = shuffledTiles[i];
                hexes[i+1].Number = 0;

                if (hexes[i+1].Resource != Resources.Desert)
                {
                    //tiles that are not deserts will have numbers on them
                    possibilities.Add(hexes[i+1]);
                }
                else
                {
                    hexes[i].Number = 7;
                }
            }


            List<int> toPlace = new List<int>() {6, 6, 8, 8};
            Random rnd = new Random();

            for (int i = 0; i < toPlace.Count; i++)
            {
                Hex pos = possibilities[rnd.Next(possibilities.Count)];
                pos.Number = toPlace[i];
                //Console.WriteLine(pos.ToString());
                //possibilities = possibilities.FindAll(hex => !(hex.HexNeighbors.Contains(hex)) || !(hex == pos)  !(hex.Resource == Resources.Desert));
                possibilities = possibilities.Where(hex => hex.Resource != Resources.Desert)
                                             .Where(hex => !(hex.HexNeighbors.Contains(pos)))
                                             .Where(hex => hex != pos)
                                             .ToList();
            }

            for (int i = 0; i < 19; i++)
            {
                if (hexes[i+1].Resource != Resources.Desert && hexes[i+1].Number == 0)
                {
                    hexes[i+1].Number = shuffledNumberPiecesNo68[0];
                    shuffledNumberPiecesNo68.RemoveAt(0);
                }
            }
        }

        //populate lists of neighbors in each


    }
}
