using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SearchBreathing
{
    public partial class Form1 : Form
    {
        private string startingDirectory;
        private string fileName;
        private bool findAll;
        private string searchType;

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonFolderBrowser_Click(object sender, EventArgs e)
        {
            DialogResult result = fbd.ShowDialog();
            if (result == DialogResult.OK)
            {
                startingDirectory = fbd.SelectedPath;
            }
        }

        private void BFS_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;

            if (rb == null)
            {
                MessageBox.Show("Sender is not a RadioButton");
                return;
            }

            if (rb.Checked)
            {
                searchType = "BFS";
            }
        }
        private void DFS_CheckedChanged_1(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;

            if (rb == null)
            {
                MessageBox.Show("Sender is not a RadioButton");
                return;
            }

            if (rb.Checked)
            {
                searchType = "DFS";
            }
        }

        private void inputFileName_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;

            if (tb == null)
            {
                MessageBox.Show("Sender is not a Text Box");
                return;
            }
            else
            {
                fileName = tb.Text;
            }
        }
        private void checkBoxFindAll_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;

            if (cb == null)
            {
                MessageBox.Show("Sender is not a Check Box");
            }
            else
            {
                findAll = cb.Checked;
            }
        }

        private void search_Click(object sender, EventArgs e)
        {
            // call bfs or dfs function
            if (searchType == "BFS")
            {
                // call bfs function, with params
                // startingDirectory    - directory awal
                // fileName             - nama file yang dicar
                // findAll              - bool, if true cari semuanya
            }
            else if (searchType == "DFS")
            {
                // call dfs function, with params
                // startingDirectory    - directory awal
                // fileName             - nama file yang dicar
                // findAll              - bool, if true cari semuany
            }
        }

    }
}
