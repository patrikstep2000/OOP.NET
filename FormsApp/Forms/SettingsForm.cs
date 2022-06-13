using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsApp.Forms
{
    public partial class SettingsForm : Form
    {
        public string WorldCup { get; set; }
        public string Language { get; set; }

        private bool Closable;

        private ConfirmForm confirm = new ConfirmForm();

        public SettingsForm(bool isInitial)
        {
            InitializeComponent();
            if (isInitial)
            {
                btnCancel.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (confirm.ShowDialog() == DialogResult.Yes)
            {
                DialogResult = DialogResult.OK;

                WorldCup = rbtnMen.Checked ? "men" : "women";
                Language = rbtnCroatian.Checked ? "croatian" : "english";

                Closable = true;
                Close(); 
            }
            else
            {
                Closable = false;
            }  
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (Closable)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
