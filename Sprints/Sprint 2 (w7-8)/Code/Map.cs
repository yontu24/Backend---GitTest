using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Catan
{
    public class Map
    {
        private List<Node> nodes = new List<Node>();
        private List<Hex> hexes = new List<Hex>();
        private static List<Resources> resourceTiles = new List<Resources>() { Resources.Desert, Resources.Clay, Resources.Clay, Resources.Clay, Resources.Wood, Resources.Wood, Resources.Wood, Resources.Wood, Resources.Stone, Resources.Stone, Resources.Stone, Resources.Sheep, Resources.Sheep, Resources.Sheep, Resources.Sheep, Resources.Wheat, Resources.Wheat, Resources.Wheat, Resources.Wheat };
        private static List<Ports> typeOfPort = new List<Ports>() { Ports.Clay, Ports.Wood, Ports.Stone, Ports.Wheat, Ports.Sheep };

        // CONSTRUCTOR
        public Map()
        {
            initHexes(); // CREATES and ADDS to list HEXES
            initNodes(); //nodes.RemoveAt(0);

            addHexNeighborsToHexes();  //connect hexes to other hexes
            addNodeNeighborsToHexes(); //connect hexes to nodes
            generateHexDetails();      //generate resources and dice numbers of each hex
            //foreach (Hex hex in hexes) { Console.WriteLine(hex.ToString()); }

            addHexNeighborsToNodes();  //connect nodes to hexes
            addNodeNeighborsToNodes(); //connect nodes to nodes
            addPortsToNodes();         //add ports
            //foreach (Node node in nodes) { Console.WriteLine(node.ToString()); }
        }


        
        private void initNodes()
        {
            //loop 1..54 generare cu constructorul doar cu id, restul se intampla in connect
            nodes.Add(new Node(-1000));
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


        private void generateHexDetails()
        {
            //List<Resources> resourceTiles = new List<Resources>() {Resources.Desert, Resources.Clay, Resources.Clay, Resources.Clay, Resources.Wood, Resources.Wood, Resources.Wood, Resources.Wood, Resources.Stone, Resources.Stone, Resources.Stone, Resources.Sheep, Resources.Sheep, Resources.Sheep, Resources.Sheep, Resources.Wheat, Resources.Wheat, Resources.Wheat, Resources.Wheat};
            List<int> numberPieces = new List<int>() { 2, 3, 3, 4, 4, 5, 5, 6, 6, 8, 8, 9, 9, 10, 10, 11, 11, 12 };

            //oceans
            for (int i = 20; i <= 37; i++)
            {
                hexes[i].setDetails(Resources.Ocean, -1);
            }

            List<Resources> shuffledTiles = Shuffler.Shuffle(resourceTiles);
            foreach (Resources tile in shuffledTiles)
            {
                //Console.WriteLine(tile.ToString());
            }
            List<int> shuffledNumberPiecesNo68 = Shuffler.Shuffle(numberPieces).FindAll(e => e != 6 && e != 8);
            for (int i = 0; i < shuffledNumberPiecesNo68.Count; i++)
            {
                //Console.Write(shuffledNumberPiecesNo68[i].ToString() + " ");
            }
            //Console.WriteLine();

            //tiles that are not deserts will have numbers on them
            List<Hex> possibilities = new List<Hex>();

            //randomize the resource tiles on the map
            for (int i = 0; i < 19; i++)
            {
                hexes[i + 1].Resource = shuffledTiles[i];
                hexes[i + 1].Number = 0;

                if (hexes[i + 1].Resource != Resources.Desert)
                {
                    //tiles that are not deserts will have numbers on them
                    possibilities.Add(hexes[i + 1]);
                }
                else
                {
                    hexes[i+1].Number = 7;
                    hexes[i+1].HasRobber = true;
                }
            }

            List<int> toPlace = new List<int>() { 6, 6, 8, 8 };
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
                if (hexes[i + 1].Resource != Resources.Desert && hexes[i + 1].Number == 0)
                {
                    hexes[i + 1].Number = shuffledNumberPiecesNo68[0];
                    shuffledNumberPiecesNo68.RemoveAt(0);
                }
            }

        }
        private void addPortsToNodes()
        {
            int[] permutation = { 3, 4, 6, 7, 16, 26, 37, 47, 53, 54, 50, 51, 39, 40, 28, 17, 8, 9 };

            Random rnd = new Random();
            int n = rnd.Next(1, 8);

            for (int i = 1; i <= n*2; i++)
            {
                int aux = permutation[0];
                for (int j = 0; j < permutation.Count() - 1; j++)
                {
                    permutation[j] = permutation[j + 1];
                }
                permutation[permutation.Count() - 1] = aux;
            }
            for (int i = 0; i < permutation.Count(); i++)
            {
                //Console.WriteLine(permutation[i]);
            }

            int poz = 0;
            List<Ports> shuffledPorts = Shuffler.Shuffle(typeOfPort);
            List<Node> nodesWithPorts = new List<Node>();
            for (int i=0; i<permutation.Count(); i++)
            {
                nodesWithPorts.Add(nodes[permutation[i]]); nodes[permutation[i]].HasPort = true;
                if(i%4==2||i%4==3)
                    nodesWithPorts[i].PortType = Ports.Simple;
                else if(i%4==0)
                    nodesWithPorts[i].PortType = shuffledPorts[poz];
                else
                {
                    nodesWithPorts[i].PortType = shuffledPorts[poz];
                    poz++;
                }
            }
            
        }
    
        private void addHexNeighborsToHexes()
        {
            hexes[1].HexNeighbors = new List<Hex> { hexes[20], hexes[21], hexes[37], hexes[2], hexes[5], hexes[4] };
            hexes[2].HexNeighbors = new List<Hex> { hexes[21], hexes[22], hexes[1], hexes[5], hexes[6], hexes[3] };
            hexes[3].HexNeighbors = new List<Hex> { hexes[22], hexes[23], hexes[24], hexes[6], hexes[7], hexes[2] };
            hexes[4].HexNeighbors = new List<Hex> { hexes[36], hexes[37], hexes[5], hexes[8], hexes[1], hexes[9] };
            hexes[5].HexNeighbors = new List<Hex> { hexes[1], hexes[2], hexes[6], hexes[10], hexes[9], hexes[4] };
            hexes[6].HexNeighbors = new List<Hex> { hexes[2], hexes[3], hexes[5], hexes[7], hexes[10], hexes[11] };
            hexes[7].HexNeighbors = new List<Hex> { hexes[3], hexes[6], hexes[11], hexes[12], hexes[24], hexes[25] };
            hexes[8].HexNeighbors = new List<Hex> { hexes[34], hexes[35], hexes[36], hexes[4], hexes[9], hexes[13] };
            hexes[9].HexNeighbors = new List<Hex> { hexes[4], hexes[5], hexes[8], hexes[10], hexes[13], hexes[14] };
            hexes[10].HexNeighbors = new List<Hex> { hexes[5], hexes[6], hexes[11], hexes[9], hexes[14], hexes[15] };
            hexes[11].HexNeighbors = new List<Hex> { hexes[6], hexes[7], hexes[12], hexes[16], hexes[15], hexes[10] };
            hexes[12].HexNeighbors = new List<Hex> { hexes[25], hexes[26], hexes[27], hexes[7], hexes[11], hexes[16] };
            hexes[13].HexNeighbors = new List<Hex> { hexes[33], hexes[34], hexes[8], hexes[9], hexes[14], hexes[17] };
            hexes[14].HexNeighbors = new List<Hex> { hexes[9], hexes[10], hexes[15], hexes[18], hexes[17], hexes[13] };
            hexes[15].HexNeighbors = new List<Hex> { hexes[10], hexes[11], hexes[16], hexes[19], hexes[18], hexes[14] };
            hexes[16].HexNeighbors = new List<Hex> { hexes[27], hexes[28], hexes[11], hexes[12], hexes[15], hexes[19] };
            hexes[17].HexNeighbors = new List<Hex> { hexes[32], hexes[33], hexes[31], hexes[13], hexes[14], hexes[18] };
            hexes[18].HexNeighbors = new List<Hex> { hexes[30], hexes[31], hexes[17], hexes[14], hexes[15], hexes[19] };
            hexes[19].HexNeighbors = new List<Hex> { hexes[28], hexes[29], hexes[30], hexes[15], hexes[16], hexes[18] };
        }
        private void addNodeNeighborsToHexes()
        {
            hexes[1].NodeNeighbors = new List<Node> { nodes[1], nodes[2], nodes[3], nodes[9], nodes[10], nodes[11] };
            hexes[2].NodeNeighbors = new List<Node> { nodes[3], nodes[4], nodes[5], nodes[11], nodes[12], nodes[13] };
            hexes[3].NodeNeighbors = new List<Node> { nodes[5], nodes[6], nodes[7], nodes[13], nodes[14], nodes[15] };
            hexes[4].NodeNeighbors = new List<Node> { nodes[8], nodes[9], nodes[10], nodes[18], nodes[19], nodes[20] };
            hexes[5].NodeNeighbors = new List<Node> { nodes[10], nodes[11], nodes[12], nodes[20], nodes[21], nodes[22] };
            hexes[6].NodeNeighbors = new List<Node> { nodes[12], nodes[13], nodes[14], nodes[22], nodes[23], nodes[24] };
            hexes[7].NodeNeighbors = new List<Node> { nodes[14], nodes[15], nodes[16], nodes[24], nodes[25], nodes[26] };
            hexes[8].NodeNeighbors = new List<Node> { nodes[17], nodes[18], nodes[19], nodes[28], nodes[29], nodes[30] };
            hexes[9].NodeNeighbors = new List<Node> { nodes[19], nodes[20], nodes[21], nodes[30], nodes[31], nodes[32] };
            hexes[10].NodeNeighbors = new List<Node> { nodes[21], nodes[22], nodes[23], nodes[32], nodes[33], nodes[34] };
            hexes[11].NodeNeighbors = new List<Node> { nodes[23], nodes[24], nodes[25], nodes[34], nodes[35], nodes[36] };
            hexes[12].NodeNeighbors = new List<Node> { nodes[25], nodes[26], nodes[27], nodes[36], nodes[37], nodes[38] };
            hexes[13].NodeNeighbors = new List<Node> { nodes[29], nodes[30], nodes[31], nodes[39], nodes[40], nodes[41] };
            hexes[14].NodeNeighbors = new List<Node> { nodes[31], nodes[32], nodes[33], nodes[41], nodes[42], nodes[43] };
            hexes[15].NodeNeighbors = new List<Node> { nodes[33], nodes[34], nodes[35], nodes[43], nodes[44], nodes[45] };
            hexes[16].NodeNeighbors = new List<Node> { nodes[35], nodes[36], nodes[37], nodes[45], nodes[46], nodes[47] };
            hexes[17].NodeNeighbors = new List<Node> { nodes[40], nodes[41], nodes[42], nodes[48], nodes[49], nodes[50] };
            hexes[18].NodeNeighbors = new List<Node> { nodes[42], nodes[43], nodes[44], nodes[50], nodes[51], nodes[52] };
            hexes[19].NodeNeighbors = new List<Node> { nodes[44], nodes[45], nodes[46], nodes[52], nodes[53], nodes[54] };

        }

        private void addHexNeighborsToNodes()
        {
            int x = 19; 
            nodes[1].HexNeighbors = new List<Hex> { hexes[x + 18], hexes[x + 1], hexes[1] };
            nodes[2].HexNeighbors = new List<Hex> { hexes[x + 1], hexes[1], hexes[x + 2] };
            nodes[3].HexNeighbors = new List<Hex> { hexes[1], hexes[x + 2], hexes[2] };
            nodes[4].HexNeighbors = new List<Hex> { hexes[x + 2], hexes[2], hexes[x + 3] };
            nodes[5].HexNeighbors = new List<Hex> { hexes[2], hexes[x + 3], hexes[3] };
            nodes[6].HexNeighbors = new List<Hex> { hexes[x + 3], hexes[3], hexes[x + 4] };
            nodes[7].HexNeighbors = new List<Hex> { hexes[3], hexes[x + 4], hexes[x + 5] };
            nodes[8].HexNeighbors = new List<Hex> { hexes[x + 17], hexes[x + 18], hexes[4] };
            nodes[9].HexNeighbors = new List<Hex> { hexes[x + 18], hexes[4], hexes[1] };
            nodes[10].HexNeighbors = new List<Hex> { hexes[4], hexes[1], hexes[5] };
            nodes[11].HexNeighbors = new List<Hex> { hexes[1], hexes[5], hexes[2] };
            nodes[12].HexNeighbors = new List<Hex> { hexes[5], hexes[2], hexes[6] };
            nodes[13].HexNeighbors = new List<Hex> { hexes[2], hexes[6], hexes[3] };
            nodes[14].HexNeighbors = new List<Hex> { hexes[6], hexes[3], hexes[7] };
            nodes[15].HexNeighbors = new List<Hex> { hexes[3], hexes[7], hexes[x + 5] };
            nodes[16].HexNeighbors = new List<Hex> { hexes[7], hexes[x + 5], hexes[x + 6] };
            nodes[17].HexNeighbors = new List<Hex> { hexes[x + 16], hexes[x + 17], hexes[8] };
            nodes[18].HexNeighbors = new List<Hex> { hexes[x + 17], hexes[8], hexes[4] };
            nodes[19].HexNeighbors = new List<Hex> { hexes[8], hexes[4], hexes[9] };
            nodes[20].HexNeighbors = new List<Hex> { hexes[4], hexes[9], hexes[5] };
            nodes[21].HexNeighbors = new List<Hex> { hexes[9], hexes[5], hexes[10] };
            nodes[22].HexNeighbors = new List<Hex> { hexes[5], hexes[10], hexes[6] };
            nodes[23].HexNeighbors = new List<Hex> { hexes[10], hexes[6], hexes[11] };
            nodes[24].HexNeighbors = new List<Hex> { hexes[6], hexes[11], hexes[7] };
            nodes[25].HexNeighbors = new List<Hex> { hexes[11], hexes[7], hexes[12] };
            nodes[26].HexNeighbors = new List<Hex> { hexes[7], hexes[12], hexes[x + 6] };
            nodes[27].HexNeighbors = new List<Hex> { hexes[12], hexes[x + 6], hexes[x + 7] };
            nodes[28].HexNeighbors = new List<Hex> { hexes[x + 16], hexes[x + 15], hexes[8] };
            nodes[29].HexNeighbors = new List<Hex> { hexes[x + 15], hexes[8], hexes[13] };
            nodes[30].HexNeighbors = new List<Hex> { hexes[8], hexes[13], hexes[9] };
            nodes[31].HexNeighbors = new List<Hex> { hexes[13], hexes[9], hexes[14] };
            nodes[32].HexNeighbors = new List<Hex> { hexes[9], hexes[14], hexes[10] };
            nodes[33].HexNeighbors = new List<Hex> { hexes[14], hexes[10], hexes[15] };
            nodes[34].HexNeighbors = new List<Hex> { hexes[10], hexes[15], hexes[11] };
            nodes[35].HexNeighbors = new List<Hex> { hexes[15], hexes[11], hexes[16] };
            nodes[36].HexNeighbors = new List<Hex> { hexes[11], hexes[16], hexes[12] };
            nodes[37].HexNeighbors = new List<Hex> { hexes[16], hexes[12], hexes[x + 8] };
            nodes[38].HexNeighbors = new List<Hex> { hexes[12], hexes[x + 8], hexes[x + 7] };
            nodes[39].HexNeighbors = new List<Hex> { hexes[x + 15], hexes[x + 14], hexes[13] };
            nodes[40].HexNeighbors = new List<Hex> { hexes[x + 14], hexes[13], hexes[17] };
            nodes[41].HexNeighbors = new List<Hex> { hexes[13], hexes[17], hexes[14] };
            nodes[42].HexNeighbors = new List<Hex> { hexes[17], hexes[14], hexes[18] };
            nodes[43].HexNeighbors = new List<Hex> { hexes[14], hexes[18], hexes[15] };
            nodes[44].HexNeighbors = new List<Hex> { hexes[18], hexes[15], hexes[19] };
            nodes[45].HexNeighbors = new List<Hex> { hexes[15], hexes[19], hexes[16] };
            nodes[46].HexNeighbors = new List<Hex> { hexes[19], hexes[16], hexes[x + 9] };
            nodes[47].HexNeighbors = new List<Hex> { hexes[16], hexes[x + 9], hexes[x + 8] };
            nodes[48].HexNeighbors = new List<Hex> { hexes[x + 14], hexes[x + 13], hexes[17] };
            nodes[49].HexNeighbors = new List<Hex> { hexes[x + 13], hexes[17], hexes[x + 12] };
            nodes[50].HexNeighbors = new List<Hex> { hexes[17], hexes[x + 12], hexes[18] };
            nodes[51].HexNeighbors = new List<Hex> { hexes[x + 12], hexes[18], hexes[x + 11] };
            nodes[52].HexNeighbors = new List<Hex> { hexes[18], hexes[x + 11], hexes[19] };
            nodes[53].HexNeighbors = new List<Hex> { hexes[x + 11], hexes[19], hexes[x + 10] };
            nodes[54].HexNeighbors = new List<Hex> { hexes[19], hexes[x + 10], hexes[x + 9] };
        }
            
        private void addNodeNeighborsToNodes()
        {
            nodes[1].NodeNeighbors = new List<Node> { nodes[2], nodes[9] };
            nodes[2].NodeNeighbors = new List<Node> { nodes[1], nodes[3] };
            nodes[3].NodeNeighbors = new List<Node> { nodes[2], nodes[4], nodes[11] };
            nodes[4].NodeNeighbors = new List<Node> { nodes[5], nodes[3] };
            nodes[5].NodeNeighbors = new List<Node> { nodes[6], nodes[13], nodes[4] };
            nodes[6].NodeNeighbors = new List<Node> { nodes[5], nodes[7] };
            nodes[7].NodeNeighbors = new List<Node> { nodes[6], nodes[15] };
            nodes[8].NodeNeighbors = new List<Node> { nodes[9], nodes[18] };
            nodes[9].NodeNeighbors = new List<Node> { nodes[1], nodes[10], nodes[8] };
            nodes[10].NodeNeighbors = new List<Node> { nodes[9], nodes[11], nodes[20] };
            nodes[11].NodeNeighbors = new List<Node> { nodes[3], nodes[12], nodes[10] };
            nodes[12].NodeNeighbors = new List<Node> { nodes[13], nodes[22], nodes[11] };
            nodes[13].NodeNeighbors = new List<Node> { nodes[5], nodes[12], nodes[14] };
            nodes[14].NodeNeighbors = new List<Node> { nodes[15], nodes[13], nodes[24] };
            nodes[15].NodeNeighbors = new List<Node> { nodes[7], nodes[16], nodes[14] };
            nodes[16].NodeNeighbors = new List<Node> { nodes[15], nodes[26] };
            nodes[17].NodeNeighbors = new List<Node> { nodes[18], nodes[28] };
            nodes[18].NodeNeighbors = new List<Node> { nodes[8], nodes[17], nodes[19] };
            nodes[19].NodeNeighbors = new List<Node> { nodes[18], nodes[20], nodes[30] };
            nodes[20].NodeNeighbors = new List<Node> { nodes[10], nodes[21], nodes[19] };
            nodes[21].NodeNeighbors = new List<Node> { nodes[20], nodes[22], nodes[32] };
            nodes[22].NodeNeighbors = new List<Node> { nodes[12], nodes[23], nodes[21] };
            nodes[23].NodeNeighbors = new List<Node> { nodes[22], nodes[24], nodes[34] };
            nodes[24].NodeNeighbors = new List<Node> { nodes[14], nodes[25], nodes[23] };
            nodes[25].NodeNeighbors = new List<Node> { nodes[24], nodes[26], nodes[36] };
            nodes[26].NodeNeighbors = new List<Node> { nodes[16], nodes[27], nodes[25] };
            nodes[27].NodeNeighbors = new List<Node> { nodes[26], nodes[38] };
            nodes[28].NodeNeighbors = new List<Node> { nodes[17], nodes[29] };
            nodes[29].NodeNeighbors = new List<Node> { nodes[28], nodes[39], nodes[30] };
            nodes[30].NodeNeighbors = new List<Node> { nodes[19], nodes[31], nodes[29] };
            nodes[31].NodeNeighbors = new List<Node> { nodes[32], nodes[30], nodes[41] };
            nodes[32].NodeNeighbors = new List<Node> { nodes[21], nodes[31], nodes[33] };
            nodes[33].NodeNeighbors = new List<Node> { nodes[32], nodes[34], nodes[43] };
            nodes[34].NodeNeighbors = new List<Node> { nodes[35], nodes[23], nodes[33] };
            nodes[35].NodeNeighbors = new List<Node> { nodes[36], nodes[34], nodes[45] };
            nodes[36].NodeNeighbors = new List<Node> { nodes[37], nodes[35], nodes[25] };
            nodes[37].NodeNeighbors = new List<Node> { nodes[38], nodes[36], nodes[47] };
            nodes[38].NodeNeighbors = new List<Node> { nodes[27], nodes[37] };
            nodes[39].NodeNeighbors = new List<Node> { nodes[29], nodes[40] };
            nodes[40].NodeNeighbors = new List<Node> { nodes[39], nodes[41], nodes[48] };
            nodes[41].NodeNeighbors = new List<Node> { nodes[31], nodes[42], nodes[40] };
            nodes[42].NodeNeighbors = new List<Node> { nodes[41], nodes[43], nodes[50] };
            nodes[43].NodeNeighbors = new List<Node> { nodes[42], nodes[44], nodes[33] };
            nodes[44].NodeNeighbors = new List<Node> { nodes[43], nodes[45], nodes[52] };
            nodes[45].NodeNeighbors = new List<Node> { nodes[44], nodes[46], nodes[35] };
            nodes[46].NodeNeighbors = new List<Node> { nodes[45], nodes[47], nodes[54] };
            nodes[47].NodeNeighbors = new List<Node> { nodes[46], nodes[37] };
            nodes[48].NodeNeighbors = new List<Node> { nodes[40], nodes[49] };
            nodes[49].NodeNeighbors = new List<Node> { nodes[48], nodes[50] };
            nodes[50].NodeNeighbors = new List<Node> { nodes[49], nodes[51], nodes[42] };
            nodes[51].NodeNeighbors = new List<Node> { nodes[50], nodes[52] };
            nodes[52].NodeNeighbors = new List<Node> { nodes[51], nodes[53], nodes[44] };
            nodes[53].NodeNeighbors = new List<Node> { nodes[52], nodes[54]};
            nodes[54].NodeNeighbors = new List<Node> { nodes[46], nodes[53] };
        }
        
        public void MoveRobber(Hex hex)
        {
            foreach (Hex ihex in hexes)
            {
                if (ihex.HasRobber == true)
                {
                    ihex.HasRobber = false;
                    break;
                }
            }

            hex.HasRobber = true;
        }

        //populate lists of neighbors in each

        // GETTERS AND SETTERS
        public List<Node> Nodes { get { return this.nodes; } set { this.nodes = value; } }
        public List<Hex> Hexes { get { return this.hexes; } set { this.hexes = value; } }
    }
}
