namespace FormsApp.Forms
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.gboxWC = new System.Windows.Forms.GroupBox();
            this.rbtnWomen = new System.Windows.Forms.RadioButton();
            this.rbtnMen = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.gboxLanguage = new System.Windows.Forms.GroupBox();
            this.rbtnEnglish = new System.Windows.Forms.RadioButton();
            this.rbtnCroatian = new System.Windows.Forms.RadioButton();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gboxWC.SuspendLayout();
            this.gboxLanguage.SuspendLayout();
            this.SuspendLayout();
            // 
            // gboxWC
            // 
            resources.ApplyResources(this.gboxWC, "gboxWC");
            this.gboxWC.Controls.Add(this.rbtnWomen);
            this.gboxWC.Controls.Add(this.rbtnMen);
            this.gboxWC.Name = "gboxWC";
            this.gboxWC.TabStop = false;
            // 
            // rbtnWomen
            // 
            resources.ApplyResources(this.rbtnWomen, "rbtnWomen");
            this.rbtnWomen.Name = "rbtnWomen";
            this.rbtnWomen.UseVisualStyleBackColor = true;
            // 
            // rbtnMen
            // 
            resources.ApplyResources(this.rbtnMen, "rbtnMen");
            this.rbtnMen.Checked = true;
            this.rbtnMen.Name = "rbtnMen";
            this.rbtnMen.TabStop = true;
            this.rbtnMen.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // gboxLanguage
            // 
            resources.ApplyResources(this.gboxLanguage, "gboxLanguage");
            this.gboxLanguage.Controls.Add(this.rbtnEnglish);
            this.gboxLanguage.Controls.Add(this.rbtnCroatian);
            this.gboxLanguage.Name = "gboxLanguage";
            this.gboxLanguage.TabStop = false;
            // 
            // rbtnEnglish
            // 
            resources.ApplyResources(this.rbtnEnglish, "rbtnEnglish");
            this.rbtnEnglish.Name = "rbtnEnglish";
            this.rbtnEnglish.UseVisualStyleBackColor = true;
            // 
            // rbtnCroatian
            // 
            resources.ApplyResources(this.rbtnCroatian, "rbtnCroatian");
            this.rbtnCroatian.Checked = true;
            this.rbtnCroatian.Name = "rbtnCroatian";
            this.rbtnCroatian.TabStop = true;
            this.rbtnCroatian.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Name = "btnSave";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.btnSave;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gboxLanguage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gboxWC);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SettingsForm";
            this.ShowIcon = false;
            this.gboxWC.ResumeLayout(false);
            this.gboxWC.PerformLayout();
            this.gboxLanguage.ResumeLayout(false);
            this.gboxLanguage.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gboxWC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gboxLanguage;
        private System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.RadioButton rbtnMen;
        public System.Windows.Forms.RadioButton rbtnWomen;
        public System.Windows.Forms.RadioButton rbtnEnglish;
        public System.Windows.Forms.RadioButton rbtnCroatian;
        private System.Windows.Forms.Button btnCancel;
    }
}