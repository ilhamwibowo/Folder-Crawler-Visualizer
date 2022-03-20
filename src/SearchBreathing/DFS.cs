using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Msagl.Drawing;

namespace SearchBreathing
{
    class DFS
    { 
        // masih bisa error kalau banyak filename yang sama
        // hapus graph di akhir pencarian
        static int same = 0;
        public static List<string> TraverseTree(string root, string filename, ref Graph graph, bool findAll)
        {
            Stack<string> dirs = new Stack<string>();
            List<string> result = new List<string>();

            bool founded = false;

            dirs.Push(root);

            while (dirs.Count > 0)
            {
                string currentDir = dirs.Pop();
                string[] subDirs = System.IO.Directory.GetDirectories(currentDir);
                string[] files = System.IO.Directory.GetFiles(currentDir);

                foreach (string file in files)
                {
                    if (GetName(file) == filename)
                    {
                        if (findAll)
                        {
                            founded = false;
                            result.Add(file);
                            AddTree(GetName(currentDir), $"{GetName(file)}({same})", ref graph, 1); 
                            PaintToTheRoot(root, $"{GetName(file)}({same++})", ref graph, 1); 
                            continue;
                        } 
                        else
                        {
                            founded = true;
                            result.Add(file);
                            AddTree(GetName(currentDir), GetName(file), ref graph, 1); 
                            PaintToTheRoot(root, GetName(file), ref graph, 1);
                            continue;
                        }
                    }
                    
                    if (!founded)                    
                        AddTree(GetName(currentDir), GetName(file), ref graph, 2);
                    else if (founded)
                        AddTree(GetName(currentDir), GetName(file), ref graph, 0);    

                }

                foreach (string str in subDirs)
                {
                    AddTree(GetName(currentDir), GetName(str), ref graph, 0);
                    dirs.Push(str);
                }
                
                if (!founded && subDirs.Length == 0)
                    PaintToTheRoot(root, GetName(currentDir), ref graph, 2);
                else if (founded) // --> !findAll
                {
                    PaintToTheRoot(root, result[0], ref graph, 1);
                    break;
                }
            }

            if (result.Count != 0)
            {
                if (findAll)
                {
                    foreach (var i in result)
                    {
                        PaintToTheRoot(root, $"{GetName(i)}({--same})", ref graph, 1);
                    }
                } 
                graph.FindNode(GetName(root)).Label.FontColor = Color.Blue;
            } else
                graph.FindNode(GetName(root)).Label.FontColor = Color.Red;
            same = 0;

            return result;
        }

        public static string FindParent(string leaf, ref Graph graph)
        {
            foreach(var e in graph.Edges)
            {
                if (e.Target == leaf)
                    return e.Source;
            }

            return null;
        }
        
        public static string GetName(string path)
        {
            return System.IO.Path.GetFileName(path);
        }

        public static void PaintToTheRoot(string root, string leaf, ref Graph graph, int color)
        {
            string parent = FindParent(leaf, ref graph);
            if (parent != root && parent != null)
            {
                changeColor(parent, leaf, ref graph, color);
                PaintToTheRoot(root, parent, ref graph, color);
            } 
        }

        public static bool IsNodeExist(string node, ref Graph graph)
        {
            foreach (var e in graph.Edges)
            {
                if (e.Target == node)
                    return true;
            }

            return false;
        }
        public static void AddTree(string parent, string child, ref Graph graph, int color)
        {
            if (IsNodeExist(child, ref graph))
                child = $"{child}({same++})";
            if (color == 0) // In Stack
            {
                graph.AddEdge(parent, child).Attr.Color = Color.Black;
                graph.FindNode(child).Label.FontColor = Color.Black;
            }
            else if (color == 1) // Founded at
            {
                graph.AddEdge(parent, child).Attr.Color = Color.Blue;
                graph.FindNode(child).Label.FontColor = Color.Blue;
            }   
            else if (color == 2) // Not founded
            {
                graph.AddEdge(parent, child).Attr.Color = Color.Red;
                graph.FindNode(child).Label.FontColor = Color.Red;
            }     
        }

        public static void changeColor(string parent, string child, ref Graph graph, int color)
        {
            graph.RemoveEdge(FindEdge(parent, child, graph));
            AddTree(parent, child, ref graph, color);
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
    }
}
