using System;
using System.Collections.Generic;
using System.Text;

namespace Catanv3
{
    class Map
    {
        private List<Node> nodes = new List<Node>();

        public List<Node> Nodes
        {
            get
            {
                return this.nodes;
            }
        }
        private List<Hex> hexes = new List<Hex>();

        public List<Hex> Hexes
        {
            get { return this.hexes; }
        }

        public Map()
        {
            initHexes();
            initNodes();
            connect();
            makePorts();
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

        //create all new hexes, add to list
        private void initHexes()
        {
            //for loop 1..19 hexurile cu resurse pe ele
            //genererare RELEVANTA, CU CAP a resursa, numar -> apelare constructor cu toate

            //for loop 1..18 hexurile cu ocean de pe exterior -> folosire constructor doar cu id

            int clay = 0, wood = 0, wheat = 0, sheep = 0, stone = 0, desert = 0;
            int[] tokens = new int[13];

            tokens[2] = 1;
            tokens[12] = 1;

            for (int i = 2; i <= 12; i++)
            {
                tokens[i] = 2;
            }

            Random rand = new Random();

            int ind = rand.Next(2, 13);
            int randomToken = tokens[ind];
            tokens[ind]--;

            //Hex hexItem = new Hex(0, Resources.None, 0);

            for (int i = 1; i <= 19; i++)
            {

                //var values = Enum.GetValues(typeof(Resources));
                List<String> resources = new List<String>() { "Wheat", "Sheep", "Wood", "Clay", "Desert" };

                String randomResource = resources[rand.Next(0, resources.Count)];

                while (randomToken == 0)
                {
                    ind = rand.Next(2, 13);
                    randomToken = tokens[ind];

                }
                tokens[ind]--;

                bool generated = false;

                while (!generated)
                {
                    switch (randomResource)
                    {
                        case "Clay":
                            if (++clay < (int)Resources.Clay)
                            {
                                Hex hexItem = new Hex(i, Resources.Clay, randomToken);
                                generated = true;
                            }
                            else
                            {
                                randomResource = resources[rand.Next(0, resources.Count)];
                            }
                            break;

                        case "Wheat":
                            if (++wheat < (int)Resources.Wheat)
                            {
                                Hex hexItem = new Hex(i, Resources.Wheat, randomToken);
                                generated = true;
                            }
                            else
                            {
                                randomResource = resources[rand.Next(0, resources.Count)];
                            }
                            break;


                        case "Wood":
                            if (++wood < (int)Resources.Wood)
                            {
                                Hex hexItem = new Hex(i, Resources.Wood, randomToken);
                                generated = true;
                            }
                            else
                            {
                                randomResource = resources[rand.Next(0, resources.Count)];
                            }
                            break;

                        case "Stone":
                            if (++stone < (int)Resources.Stone)
                            {
                                Hex hexItem = new Hex(i, Resources.Stone, randomToken);
                                generated = true;
                            }
                            else
                            {
                                randomResource = resources[rand.Next(0, resources.Count)];
                            }
                            break;

                        case "Sheep":
                            if (++sheep < (int)Resources.Sheep)
                            {
                                Hex hexItem = new Hex(i, Resources.Sheep, randomToken);
                                generated = true;
                            }
                            else
                            {
                                randomResource = resources[rand.Next(0, resources.Count)];
                            }
                            break;

                        case "Desert":
                            if (++desert < (int)Resources.Desert)
                            {
                                Hex hexItem = new Hex(i, Resources.Desert, randomToken);
                                generated = true;
                            }
                            else
                            {
                                randomResource = resources[rand.Next(0, resources.Count)];
                            }
                            break;

                        default:
                            Console.WriteLine("eraore");
                            break;
                    }
                }

            }


            //oceane exterioare
            for (int i = 1; i <= 18; i++)
            {
                hexes.Add(new Hex(0 - i));
            }

            foreach (Hex hex in hexes)
            {
                Console.WriteLine(hex);
            }

            foreach (Hex item in hexes)
            {
                if (item.number == 6 || item.number == 8)
                {

                }
            }

        }

        //populate lists of neighbors in each
        private void connect()
        {
            //parcurgere lista de hexuri
            //hex 1 . setlistavecininoduri(new list {1, 2, 3, 9, 10, 11 } etc

            //parcurgere lista de noduri
            //nod1 .setlistavecininoduri (new list {..} etc
            //la fel setlistavecinihexuri
            //necesar creeare setters la listele astea de vecini
        }

        private void makePorts()
        {
            //generare porturi (hardcodate), randomizare doar ce trade au
        }

    }
}
