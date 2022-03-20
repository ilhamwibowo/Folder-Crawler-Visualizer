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
        private string _startingDirectory;
        private string _fileName;
        private bool _findAll;
        private string _searchType;
        private int numberOfClick = 0;

        public string startingDirectory
        {
            get
            {
                return _startingDirectory;
            }
        }
        public string fileName
        {
            get
            {
                return _fileName;
            }
        }
        public bool findAll
        {
            get
            {
                return _findAll;
            }
        }
        public string searchType
        {
            get
            {
                return _searchType;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonFolderBrowser_Click(object sender, EventArgs e)
        {
            DialogResult result = fbd.ShowDialog();
            if (result == DialogResult.OK)
            {
                _startingDirectory = fbd.SelectedPath;
                labelFolderBrowser.Text = _startingDirectory;
                buttonFolderBrowser.Text = "Change Folder..";
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
                _searchType = "BFS";
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
                _searchType = "DFS";
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
                _fileName = tb.Text;
            }
        }

        private void inputFileName_OnClick(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            numberOfClick++;
            if(numberOfClick == 1)
                tb.Clear();
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
                _findAll = cb.Checked;
            }
        }

        private void search_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2(startingDirectory, fileName, searchType, findAll);
            form.Show();
        }
    }
}
