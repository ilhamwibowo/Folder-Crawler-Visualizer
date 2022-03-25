using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        public String root;
        public BFS(string dir, string filename, bool findall)
        {
            solution = new List<string>();
            graph = new Graph();
            bfs(dir, filename, findall);
            root = Path.GetFileName(filename);
        }

        public List<string> getSolution()
        {
            return solution;
        }

        public Graph getGraph()
        {
            return graph;
        }

        public void bfs(string dir, string filename, bool findall)
        {
            string currentdir;
            Queue<string> q = new Queue<string>();
            q.Enqueue(dir);
            bool stopsearch = false;

            while (q.Count > 0 && !stopsearch)
            {
                currentdir = q.Dequeue();

                //enqueue folders
                foreach (string di in Directory.GetDirectories(currentdir))
                {
                    q.Enqueue(di);
                    addTreeEdge(Path.GetFileName(currentdir), Path.GetFileName(di), ref graph,2);
                    //this.graph.AddEdge(Path.GetFileName(currentdir), Path.GetFileName(di));
                }

                //search filename
                //if file found, break loop, returns path to file
                foreach (string f in Directory.GetFiles(currentdir))
                {
                    if (Path.GetFileName(f) == filename)
                    {
                        this.solution.Add(f);
                        addTreeEdge(Path.GetFileName(currentdir), Path.GetFileName(f), ref graph, 1);
                        if (!findall)
                        {
                            colorQueue(q,ref this.graph);
                            stopsearch = true;
                        }
                    }
                    else
                    {
                        addTreeEdge(Path.GetFileName(currentdir), Path.GetFileName(f), ref graph, 2);
                    }
                }


            }

            //graph = reverseGraph(graph);
            //colorSolution(root, solution, ref graph);

            //warnain 

        }


        public void colorQueue(Queue<string> left, ref Graph graph)
        {
            foreach (string f in left)
            {
                foreach (string s in Directory.GetDirectories(f))
                {
                    graph.AddEdge(Path.GetFileName(f), Path.GetFileName(s)).Attr.Color = Color.Black;
                }
                foreach (string s in Directory.GetFiles(f))
                {
                    graph.AddEdge(Path.GetFileName(f), Path.GetFileName(s)).Attr.Color = Color.Black;
                }

            }
        }


        public static Edge FindEdge(string parent, string child, Graph graph)
        {
            foreach (var e in graph.Edges)
            {
                if (e.Source == parent && e.Target == child)
                    return e;
            }

            return null;
        }
        
        public void colorSolution(string start, List<string> solution, ref Graph graph)
        {
            foreach (string di in solution)
            {
                colorPath(start, Path.GetFileName(di),ref graph);
            }
        }

        public static string FindParent(string leaf, ref Graph graph)
        {
            foreach (var e in graph.Edges)
            {
                if (e.Target == leaf)
                    return e.Source;
            }

            return null;
        }

        public void colorPath(string start, string leaf, ref Graph graph)
        {
            string parent = FindParent(leaf,ref graph);
            if (parent != null)
            {
                graph.RemoveEdge(FindEdge(parent, leaf, graph));
                graph.AddEdge(parent, leaf).Attr.Color = Color.Blue;
                colorPath(start, parent, ref graph);
            }
            
        }

        public bool isNodeExist(Graph graph, string target)
        {
            foreach (var e in graph.Edges)
            {
                if (e.Target == target)
                    return true;
            }

            return false;
        }

        public void addTreeEdge(string parent, string child, ref Graph graph, int target)
        {
            int count = 0;
            string s = child;

            while(isNodeExist(graph,s))
            {
                count = count + 1;
                s = $"{child}({count})";        
            }

            if (target == 1)
            {
                graph.AddEdge(parent, s).Attr.Color = Color.Blue;
                colorPath(root, s, ref graph);
            }
            else if (target == 2)
            {
                graph.AddEdge(parent, s).Attr.Color = Color.Red;
            }
            else
            {
                graph.AddEdge(parent, s).Attr.Color = Color.Black;
            }
            
        }



    }
}