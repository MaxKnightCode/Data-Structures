using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NormalAssGraph
{
    internal class GraphMaker
    {
        int X;
        int Y;

        public Graph<Point> output;

        public Dictionary<Point, Vertex<Point>> points = new();

        public GraphMaker(int x, int y)
        {
            X = x;
            Y = y;

            output = new Graph<Point>(null);



            for (int f = 0; f < Y; f++)
            {
                for (int i = 0; i < X; i++)
                {
                    points.Add(new Point(i, f), new Vertex<Point>(new Point(i, f)));
                }
            }

            List<Point> Keys = points.Keys.ToList<Point>();

            for (int f = 0; f < points.Count; f++)
            {
                output.AddVertex(points[Keys[f]]);
            }




            for (int i = 0; i < points.Count; i++)
            {



                //left

                output.AddEdge(points[Keys[i]], points.GetValueOrDefault(new Point(Keys[i].X - 1, Keys[i].Y)));


                //right

                output.AddEdge(points[Keys[i]], points.GetValueOrDefault(new Point(Keys[i].X + 1, Keys[i].Y)));

                //up

                output.AddEdge(points[Keys[i]], points.GetValueOrDefault(new Point(Keys[i].X, Keys[i].Y + 1)));

                //down

                output.AddEdge(points[Keys[i]], points.GetValueOrDefault(new Point(Keys[i].X, Keys[i].Y - 1)));
            }



            
            output.RemoveEdge(points[Keys[10]], points[Keys[17]]);
            output.AddEdge(points[Keys[10]], points[Keys[17]], 100);

            output.RemoveEdge(points[Keys[11]], points[Keys[18]]);
            output.AddEdge(points[Keys[11]], points[Keys[18]], 100);

            
            output.RemoveEdge(points[Keys[12]], points[Keys[19]]);
            output.AddEdge(points[Keys[12]], points[Keys[19]], 100);

            output.RemoveEdge(points[Keys[16]], points[Keys[17]]);
            output.AddEdge(points[Keys[16]], points[Keys[17]], 100);

            output.RemoveEdge(points[Keys[23]], points[Keys[24]]);
            output.AddEdge(points[Keys[23]], points[Keys[24]], 100);

            output.RemoveEdge(points[Keys[30]], points[Keys[31]]);
            output.AddEdge(points[Keys[30]], points[Keys[31]], 100);

            output.RemoveEdge(points[Keys[37]], points[Keys[38]]);
            output.AddEdge(points[Keys[37]], points[Keys[38]], 100);



        }





    }
}
