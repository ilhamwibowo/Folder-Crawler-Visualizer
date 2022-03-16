namespace SearchBreathing
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelTitle = new System.Windows.Forms.Label();
            this.buttonFolderBrowser = new System.Windows.Forms.Button();
            this.DFS = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.fbd = new System.Windows.Forms.FolderBrowserDialog();
            this.inputFileName = new System.Windows.Forms.TextBox();
            this.search = new System.Windows.Forms.Button();
            this.checkBoxFindAll = new System.Windows.Forms.CheckBox();
            this.labelFolderBrowser = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.BFS = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(294, 22);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(412, 74);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Folder Crawling";
            // 
            // buttonFolderBrowser
            // 
            this.buttonFolderBrowser.Location = new System.Drawing.Point(145, 200);
            this.buttonFolderBrowser.Name = "buttonFolderBrowser";
            this.buttonFolderBrowser.Size = new System.Drawing.Size(99, 31);
            this.buttonFolderBrowser.TabIndex = 1;
            this.buttonFolderBrowser.Text = "Choose Folder";
            this.buttonFolderBrowser.UseVisualStyleBackColor = true;
            this.buttonFolderBrowser.Click += new System.EventHandler(this.buttonFolderBrowser_Click);
            // 
            // DFS
            // 
            this.DFS.AutoSize = true;
            this.DFS.Location = new System.Drawing.Point(221, 386);
            this.DFS.Name = "DFS";
            this.DFS.Size = new System.Drawing.Size(46, 17);
            this.DFS.TabIndex = 3;
            this.DFS.TabStop = true;
            this.DFS.Text = "DFS";
            this.DFS.UseVisualStyleBackColor = true;
            this.DFS.CheckedChanged += new System.EventHandler(this.DFS_CheckedChanged_1);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            // 
            // fbd
            // 
            this.fbd.SelectedPath = " ";
            // 
            // inputFileName
            // 
            this.inputFileName.Location = new System.Drawing.Point(145, 283);
            this.inputFileName.Name = "inputFileName";
            this.inputFileName.Size = new System.Drawing.Size(138, 20);
            this.inputFileName.TabIndex = 4;
            this.inputFileName.Text = "e.g. \"Tubes 2 Stima.pdf\"";
            this.inputFileName.Click += new System.EventHandler(this.inputFileName_OnClick);
            this.inputFileName.TextChanged += new System.EventHandler(this.inputFileName_TextChanged);
            // 
            // search
            // 
            this.search.Location = new System.Drawing.Point(160, 420);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(98, 31);
            this.search.TabIndex = 5;
            this.search.Text = "Search";
            this.search.UseVisualStyleBackColor = true;
            this.search.Click += new System.EventHandler(this.search_Click);
            // 
            // checkBoxFindAll
            // 
            this.checkBoxFindAll.AutoSize = true;
            this.checkBoxFindAll.Location = new System.Drawing.Point(145, 323);
            this.checkBoxFindAll.Name = "checkBoxFindAll";
            this.checkBoxFindAll.Size = new System.Drawing.Size(113, 17);
            this.checkBoxFindAll.TabIndex = 6;
            this.checkBoxFindAll.Text = "Find all occurence";
            this.checkBoxFindAll.UseVisualStyleBackColor = true;
            this.checkBoxFindAll.CheckedChanged += new System.EventHandler(this.checkBoxFindAll_CheckedChanged);
            // 
            // labelFolderBrowser
            // 
            this.labelFolderBrowser.AutoSize = true;
            this.labelFolderBrowser.BackColor = System.Drawing.Color.Transparent;
            this.labelFolderBrowser.Location = new System.Drawing.Point(268, 209);
            this.labelFolderBrowser.Name = "labelFolderBrowser";
            this.labelFolderBrowser.Size = new System.Drawing.Size(79, 13);
            this.labelFolderBrowser.TabIndex = 7;
            this.labelFolderBrowser.Text = "No File Chosen";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.label2.Location = new System.Drawing.Point(142, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Choose Starting Directory";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(142, 251);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Input File Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(142, 356);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "Input Metode Pencarian";
            // 
            // BFS
            // 
            this.BFS.AutoSize = true;
            this.BFS.Location = new System.Drawing.Point(145, 386);
            this.BFS.Name = "BFS";
            this.BFS.Size = new System.Drawing.Size(45, 17);
            this.BFS.TabIndex = 2;
            this.BFS.TabStop = true;
            this.BFS.Text = "BFS";
            this.BFS.UseVisualStyleBackColor = true;
            this.BFS.CheckedChanged += new System.EventHandler(this.BFS_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1020, 547);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelFolderBrowser);
            this.Controls.Add(this.checkBoxFindAll);
            this.Controls.Add(this.search);
            this.Controls.Add(this.inputFileName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DFS);
            this.Controls.Add(this.BFS);
            this.Controls.Add(this.buttonFolderBrowser);
            this.Controls.Add(this.labelTitle);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Button buttonFolderBrowser;
        private System.Windows.Forms.RadioButton DFS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog fbd;
        private System.Windows.Forms.TextBox inputFileName;
        private System.Windows.Forms.Button search;
        private System.Windows.Forms.CheckBox checkBoxFindAll;
        private System.Windows.Forms.Label labelFolderBrowser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton BFS;
        // private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        // private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        // private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
    }
}

