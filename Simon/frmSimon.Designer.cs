namespace Simon
{
    partial class frmSimon
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
            this.tmrSimon = new System.Windows.Forms.Timer(this.components);
            this.pnlGame = new System.Windows.Forms.Panel();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblScore = new System.Windows.Forms.Label();
            this.btnYellow = new System.Windows.Forms.Button();
            this.btnBlue = new System.Windows.Forms.Button();
            this.btnRed = new System.Windows.Forms.Button();
            this.btnGreen = new System.Windows.Forms.Button();
            this.tmrEndGame = new System.Windows.Forms.Timer(this.components);
            this.btnScores = new System.Windows.Forms.Button();
            this.pnlGame.SuspendLayout();
            this.SuspendLayout();
            // 
            // tmrSimon
            // 
            this.tmrSimon.Interval = 550;
            this.tmrSimon.Tick += new System.EventHandler(this.tmrSimon_Tick);
            // 
            // pnlGame
            // 
            this.pnlGame.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlGame.Controls.Add(this.btnScores);
            this.pnlGame.Controls.Add(this.btnStart);
            this.pnlGame.Controls.Add(this.lblScore);
            this.pnlGame.Controls.Add(this.btnYellow);
            this.pnlGame.Controls.Add(this.btnBlue);
            this.pnlGame.Controls.Add(this.btnRed);
            this.pnlGame.Controls.Add(this.btnGreen);
            this.pnlGame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGame.Location = new System.Drawing.Point(0, 0);
            this.pnlGame.Name = "pnlGame";
            this.pnlGame.Size = new System.Drawing.Size(583, 571);
            this.pnlGame.TabIndex = 7;
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(420, 514);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(105, 35);
            this.btnStart.TabIndex = 8;
            this.btnStart.Text = "&Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.ForeColor = System.Drawing.Color.White;
            this.lblScore.Location = new System.Drawing.Point(57, 517);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(65, 24);
            this.lblScore.TabIndex = 11;
            this.lblScore.Text = "Score:";
            this.lblScore.Click += new System.EventHandler(this.lblScore_Click);
            // 
            // btnYellow
            // 
            this.btnYellow.BackColor = System.Drawing.Color.Gold;
            this.btnYellow.Enabled = false;
            this.btnYellow.Location = new System.Drawing.Point(60, 270);
            this.btnYellow.Name = "btnYellow";
            this.btnYellow.Size = new System.Drawing.Size(225, 225);
            this.btnYellow.TabIndex = 10;
            this.btnYellow.UseVisualStyleBackColor = false;
            this.btnYellow.Click += new System.EventHandler(this.btnYellow_Click);
            // 
            // btnBlue
            // 
            this.btnBlue.BackColor = System.Drawing.Color.Blue;
            this.btnBlue.Enabled = false;
            this.btnBlue.Location = new System.Drawing.Point(300, 270);
            this.btnBlue.Name = "btnBlue";
            this.btnBlue.Size = new System.Drawing.Size(225, 225);
            this.btnBlue.TabIndex = 9;
            this.btnBlue.UseVisualStyleBackColor = false;
            this.btnBlue.Click += new System.EventHandler(this.btnBlue_Click);
            // 
            // btnRed
            // 
            this.btnRed.BackColor = System.Drawing.Color.Maroon;
            this.btnRed.Enabled = false;
            this.btnRed.Location = new System.Drawing.Point(300, 30);
            this.btnRed.Name = "btnRed";
            this.btnRed.Size = new System.Drawing.Size(225, 225);
            this.btnRed.TabIndex = 8;
            this.btnRed.UseVisualStyleBackColor = false;
            this.btnRed.Click += new System.EventHandler(this.btnRed_Click);
            // 
            // btnGreen
            // 
            this.btnGreen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(0)))));
            this.btnGreen.Enabled = false;
            this.btnGreen.Location = new System.Drawing.Point(60, 30);
            this.btnGreen.Name = "btnGreen";
            this.btnGreen.Size = new System.Drawing.Size(225, 225);
            this.btnGreen.TabIndex = 7;
            this.btnGreen.UseVisualStyleBackColor = false;
            this.btnGreen.Click += new System.EventHandler(this.btnGreen_Click);
            // 
            // tmrEndGame
            // 
            this.tmrEndGame.Interval = 1500;
            this.tmrEndGame.Tick += new System.EventHandler(this.tmrEndGame_Tick);
            // 
            // btnScores
            // 
            this.btnScores.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScores.Location = new System.Drawing.Point(300, 514);
            this.btnScores.Name = "btnScores";
            this.btnScores.Size = new System.Drawing.Size(105, 35);
            this.btnScores.TabIndex = 12;
            this.btnScores.Text = "&High Scores";
            this.btnScores.UseVisualStyleBackColor = true;
            this.btnScores.Click += new System.EventHandler(this.btnScores_Click);
            // 
            // frmSimon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(583, 571);
            this.Controls.Add(this.pnlGame);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmSimon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TransparencyKey = System.Drawing.SystemColors.ActiveBorder;
            this.Load += new System.EventHandler(this.frmSimon_Load);
            this.pnlGame.ResumeLayout(false);
            this.pnlGame.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlGame;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Button btnYellow;
        private System.Windows.Forms.Button btnBlue;
        private System.Windows.Forms.Button btnRed;
        private System.Windows.Forms.Button btnGreen;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Timer tmrEndGame;
        private System.Windows.Forms.Timer tmrSimon;
        private System.Windows.Forms.Button btnScores;
    }
}

