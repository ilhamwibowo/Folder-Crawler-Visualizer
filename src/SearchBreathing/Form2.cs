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

        public Form2(string startingDirectory)
        {
            InitializeComponent();
            this.startingDirectory = startingDirectory;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // gViewer1 viewer = new gViewer1();
            Graph graph = new Graph();

            graph.AddEdge("A", "B");
            graph.AddEdge("A", "C").Attr.Color = Microsoft.Msagl.Drawing.Color.Blue;
            graph.AddEdge("A", "D");
            graph.AddEdge("A", "C").Attr.Color = Microsoft.Msagl.Drawing.Color.PaleGreen;

            // warnain node
            Node c = graph.FindNode("C"); // target
            c.Attr.FillColor = Microsoft.Msagl.Drawing.Color.Blue; //warna

            // warnain edge
            foreach (var edge in graph.Edges)
            {
                if (edge.Target == "C") //target
                {
                    edge.Attr.Color = Microsoft.Msagl.Drawing.Color.AliceBlue; // warna
                }
            }

            graph.Attr.LayerDirection = LayerDirection.TB; // biar jadi kayak tree
            gViewer1.Graph = graph;

            linkLabel1.Text = "Education"; // ganti jadi path jawaban

            // Test 
            var path = Directory.GetDirectories(startingDirectory);
            MessageBox.Show(path[4]);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1.LinkVisited = true;
            System.Diagnostics.Process.Start(@"D:\Education"); // ganti path nya jadi jawaban
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
