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

        public BFS(string dir, string filename, bool findall)
        {
            solution = new List<string>();
            graph = new Graph();
            bfs(dir, filename, findall);
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
            string root = Path.GetFileName(dir);
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
                    addTreeEdge(root, Path.GetFileName(currentdir), Path.GetFileName(di), ref graph,false);
                    //this.graph.AddEdge(Path.GetFileName(currentdir), Path.GetFileName(di));
                }

                //search filename
                //if file found, break loop, returns path to file
                foreach (string f in Directory.GetFiles(currentdir))
                {
                    if (Path.GetFileName(f) == filename)
                    {
                        this.solution.Add(f);
                        addTreeEdge(root, Path.GetFileName(currentdir), Path.GetFileName(f), ref graph, true);
                        if (!findall)
                        {
                            colorQueue(q,ref this.graph);
                            stopsearch = true;
                        }
                    }
                    else
                    {
                        addTreeEdge(root, Path.GetFileName(currentdir), Path.GetFileName(f), ref graph, false);
                    }
                }


            }

            //colorSolution(root, solution, ref graph);

            //warnain 

        }

        public void colorQueue(Queue<string> left, ref Graph graph)
        {
            string parent;
            foreach (string path in left)
            {
                parent = path.Remove(path.LastIndexOf(@"\"));
                graph.RemoveEdge(FindEdge(Path.GetFileName(parent), Path.GetFileName(path), graph));
                graph.AddEdge(Path.GetFileName(parent), Path.GetFileName(path)).Attr.Color = Color.Black;
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

        public void addTreeEdge(string root, string parent, string child, ref Graph graph, bool target)
        {
            int count = 0;
            string s = child;

            while(isNodeExist(graph,s))
            {
                count = count + 1;
                s = $"{child}({count})";        
            }

            if (target)
            {
                graph.AddEdge(parent, s).Attr.Color = Color.Blue;
                colorPath(root, s, ref graph);
            }
            else
            {
                graph.AddEdge(parent, s).Attr.Color = Color.Red;
            }
            
        }



    }
}