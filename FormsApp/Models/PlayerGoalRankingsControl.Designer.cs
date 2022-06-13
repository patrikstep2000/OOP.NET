namespace FormsApp.Models
{
    partial class PlayerGoalRankingsControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerGoalRankingsControl));
            this.lbPlayerName = new System.Windows.Forms.Label();
            this.lbGoalsText = new System.Windows.Forms.Label();
            this.lbNoOfGoals = new System.Windows.Forms.Label();
            this.pbFavourite = new System.Windows.Forms.PictureBox();
            this.pbPlayer = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbFavourite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // lbPlayerName
            // 
            resources.ApplyResources(this.lbPlayerName, "lbPlayerName");
            this.lbPlayerName.Name = "lbPlayerName";
            // 
            // lbGoalsText
            // 
            resources.ApplyResources(this.lbGoalsText, "lbGoalsText");
            this.lbGoalsText.Name = "lbGoalsText";
            // 
            // lbNoOfGoals
            // 
            resources.ApplyResources(this.lbNoOfGoals, "lbNoOfGoals");
            this.lbNoOfGoals.Name = "lbNoOfGoals";
            // 
            // pbFavourite
            // 
            resources.ApplyResources(this.pbFavourite, "pbFavourite");
            this.pbFavourite.Image = global::FormsApp.Images.favourite_star;
            this.pbFavourite.Name = "pbFavourite";
            this.pbFavourite.TabStop = false;
            // 
            // pbPlayer
            // 
            resources.ApplyResources(this.pbPlayer, "pbPlayer");
            this.pbPlayer.Image = global::FormsApp.Images.default_player_img;
            this.pbPlayer.InitialImage = global::FormsApp.Images.default_player_img;
            this.pbPlayer.Name = "pbPlayer";
            this.pbPlayer.TabStop = false;
            // 
            // PlayerGoalRankingsControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pbFavourite);
            this.Controls.Add(this.lbNoOfGoals);
            this.Controls.Add(this.lbGoalsText);
            this.Controls.Add(this.lbPlayerName);
            this.Controls.Add(this.pbPlayer);
            this.Name = "PlayerGoalRankingsControl";
            ((System.ComponentModel.ISupportInitialize)(this.pbFavourite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbPlayer;
        private System.Windows.Forms.Label lbPlayerName;
        private System.Windows.Forms.Label lbGoalsText;
        private System.Windows.Forms.Label lbNoOfGoals;
        private System.Windows.Forms.PictureBox pbFavourite;
    }
}
