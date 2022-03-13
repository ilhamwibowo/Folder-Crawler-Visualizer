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
            this.BFS = new System.Windows.Forms.RadioButton();
            this.DFS = new System.Windows.Forms.RadioButton();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
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
            this.buttonFolderBrowser.Location = new System.Drawing.Point(442, 153);
            this.buttonFolderBrowser.Name = "buttonFolderBrowser";
            this.buttonFolderBrowser.Size = new System.Drawing.Size(78, 31);
            this.buttonFolderBrowser.TabIndex = 1;
            this.buttonFolderBrowser.Text = "button1";
            this.buttonFolderBrowser.UseVisualStyleBackColor = true;
            this.buttonFolderBrowser.Click += new System.EventHandler(this.buttonFolderBrowser_Click);
            // 
            // BFS
            // 
            this.BFS.AutoSize = true;
            this.BFS.Location = new System.Drawing.Point(317, 309);
            this.BFS.Name = "BFS";
            this.BFS.Size = new System.Drawing.Size(45, 17);
            this.BFS.TabIndex = 2;
            this.BFS.TabStop = true;
            this.BFS.Text = "BFS";
            this.BFS.UseVisualStyleBackColor = true;
            // 
            // DFS
            // 
            this.DFS.AutoSize = true;
            this.DFS.Location = new System.Drawing.Point(435, 309);
            this.DFS.Name = "DFS";
            this.DFS.Size = new System.Drawing.Size(46, 17);
            this.DFS.TabIndex = 3;
            this.DFS.TabStop = true;
            this.DFS.Text = "DFS";
            this.DFS.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 547);
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
        private System.Windows.Forms.RadioButton BFS;
        private System.Windows.Forms.RadioButton DFS;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
    }
}

