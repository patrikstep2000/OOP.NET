namespace FormsApp.Models
{
    partial class PlayerControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerControl));
            this.fileDialog = new System.Windows.Forms.OpenFileDialog();
            this.playerPanel = new System.Windows.Forms.Panel();
            this.lbPositionText = new System.Windows.Forms.Label();
            this.lbPosition = new System.Windows.Forms.Label();
            this.lbCaptainText = new System.Windows.Forms.Label();
            this.lbCaptain = new System.Windows.Forms.Label();
            this.lbNumberText = new System.Windows.Forms.Label();
            this.lbNumber = new System.Windows.Forms.Label();
            this.lbPlayerNameText = new System.Windows.Forms.Label();
            this.lbPlayerName = new System.Windows.Forms.Label();
            this.pbFavourite = new System.Windows.Forms.PictureBox();
            this.pbPlayer = new System.Windows.Forms.PictureBox();
            this.playerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFavourite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // fileDialog
            // 
            this.fileDialog.FileName = "openFileDialog1";
            resources.ApplyResources(this.fileDialog, "fileDialog");
            // 
            // playerPanel
            // 
            resources.ApplyResources(this.playerPanel, "playerPanel");
            this.playerPanel.Controls.Add(this.pbFavourite);
            this.playerPanel.Controls.Add(this.lbPositionText);
            this.playerPanel.Controls.Add(this.lbPosition);
            this.playerPanel.Controls.Add(this.lbCaptainText);
            this.playerPanel.Controls.Add(this.lbCaptain);
            this.playerPanel.Controls.Add(this.lbNumberText);
            this.playerPanel.Controls.Add(this.lbNumber);
            this.playerPanel.Controls.Add(this.lbPlayerNameText);
            this.playerPanel.Controls.Add(this.lbPlayerName);
            this.playerPanel.Controls.Add(this.pbPlayer);
            this.playerPanel.Name = "playerPanel";
            // 
            // lbPositionText
            // 
            resources.ApplyResources(this.lbPositionText, "lbPositionText");
            this.lbPositionText.Name = "lbPositionText";
            // 
            // lbPosition
            // 
            resources.ApplyResources(this.lbPosition, "lbPosition");
            this.lbPosition.Name = "lbPosition";
            // 
            // lbCaptainText
            // 
            resources.ApplyResources(this.lbCaptainText, "lbCaptainText");
            this.lbCaptainText.Name = "lbCaptainText";
            // 
            // lbCaptain
            // 
            resources.ApplyResources(this.lbCaptain, "lbCaptain");
            this.lbCaptain.Name = "lbCaptain";
            // 
            // lbNumberText
            // 
            resources.ApplyResources(this.lbNumberText, "lbNumberText");
            this.lbNumberText.Name = "lbNumberText";
            // 
            // lbNumber
            // 
            resources.ApplyResources(this.lbNumber, "lbNumber");
            this.lbNumber.Name = "lbNumber";
            // 
            // lbPlayerNameText
            // 
            resources.ApplyResources(this.lbPlayerNameText, "lbPlayerNameText");
            this.lbPlayerNameText.Name = "lbPlayerNameText";
            // 
            // lbPlayerName
            // 
            resources.ApplyResources(this.lbPlayerName, "lbPlayerName");
            this.lbPlayerName.Name = "lbPlayerName";
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
            this.pbPlayer.Name = "pbPlayer";
            this.pbPlayer.TabStop = false;
            // 
            // PlayerControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.playerPanel);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "PlayerControl";
            this.playerPanel.ResumeLayout(false);
            this.playerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFavourite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog fileDialog;
        private System.Windows.Forms.PictureBox pbFavourite;
        private System.Windows.Forms.Label lbPositionText;
        private System.Windows.Forms.Label lbPosition;
        private System.Windows.Forms.Label lbCaptainText;
        private System.Windows.Forms.Label lbCaptain;
        private System.Windows.Forms.Label lbNumberText;
        private System.Windows.Forms.Label lbNumber;
        private System.Windows.Forms.Label lbPlayerNameText;
        private System.Windows.Forms.Label lbPlayerName;
        public System.Windows.Forms.Panel playerPanel;
        public System.Windows.Forms.PictureBox pbPlayer;
    }
}
