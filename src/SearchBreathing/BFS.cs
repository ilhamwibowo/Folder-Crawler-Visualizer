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
            root = Path.GetFileName(dir);
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
            string currentdir;
            Queue<string> q = new Queue<string>();
            Queue<int> dupes = new Queue<int>();
            q.Enqueue(dir);
            dupes.Enqueue(0);
            bool stopsearch = false;
            int dp;

            while (q.Count > 0 && !stopsearch)
            {
                currentdir = q.Dequeue();
                dp = dupes.Dequeue();

                //enqueue folders
                foreach (string di in Directory.GetDirectories(currentdir))
                {
                    q.Enqueue(di);
                    dupes.Enqueue(countDuplicates(graph, Path.GetFileName(di)));
                    addTreeEdge(Path.GetFileName(currentdir), Path.GetFileName(di), ref graph, 2);
                    //this.graph.AddEdge(Path.GetFileName(currentdir), Path.GetFileName(di));
                }

                //search filename
                //if file found, break loop, returns path to file
                foreach (string f in Directory.GetFiles(currentdir))
                {
                    if (Path.GetFileName(f) == filename)
                    {
                        this.solution.Add(f);
                        if (dp > 0)
                        {
                            string parent = $"{Path.GetFileName(currentdir)}({dp})";
                            addTreeEdge(parent, Path.GetFileName(f), ref graph, 1);
                        }
                        else
                        {
                            addTreeEdge(Path.GetFileName(currentdir), Path.GetFileName(f), ref graph, 1);
                        }
                        
                        if (!findall)
                        {
                            colorQueue(q,dupes, ref this.graph);
                            stopsearch = true;
                        }
                    }
                    else
                    {
                        if (dp > 0)
                        {
                            string parent = $"{Path.GetFileName(currentdir)}({dp})";
                            addTreeEdge(parent, Path.GetFileName(f), ref graph, 2);
                        }
                        else
                        {
                            addTreeEdge(Path.GetFileName(currentdir), Path.GetFileName(f), ref graph, 2);
                        }
                    }
                }


            }

            if (solution.Count == 0)
            {
                graph.FindNode(root).Label.FontColor = Color.Red;
            }
            //graph = reverseGraph(graph);
            //colorSolution(root, solution, ref graph);

            //warnain 

        }

        public int countDuplicates(Graph graph, string target)
        {
            int count = 0;
            foreach (var di in graph.Edges)
            {
                if (di.Target == target)
                {
                    count++;
                }
            }
            return count;
        }

        public void colorQueue(Queue<string> left,Queue<int> dupes, ref Graph graph)
        {
            int dp;
            string parent;
            foreach (string f in left)
            {
                dp = dupes.Dequeue();

                foreach (string s in Directory.GetDirectories(f))
                {
                    if (dp > 0)
                    {
                        parent = $"{Path.GetFileName(f)}({dp})";
                    }
                    else
                    {
                        parent = s;
                    }
                    addTreeEdge(parent, Path.GetFileName(s), ref graph, 3);
                }
                foreach (string s in Directory.GetFiles(f))
                {
                    if (dp > 0)
                    {
                        parent = $"{Path.GetFileName(f)}({dp})";
                    }
                    else
                    {
                        parent = s;
                    }
                    addTreeEdge(parent, Path.GetFileName(s), ref graph, 3);
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
                graph.FindNode(leaf).Label.FontColor = Color.Blue;
                colorPath(start, parent, ref graph);
            }
            graph.FindNode(root).Label.FontColor = Color.Blue;
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
            int count;
            string s;

            count = countDuplicates(graph, child);
            
            if (count > 0)
            {
                s = $"{child}({count})";
            }
            else
            {
                s = child;
            }
           

            if (target == 1)
            {
                graph.AddEdge(parent, s).Attr.Color = Color.Blue;
                graph.FindNode(s).Label.FontColor = Color.Blue;
                
                colorPath(root, s, ref graph);
            }
            else if (target == 2)
            {
                graph.AddEdge(parent, s).Attr.Color = Color.Red;
                graph.FindNode(s).Label.FontColor = Color.Red;
            }
            else
            {
                graph.AddEdge(parent, s).Attr.Color = Color.Black;
                graph.FindNode(s).Label.FontColor = Color.Black;
            }
            
        }



    }
}