namespace Casino_Royale
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.BlackJack = new System.Windows.Forms.Button();
            this.Roulette = new System.Windows.Forms.Button();
            this.Bingo = new System.Windows.Forms.Button();
            this.poker = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // BlackJack
            // 
            this.BlackJack.BackColor = System.Drawing.Color.Transparent;
            this.BlackJack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BlackJack.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BlackJack.ForeColor = System.Drawing.Color.Transparent;
            this.BlackJack.Image = ((System.Drawing.Image)(resources.GetObject("BlackJack.Image")));
            this.BlackJack.Location = new System.Drawing.Point(247, 84);
            this.BlackJack.Name = "BlackJack";
            this.BlackJack.Size = new System.Drawing.Size(246, 232);
            this.BlackJack.TabIndex = 11;
            this.BlackJack.UseVisualStyleBackColor = true;
            this.BlackJack.Click += new System.EventHandler(this.button1_Click);
            // 
            // Roulette
            // 
            this.Roulette.BackColor = System.Drawing.Color.Transparent;
            this.Roulette.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Roulette.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Roulette.Image = ((System.Drawing.Image)(resources.GetObject("Roulette.Image")));
            this.Roulette.Location = new System.Drawing.Point(158, 595);
            this.Roulette.Name = "Roulette";
            this.Roulette.Size = new System.Drawing.Size(456, 325);
            this.Roulette.TabIndex = 12;
            this.Roulette.UseVisualStyleBackColor = false;
            this.Roulette.Click += new System.EventHandler(this.button2_Click);
            // 
            // Bingo
            // 
            this.Bingo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Bingo.BackColor = System.Drawing.Color.Transparent;
            this.Bingo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Bingo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Bingo.Image = ((System.Drawing.Image)(resources.GetObject("Bingo.Image")));
            this.Bingo.Location = new System.Drawing.Point(877, 527);
            this.Bingo.Name = "Bingo";
            this.Bingo.Size = new System.Drawing.Size(402, 322);
            this.Bingo.TabIndex = 13;
            this.Bingo.UseVisualStyleBackColor = false;
            this.Bingo.Click += new System.EventHandler(this.button3_Click);
            // 
            // poker
            // 
            this.poker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.poker.BackColor = System.Drawing.Color.Transparent;
            this.poker.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.poker.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.poker.Image = ((System.Drawing.Image)(resources.GetObject("poker.Image")));
            this.poker.Location = new System.Drawing.Point(911, 12);
            this.poker.Name = "poker";
            this.poker.Size = new System.Drawing.Size(383, 376);
            this.poker.TabIndex = 14;
            this.poker.UseVisualStyleBackColor = false;
            this.poker.Click += new System.EventHandler(this.button4_Click);
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(911, 723);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(182, 63);
            this.listView1.TabIndex = 15;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Tile;
            // 
            // Form3
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1444, 881);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.poker);
            this.Controls.Add(this.Bingo);
            this.Controls.Add(this.Roulette);
            this.Controls.Add(this.BlackJack);
            this.ForeColor = System.Drawing.Color.Transparent;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form3";
            this.Text = "Form3";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button BlackJack;
        private System.Windows.Forms.Button Roulette;
        private System.Windows.Forms.Button Bingo;
        private System.Windows.Forms.Button poker;
        private System.Windows.Forms.ListView listView1;
    }
}