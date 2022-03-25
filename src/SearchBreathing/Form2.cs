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

namespace SearchBreathing
{
    public partial class Form2 : Form
    {
        public string startingDirectory;
        public string fileName;
        public string searchType;
        public bool findAll;

        public Form2(string startingDirectory, string fileName, string searchType, bool findAll)
        {
            InitializeComponent();
            this.startingDirectory = startingDirectory;
            this.fileName = fileName;
            this.searchType = searchType;
            this.findAll = findAll;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // gViewer1 viewer = new gViewer1();
            Graph graph = new Graph();
            
            _ = new List<string>();
            if (searchType == "DFS")
            {
                List<string> result = DFS.TraverseTree(startingDirectory, fileName, ref graph, findAll);
                if (result.Count == 0)
                    linkLabel1.Text = "Not Founded";
                else if (result.Count == 1)
                    linkLabel1.Text = result[0];
                else
                    linkLabel1.Text = result[0]; // harus ditambahin buat result > 1
            } 
            else // Kasus "BFS"
            {
                BFS bfs = new BFS(startingDirectory, fileName, findAll);
                List<string> result = bfs.getSolution();
                graph = bfs.getGraph();
                if (result.Count == 0)
                {
                    linkLabel1.Text = "Not Found";
                }
                else if (result.Count == 1)
                {
                    linkLabel1.Text = result[0];
                }
                else
                {
                    linkLabel1.Text = result[0];
                }
            }

            graph.Attr.LayerDirection = LayerDirection.TB; // biar jadi kayak tree
            gViewer1.Graph = graph;

            // linkLabel1.Text = "Education"; // ganti jadi path jawaban
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1.LinkVisited = true;
            System.Diagnostics.Process.Start(linkLabel1.Text); // harus ditambahin buat result > 1
            // System.Diagnostics.Process.Start(@"D:\Education"); // ganti path nya jadi jawaban
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
