namespace UWUDGraph
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            int[] ToAdd = { 1, 2, 3 , 4};
            List<Vertex<int>> test = new List<Vertex<int>>();

            for(int i = 0; i < ToAdd.Length; i++)
            {
                test.Add(new Vertex<int>(ToAdd[i]));
            }




            Graph<int> graphy = new Graph<int>();

            for(int i = 0; i < test.Count; i++)
            {
                graphy.AddVertex(test[i]);//erm
            }

            
            graphy.AddEdge(test[0], test[1]);
            graphy.AddEdge(test[0], test[2]);
            graphy.AddEdge(test[0], test[3]);
            graphy.AddEdge(test[2], test[3]);




            ;

        }
    }
}