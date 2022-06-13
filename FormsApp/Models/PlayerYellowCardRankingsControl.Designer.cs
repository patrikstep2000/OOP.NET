namespace FormsApp.Models
{
    partial class PlayerYellowCardRankingsControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbNoOfYellowCards = new System.Windows.Forms.Label();
            this.lbYellowCardText = new System.Windows.Forms.Label();
            this.lbPlayerName = new System.Windows.Forms.Label();
            this.pbPlayer = new System.Windows.Forms.PictureBox();
            this.pbFavourite = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFavourite)).BeginInit();
            this.SuspendLayout();
            // 
            // lbNoOfYellowCards
            // 
            this.lbNoOfYellowCards.AutoSize = true;
            this.lbNoOfYellowCards.Location = new System.Drawing.Point(180, 54);
            this.lbNoOfYellowCards.Name = "lbNoOfYellowCards";
            this.lbNoOfYellowCards.Size = new System.Drawing.Size(24, 13);
            this.lbNoOfYellowCards.TabIndex = 7;
            this.lbNoOfYellowCards.Text = "No.";
            // 
            // lbYellowCardText
            // 
            this.lbYellowCardText.AutoSize = true;
            this.lbYellowCardText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbYellowCardText.Location = new System.Drawing.Point(87, 51);
            this.lbYellowCardText.Name = "lbYellowCardText";
            this.lbYellowCardText.Size = new System.Drawing.Size(87, 16);
            this.lbYellowCardText.TabIndex = 6;
            this.lbYellowCardText.Text = "Žuti kartoni:";
            // 
            // lbPlayerName
            // 
            this.lbPlayerName.AutoSize = true;
            this.lbPlayerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPlayerName.Location = new System.Drawing.Point(87, 23);
            this.lbPlayerName.Name = "lbPlayerName";
            this.lbPlayerName.Size = new System.Drawing.Size(94, 16);
            this.lbPlayerName.TabIndex = 5;
            this.lbPlayerName.Text = "Player name";
            // 
            // pbPlayer
            // 
            this.pbPlayer.Image = global::FormsApp.Images.default_player_img;
            this.pbPlayer.InitialImage = global::FormsApp.Images.default_player_img;
            this.pbPlayer.Location = new System.Drawing.Point(13, 14);
            this.pbPlayer.Name = "pbPlayer";
            this.pbPlayer.Size = new System.Drawing.Size(68, 63);
            this.pbPlayer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPlayer.TabIndex = 4;
            this.pbPlayer.TabStop = false;
            // 
            // pbFavourite
            // 
            this.pbFavourite.Image = global::FormsApp.Images.favourite_star;
            this.pbFavourite.Location = new System.Drawing.Point(291, 37);
            this.pbFavourite.Name = "pbFavourite";
            this.pbFavourite.Size = new System.Drawing.Size(40, 40);
            this.pbFavourite.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbFavourite.TabIndex = 8;
            this.pbFavourite.TabStop = false;
            this.pbFavourite.Visible = false;
            // 
            // PlayerYellowCardRankingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pbFavourite);
            this.Controls.Add(this.lbNoOfYellowCards);
            this.Controls.Add(this.lbYellowCardText);
            this.Controls.Add(this.lbPlayerName);
            this.Controls.Add(this.pbPlayer);
            this.Name = "PlayerYellowCardRankingsControl";
            this.Size = new System.Drawing.Size(344, 89);
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFavourite)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbNoOfYellowCards;
        private System.Windows.Forms.Label lbYellowCardText;
        private System.Windows.Forms.Label lbPlayerName;
        private System.Windows.Forms.PictureBox pbPlayer;
        private System.Windows.Forms.PictureBox pbFavourite;
    }
}
