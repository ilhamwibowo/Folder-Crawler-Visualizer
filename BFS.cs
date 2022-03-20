using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Msagl.Drawing;
using Microsoft.Msagl.WpfGraphControl;
using Microsoft.Msagl.GraphViewerGdi;


//NOTES
//make graf
//Kalo ada file/folder yang sama, bakal jadi satu node, belum bisa bikin dua node beda


namespace SearchBreathing
{
    public class BFS
    {
        public List<string> solution;
        public Graph graph;

        public BFS(string dir, string filename, bool findall)
        {
            solution = new List<string>();
            graph = new Graph();
            solution = bfs(dir, filename, findall);
        }

        public List<string> getSolution()
        {
            return solution;
        }

        public Graph getGraph()
        {
            return graph;
        }

        public List<string> bfs(string dir, string filename, bool findall)
        {
            List<string> solution = new List<string>();
            string currentdir;
            Queue<string> q = new Queue<string>();
            q.Enqueue(dir);

            while (q.Count > 0)
            {
                currentdir = q.Dequeue();

                //enqueue folders
                foreach (string di in Directory.GetDirectories(currentdir))
                {
                    q.Enqueue(di);
                    this.graph.AddEdge(Path.GetFileName(currentdir), Path.GetFileName(di));
                }

                //search filename
                //if file found, break loop, returns path to file
                foreach (string f in Directory.GetFiles(currentdir))
                {
                    this.graph.AddEdge(Path.GetFileName(currentdir), Path.GetFileName(f));
                    if (Path.GetFileName(f) == filename)
                    {
                        solution.Add(f);
                        if (!findall)
                        {
                            return solution;
                        }
                    }
                }


            }

            return solution;

        }
    }
}
