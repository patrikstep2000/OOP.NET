namespace FormsApp.Models
{
    partial class MatchRankingsControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MatchRankingsControl));
            this.lbLocation = new System.Windows.Forms.Label();
            this.lbAttendanceText = new System.Windows.Forms.Label();
            this.lbHomeTeamText = new System.Windows.Forms.Label();
            this.lbAwayTeamText = new System.Windows.Forms.Label();
            this.lbAttendance = new System.Windows.Forms.Label();
            this.lbHomeTeam = new System.Windows.Forms.Label();
            this.lbAwayTeam = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbLocation
            // 
            resources.ApplyResources(this.lbLocation, "lbLocation");
            this.lbLocation.Name = "lbLocation";
            // 
            // lbAttendanceText
            // 
            resources.ApplyResources(this.lbAttendanceText, "lbAttendanceText");
            this.lbAttendanceText.Name = "lbAttendanceText";
            // 
            // lbHomeTeamText
            // 
            resources.ApplyResources(this.lbHomeTeamText, "lbHomeTeamText");
            this.lbHomeTeamText.Name = "lbHomeTeamText";
            // 
            // lbAwayTeamText
            // 
            resources.ApplyResources(this.lbAwayTeamText, "lbAwayTeamText");
            this.lbAwayTeamText.Name = "lbAwayTeamText";
            // 
            // lbAttendance
            // 
            resources.ApplyResources(this.lbAttendance, "lbAttendance");
            this.lbAttendance.Name = "lbAttendance";
            // 
            // lbHomeTeam
            // 
            resources.ApplyResources(this.lbHomeTeam, "lbHomeTeam");
            this.lbHomeTeam.Name = "lbHomeTeam";
            // 
            // lbAwayTeam
            // 
            resources.ApplyResources(this.lbAwayTeam, "lbAwayTeam");
            this.lbAwayTeam.Name = "lbAwayTeam";
            // 
            // MatchRankingsControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lbAwayTeam);
            this.Controls.Add(this.lbHomeTeam);
            this.Controls.Add(this.lbAttendance);
            this.Controls.Add(this.lbAwayTeamText);
            this.Controls.Add(this.lbHomeTeamText);
            this.Controls.Add(this.lbAttendanceText);
            this.Controls.Add(this.lbLocation);
            this.Name = "MatchRankingsControl";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbLocation;
        private System.Windows.Forms.Label lbAttendanceText;
        private System.Windows.Forms.Label lbHomeTeamText;
        private System.Windows.Forms.Label lbAwayTeamText;
        private System.Windows.Forms.Label lbAttendance;
        private System.Windows.Forms.Label lbHomeTeam;
        private System.Windows.Forms.Label lbAwayTeam;
    }
}
