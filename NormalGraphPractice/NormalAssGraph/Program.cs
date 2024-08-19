using System.Drawing;
using System.Text.Json;

namespace NormalAssGraph
{
    struct Flight
    {
        public string Start { get; set; }
        public string End { get; set; }
        public int Distance { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");


            GraphMaker NewGraph = new GraphMaker(7, 6);
            //Graph TheGraph = NewGraph.output;

            
            var flights = JsonSerializer.Deserialize<Flight[]>(File.ReadAllText("../../../AirportProblemEdges.json"));
            var airports = JsonSerializer.Deserialize<string[]>(File.ReadAllText("../../../AirportProblemVerticies.json"));
            //TheGraph.Goal = TheGraph.Search(new Point(3, 2));


            Graph<string> AirportGraph = new Graph<string>(null);

            for(int i = 0; i < airports.Length; i ++)
            {

                Vertex<string> temp = new Vertex<string>(airports[i]); 

                AirportGraph.AddVertex(temp);
            }


            for(int i = 0; i < flights.Length; i ++)
            {
                AirportGraph.AddEdge(AirportGraph.Search(flights[i].Start), AirportGraph.Search(flights[i].End), flights[i].Distance);
            }

            AirportGraph.Goal = AirportGraph.Search("IND");


            //List<Edge<Point>> check1 = TheGraph.GraphTraversal(TheGraph.Search(new Point(0,0)), TheGraph.Search(new Point(3, 2)), TheGraph.DepthFirstSearch);
            //List<Edge<Point>> check2 = TheGraph.GraphTraversal(TheGraph.Search(new Point(0, 0)), TheGraph.Search(new Point(3, 2)), TheGraph.BreadthFirstSearch);
            //List<Edge> check2 = TheGraph.GraphTraversal(TheGraph.Search(new Point(0, 0)), TheGraph.UniformSearch);
            List<Edge<string>> check2 = AirportGraph.GraphTraversal(AirportGraph.Search("CVG"), AirportGraph.UniformSearch);
            //List<Edge<>>
            ;

        }
    }
}