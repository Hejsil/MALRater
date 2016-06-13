namespace MALRater.Forms
{
    partial class MainWindow
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ratingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importMALToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportMALToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.rateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recalcScoreToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.rateUnratedToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guideToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.ratedListBox = new System.Windows.Forms.ListBox();
            this.dontrateListBox = new System.Windows.Forms.ListBox();
            this.unratedListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.malListView = new System.Windows.Forms.ListView();
            this.title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.score = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem,
            this.rateToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(671, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip";
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStrip,
            this.openToolStrip,
            this.toolStripSeparator1,
            this.saveToolStrip,
            this.saveAsToolStrip,
            this.toolStripSeparator2,
            this.ratingsToolStripMenuItem,
            this.exportToolStripMenuItem});
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.importToolStripMenuItem.Text = "File";
            // 
            // newToolStrip
            // 
            this.newToolStrip.Name = "newToolStrip";
            this.newToolStrip.Size = new System.Drawing.Size(155, 22);
            this.newToolStrip.Text = "New";
            this.newToolStrip.Click += new System.EventHandler(this.newToolStrip_Click);
            // 
            // openToolStrip
            // 
            this.openToolStrip.Name = "openToolStrip";
            this.openToolStrip.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStrip.Size = new System.Drawing.Size(155, 22);
            this.openToolStrip.Text = "Open...";
            this.openToolStrip.Click += new System.EventHandler(this.openToolStrip_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(152, 6);
            // 
            // saveToolStrip
            // 
            this.saveToolStrip.Name = "saveToolStrip";
            this.saveToolStrip.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStrip.Size = new System.Drawing.Size(155, 22);
            this.saveToolStrip.Text = "Save";
            this.saveToolStrip.Click += new System.EventHandler(this.saveToolStrip_Click);
            // 
            // saveAsToolStrip
            // 
            this.saveAsToolStrip.Name = "saveAsToolStrip";
            this.saveAsToolStrip.Size = new System.Drawing.Size(155, 22);
            this.saveAsToolStrip.Text = "Save As...";
            this.saveAsToolStrip.Click += new System.EventHandler(this.saveAsToolStrip_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(152, 6);
            // 
            // ratingsToolStripMenuItem
            // 
            this.ratingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importMALToolStrip});
            this.ratingsToolStripMenuItem.Name = "ratingsToolStripMenuItem";
            this.ratingsToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.ratingsToolStripMenuItem.Text = "Import";
            // 
            // importMALToolStrip
            // 
            this.importMALToolStrip.Name = "importMALToolStrip";
            this.importMALToolStrip.Size = new System.Drawing.Size(159, 22);
            this.importMALToolStrip.Text = "My Anime List...";
            this.importMALToolStrip.Click += new System.EventHandler(this.importMALToolStrip_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportMALToolStrip});
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.exportToolStripMenuItem.Text = "Export";
            // 
            // exportMALToolStrip
            // 
            this.exportMALToolStrip.Enabled = false;
            this.exportMALToolStrip.Name = "exportMALToolStrip";
            this.exportMALToolStrip.Size = new System.Drawing.Size(159, 22);
            this.exportMALToolStrip.Text = "My Anime List...";
            this.exportMALToolStrip.Click += new System.EventHandler(this.exportMALToolStrip_Click);
            // 
            // rateToolStripMenuItem
            // 
            this.rateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.recalcScoreToolStrip,
            this.rateUnratedToolStrip});
            this.rateToolStripMenuItem.Name = "rateToolStripMenuItem";
            this.rateToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.rateToolStripMenuItem.Text = "Rate";
            // 
            // recalcScoreToolStrip
            // 
            this.recalcScoreToolStrip.Enabled = false;
            this.recalcScoreToolStrip.Name = "recalcScoreToolStrip";
            this.recalcScoreToolStrip.Size = new System.Drawing.Size(194, 22);
            this.recalcScoreToolStrip.Text = "Recalculate Scores";
            this.recalcScoreToolStrip.Click += new System.EventHandler(this.recalcScoreToolStrip_Click);
            // 
            // rateUnratedToolStrip
            // 
            this.rateUnratedToolStrip.Enabled = false;
            this.rateUnratedToolStrip.Name = "rateUnratedToolStrip";
            this.rateUnratedToolStrip.Size = new System.Drawing.Size(194, 22);
            this.rateUnratedToolStrip.Text = "Rate Unrated Animes...";
            this.rateUnratedToolStrip.Click += new System.EventHandler(this.rateUnratedToolStrip_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.guideToolStrip});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // guideToolStrip
            // 
            this.guideToolStrip.Name = "guideToolStrip";
            this.guideToolStrip.Size = new System.Drawing.Size(114, 22);
            this.guideToolStrip.Text = "Guide...";
            this.guideToolStrip.Click += new System.EventHandler(this.guideToolStrip_Click);
            // 
            // ratedListBox
            // 
            this.ratedListBox.FormattingEnabled = true;
            this.ratedListBox.Location = new System.Drawing.Point(12, 46);
            this.ratedListBox.Name = "ratedListBox";
            this.ratedListBox.Size = new System.Drawing.Size(120, 290);
            this.ratedListBox.TabIndex = 1;
            // 
            // dontrateListBox
            // 
            this.dontrateListBox.FormattingEnabled = true;
            this.dontrateListBox.Location = new System.Drawing.Point(138, 46);
            this.dontrateListBox.Name = "dontrateListBox";
            this.dontrateListBox.Size = new System.Drawing.Size(120, 290);
            this.dontrateListBox.TabIndex = 2;
            // 
            // unratedListBox
            // 
            this.unratedListBox.FormattingEnabled = true;
            this.unratedListBox.Location = new System.Drawing.Point(264, 46);
            this.unratedListBox.Name = "unratedListBox";
            this.unratedListBox.Size = new System.Drawing.Size(120, 290);
            this.unratedListBox.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Rated";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(135, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Don\'t Rate";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(387, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "My Anime List";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(261, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Unrated";
            // 
            // malListView
            // 
            this.malListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.title,
            this.score});
            this.malListView.GridLines = true;
            this.malListView.Location = new System.Drawing.Point(390, 46);
            this.malListView.Name = "malListView";
            this.malListView.Size = new System.Drawing.Size(257, 289);
            this.malListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.malListView.TabIndex = 9;
            this.malListView.UseCompatibleStateImageBehavior = false;
            this.malListView.View = System.Windows.Forms.View.Details;
            // 
            // title
            // 
            this.title.Text = "Title";
            this.title.Width = 191;
            // 
            // score
            // 
            this.score.Text = "Score";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(671, 432);
            this.Controls.Add(this.malListView);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.unratedListBox);
            this.Controls.Add(this.dontrateListBox);
            this.Controls.Add(this.ratedListBox);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guideToolStrip;
        private System.Windows.Forms.ListBox ratedListBox;
        private System.Windows.Forms.ListBox dontrateListBox;
        private System.Windows.Forms.ListBox unratedListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ratingsToolStripMenuItem;
        private System.Windows.Forms.ListView malListView;
        private System.Windows.Forms.ToolStripMenuItem rateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recalcScoreToolStrip;
        private System.Windows.Forms.ToolStripMenuItem rateUnratedToolStrip;
        private System.Windows.Forms.ColumnHeader title;
        private System.Windows.Forms.ColumnHeader score;
        private System.Windows.Forms.ToolStripMenuItem newToolStrip;
        private System.Windows.Forms.ToolStripMenuItem openToolStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStrip;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem importMALToolStrip;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportMALToolStrip;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

