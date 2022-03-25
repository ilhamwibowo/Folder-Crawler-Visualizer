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
        public List<string> result;

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
            string url = "";
            
            _ = new List<string>();
            if (searchType == "DFS")
            {
                this.result = DFS.TraverseTree(startingDirectory, fileName, ref graph, findAll);
                
            } 
            else // Kasus "BFS"
            {
                BFS bfs = new BFS(startingDirectory, fileName, findAll);
                this.result = bfs.getSolution();
                graph = bfs.getGraph();
            }

            linkLabel1.LinkClicked += new LinkLabelLinkClickedEventHandler(linkLabel1_LinkClicked);

            if (this.result.Count == 0)
                linkLabel1.Text = "Not Founded";
            else if (this.result.Count == 1)
                linkLabel1.Text = this.result[0];
            else
            {
                for (int i =0;i<this.result.Count; i++)
                {
                    url += this.result[i];
                    url += "\n"; 
                }
                linkLabel1.Text = url; // harus ditambahin buat result > 1

                foreach ( string path in this.result )
                {
                    linkLabel1.Links.Add(url.IndexOf(path), path.Length);
                }
            }

            graph.Attr.LayerDirection = LayerDirection.TB; // biar jadi kayak tree
            gViewer1.Graph = graph;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = "";

            int i = linkLabel1.Links.IndexOf(e.Link);
            url = this.result[i];
            url = url.Substring(0, url.IndexOf(this.fileName));

            e.Link.Visited = true;

            System.Diagnostics.Process.Start(url);
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
