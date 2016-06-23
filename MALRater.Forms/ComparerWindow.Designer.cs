namespace MALRater.Forms
{
    partial class ComparerWindow
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
            this.currPicture = new System.Windows.Forms.PictureBox();
            this.dontrateButton = new System.Windows.Forms.Button();
            this.compPicture = new System.Windows.Forms.PictureBox();
            this.currLabel = new System.Windows.Forms.Label();
            this.compLabel = new System.Windows.Forms.Label();
            this.equalButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.currPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.compPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // currPicture
            // 
            this.currPicture.ImageLocation = "http://cdn.myanimelist.net/images/anime/4/79073.jpg";
            this.currPicture.Location = new System.Drawing.Point(12, 25);
            this.currPicture.Name = "currPicture";
            this.currPicture.Size = new System.Drawing.Size(225, 318);
            this.currPicture.TabIndex = 0;
            this.currPicture.TabStop = false;
            this.currPicture.Click += new System.EventHandler(this.currPicture_Click);
            // 
            // dontrateButton
            // 
            this.dontrateButton.Location = new System.Drawing.Point(12, 349);
            this.dontrateButton.Name = "dontrateButton";
            this.dontrateButton.Size = new System.Drawing.Size(225, 23);
            this.dontrateButton.TabIndex = 1;
            this.dontrateButton.Text = "Don\'t Rate";
            this.dontrateButton.UseVisualStyleBackColor = true;
            this.dontrateButton.Click += new System.EventHandler(this.dontrateButton_Click);
            // 
            // compPicture
            // 
            this.compPicture.Location = new System.Drawing.Point(243, 24);
            this.compPicture.Name = "compPicture";
            this.compPicture.Size = new System.Drawing.Size(225, 318);
            this.compPicture.TabIndex = 2;
            this.compPicture.TabStop = false;
            this.compPicture.Click += new System.EventHandler(this.compPicture_Click);
            // 
            // currLabel
            // 
            this.currLabel.AutoSize = true;
            this.currLabel.Location = new System.Drawing.Point(9, 9);
            this.currLabel.Name = "currLabel";
            this.currLabel.Size = new System.Drawing.Size(51, 13);
            this.currLabel.TabIndex = 3;
            this.currLabel.Text = "currLabel";
            // 
            // compLabel
            // 
            this.compLabel.Location = new System.Drawing.Point(240, 8);
            this.compLabel.Name = "compLabel";
            this.compLabel.Size = new System.Drawing.Size(225, 13);
            this.compLabel.TabIndex = 4;
            this.compLabel.Text = "compLabel";
            // 
            // equalButton
            // 
            this.equalButton.Location = new System.Drawing.Point(243, 349);
            this.equalButton.Name = "equalButton";
            this.equalButton.Size = new System.Drawing.Size(225, 23);
            this.equalButton.TabIndex = 5;
            this.equalButton.Text = "About Equal";
            this.equalButton.UseVisualStyleBackColor = true;
            this.equalButton.Click += new System.EventHandler(this.equalButton_Click);
            // 
            // ComparerWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(507, 400);
            this.Controls.Add(this.equalButton);
            this.Controls.Add(this.compLabel);
            this.Controls.Add(this.currLabel);
            this.Controls.Add(this.dontrateButton);
            this.Controls.Add(this.currPicture);
            this.Controls.Add(this.compPicture);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ComparerWindow";
            this.Text = "Compare Rating";
            ((System.ComponentModel.ISupportInitialize)(this.currPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.compPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox currPicture;
        private System.Windows.Forms.Button dontrateButton;
        private System.Windows.Forms.PictureBox compPicture;
        private System.Windows.Forms.Label currLabel;
        private System.Windows.Forms.Label compLabel;
        private System.Windows.Forms.Button equalButton;
    }
}