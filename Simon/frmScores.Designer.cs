namespace Simon
{
    partial class frmScores
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
            this.components = new System.ComponentModel.Container();
            this.lblHighScores = new System.Windows.Forms.Label();
            this.txtHighScores = new System.Windows.Forms.TextBox();
            this.tmrScroller = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lblHighScores
            // 
            this.lblHighScores.AutoSize = true;
            this.lblHighScores.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHighScores.ForeColor = System.Drawing.Color.White;
            this.lblHighScores.Location = new System.Drawing.Point(253, 9);
            this.lblHighScores.Name = "lblHighScores";
            this.lblHighScores.Size = new System.Drawing.Size(145, 29);
            this.lblHighScores.TabIndex = 0;
            this.lblHighScores.Text = "High Scores";
            // 
            // txtHighScores
            // 
            this.txtHighScores.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtHighScores.ForeColor = System.Drawing.Color.White;
            this.txtHighScores.Location = new System.Drawing.Point(12, 53);
            this.txtHighScores.Multiline = true;
            this.txtHighScores.Name = "txtHighScores";
            this.txtHighScores.Size = new System.Drawing.Size(631, 480);
            this.txtHighScores.TabIndex = 1;
            this.txtHighScores.Text = "Bye !";
            // 
            // tmrScroller
            // 
            this.tmrScroller.Enabled = true;
            this.tmrScroller.Tick += new System.EventHandler(this.tmrScroller_Tick);
            // 
            // frmScores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(655, 545);
            this.Controls.Add(this.txtHighScores);
            this.Controls.Add(this.lblHighScores);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmScores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "High Scores";
            this.Load += new System.EventHandler(this.frmScores_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHighScores;
        public System.Windows.Forms.TextBox txtHighScores;
        private System.Windows.Forms.Timer tmrScroller;
    }
}