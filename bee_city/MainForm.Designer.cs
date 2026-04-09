namespace bee_city
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            pictureBox1 = new PictureBox();
            splitContainer1 = new SplitContainer();
            treeView = new TreeView();
            showTable = new DataGridView();
            menuStrip1 = new MenuStrip();
            LoadMenuItem = new ToolStripMenuItem();
            ShowMenuItem = new ToolStripMenuItem();
            CloseMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)showTable).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(40, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(148, 221);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // splitContainer1
            // 
            splitContainer1.Location = new Point(-2, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.BackColor = Color.White;
            splitContainer1.Panel1.Controls.Add(treeView);
            splitContainer1.Panel1.Controls.Add(pictureBox1);
            splitContainer1.Panel1.ForeColor = SystemColors.ActiveCaptionText;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = Color.Bisque;
            splitContainer1.Panel2.Controls.Add(showTable);
            splitContainer1.Panel2.Controls.Add(menuStrip1);
            splitContainer1.Size = new Size(1384, 908);
            splitContainer1.SplitterDistance = 403;
            splitContainer1.TabIndex = 1;
            // 
            // treeView
            // 
            treeView.Location = new Point(14, 239);
            treeView.Name = "treeView";
            treeView.Size = new Size(372, 606);
            treeView.TabIndex = 1;
            // 
            // showTable
            // 
            showTable.BackgroundColor = SystemColors.Info;
            showTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            showTable.Location = new Point(33, 85);
            showTable.Name = "showTable";
            showTable.RowHeadersWidth = 51;
            showTable.Size = new Size(903, 331);
            showTable.TabIndex = 1;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { LoadMenuItem, ShowMenuItem, CloseMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(977, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // LoadMenuItem
            // 
            LoadMenuItem.Name = "LoadMenuItem";
            LoadMenuItem.Size = new Size(91, 24);
            LoadMenuItem.Text = "Загрузить";
            LoadMenuItem.Click += LoadMenuItem_Click;
            // 
            // ShowMenuItem
            // 
            ShowMenuItem.Name = "ShowMenuItem";
            ShowMenuItem.Size = new Size(87, 24);
            ShowMenuItem.Text = "Показать";
            ShowMenuItem.Click += ShowMenuItem_Click;
            // 
            // CloseMenuItem
            // 
            CloseMenuItem.Name = "CloseMenuItem";
            CloseMenuItem.Size = new Size(80, 24);
            CloseMenuItem.Text = "Закрыть";
            CloseMenuItem.Click += CloseMenuItem_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1382, 857);
            Controls.Add(splitContainer1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "Пасека «Пчёлка»";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)showTable).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private SplitContainer splitContainer1;
        private TreeView treeView;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem LoadMenuItem;
        private ToolStripMenuItem ShowMenuItem;
        private ToolStripMenuItem CloseMenuItem;
        private DataGridView showTable;
    }
}
