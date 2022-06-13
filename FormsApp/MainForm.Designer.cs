namespace FormsApp
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.Tabs = new System.Windows.Forms.TabControl();
            this.tabPagePlayers = new System.Windows.Forms.TabPage();
            this.flowPanelAllPlayers = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.flowPanelFavPlayers = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPageRankings = new System.Windows.Forms.TabPage();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.lbVisitors = new System.Windows.Forms.Label();
            this.flowPanelVisitors = new System.Windows.Forms.FlowLayoutPanel();
            this.lbYellowCard = new System.Windows.Forms.Label();
            this.flowPanelYellowCards = new System.Windows.Forms.FlowLayoutPanel();
            this.lbGoals = new System.Windows.Forms.Label();
            this.flowPanelGoals = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeWorldCupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeFavouriteTeamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.favouriteTeamWorker = new System.ComponentModel.BackgroundWorker();
            this.favouritePlayersWorker = new System.ComponentModel.BackgroundWorker();
            this.rankingsWorker = new System.ComponentModel.BackgroundWorker();
            this.printDialog = new System.Windows.Forms.PrintDialog();
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.Tabs.SuspendLayout();
            this.tabPagePlayers.SuspendLayout();
            this.tabPageRankings.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Tabs
            // 
            this.Tabs.Controls.Add(this.tabPagePlayers);
            this.Tabs.Controls.Add(this.tabPageRankings);
            resources.ApplyResources(this.Tabs, "Tabs");
            this.Tabs.Name = "Tabs";
            this.Tabs.SelectedIndex = 0;
            this.Tabs.SelectedIndexChanged += new System.EventHandler(this.Tabs_SelectedIndexChanged);
            // 
            // tabPagePlayers
            // 
            this.tabPagePlayers.Controls.Add(this.flowPanelAllPlayers);
            this.tabPagePlayers.Controls.Add(this.label2);
            this.tabPagePlayers.Controls.Add(this.label1);
            this.tabPagePlayers.Controls.Add(this.flowPanelFavPlayers);
            resources.ApplyResources(this.tabPagePlayers, "tabPagePlayers");
            this.tabPagePlayers.Name = "tabPagePlayers";
            this.tabPagePlayers.UseVisualStyleBackColor = true;
            // 
            // flowPanelAllPlayers
            // 
            this.flowPanelAllPlayers.AllowDrop = true;
            resources.ApplyResources(this.flowPanelAllPlayers, "flowPanelAllPlayers");
            this.flowPanelAllPlayers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowPanelAllPlayers.Name = "flowPanelAllPlayers";
            this.flowPanelAllPlayers.DragDrop += new System.Windows.Forms.DragEventHandler(this.FlowPanel_DragDrop);
            this.flowPanelAllPlayers.DragEnter += new System.Windows.Forms.DragEventHandler(this.FlowPanel_DragEnter);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // flowPanelFavPlayers
            // 
            this.flowPanelFavPlayers.AllowDrop = true;
            this.flowPanelFavPlayers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.flowPanelFavPlayers, "flowPanelFavPlayers");
            this.flowPanelFavPlayers.Name = "flowPanelFavPlayers";
            this.flowPanelFavPlayers.DragDrop += new System.Windows.Forms.DragEventHandler(this.FlowPanel_DragDrop);
            this.flowPanelFavPlayers.DragEnter += new System.Windows.Forms.DragEventHandler(this.FlowPanel_DragEnter);
            // 
            // tabPageRankings
            // 
            this.tabPageRankings.Controls.Add(this.btnPreview);
            this.tabPageRankings.Controls.Add(this.btnPrint);
            this.tabPageRankings.Controls.Add(this.lbVisitors);
            this.tabPageRankings.Controls.Add(this.flowPanelVisitors);
            this.tabPageRankings.Controls.Add(this.lbYellowCard);
            this.tabPageRankings.Controls.Add(this.flowPanelYellowCards);
            this.tabPageRankings.Controls.Add(this.lbGoals);
            this.tabPageRankings.Controls.Add(this.flowPanelGoals);
            resources.ApplyResources(this.tabPageRankings, "tabPageRankings");
            this.tabPageRankings.Name = "tabPageRankings";
            this.tabPageRankings.UseVisualStyleBackColor = true;
            // 
            // btnPreview
            // 
            resources.ApplyResources(this.btnPreview, "btnPreview");
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.BtnPreview_Click);
            // 
            // btnPrint
            // 
            resources.ApplyResources(this.btnPrint, "btnPrint");
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
            // 
            // lbVisitors
            // 
            resources.ApplyResources(this.lbVisitors, "lbVisitors");
            this.lbVisitors.Name = "lbVisitors";
            // 
            // flowPanelVisitors
            // 
            resources.ApplyResources(this.flowPanelVisitors, "flowPanelVisitors");
            this.flowPanelVisitors.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowPanelVisitors.Name = "flowPanelVisitors";
            // 
            // lbYellowCard
            // 
            resources.ApplyResources(this.lbYellowCard, "lbYellowCard");
            this.lbYellowCard.Name = "lbYellowCard";
            // 
            // flowPanelYellowCards
            // 
            resources.ApplyResources(this.flowPanelYellowCards, "flowPanelYellowCards");
            this.flowPanelYellowCards.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowPanelYellowCards.Name = "flowPanelYellowCards";
            // 
            // lbGoals
            // 
            resources.ApplyResources(this.lbGoals, "lbGoals");
            this.lbGoals.Name = "lbGoals";
            // 
            // flowPanelGoals
            // 
            resources.ApplyResources(this.flowPanelGoals, "flowPanelGoals");
            this.flowPanelGoals.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowPanelGoals.Name = "flowPanelGoals";
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeWorldCupToolStripMenuItem,
            this.changeFavouriteTeamToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            resources.ApplyResources(this.settingsToolStripMenuItem, "settingsToolStripMenuItem");
            // 
            // changeWorldCupToolStripMenuItem
            // 
            this.changeWorldCupToolStripMenuItem.Name = "changeWorldCupToolStripMenuItem";
            resources.ApplyResources(this.changeWorldCupToolStripMenuItem, "changeWorldCupToolStripMenuItem");
            this.changeWorldCupToolStripMenuItem.Click += new System.EventHandler(this.ChangeWorldCupToolStripMenuItem_Click);
            // 
            // changeFavouriteTeamToolStripMenuItem
            // 
            this.changeFavouriteTeamToolStripMenuItem.Name = "changeFavouriteTeamToolStripMenuItem";
            resources.ApplyResources(this.changeFavouriteTeamToolStripMenuItem, "changeFavouriteTeamToolStripMenuItem");
            this.changeFavouriteTeamToolStripMenuItem.Click += new System.EventHandler(this.ChangeFavouriteTeamToolStripMenuItem_Click);
            // 
            // favouriteTeamWorker
            // 
            this.favouriteTeamWorker.WorkerSupportsCancellation = true;
            this.favouriteTeamWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.FavouriteTeamWorker_DoWork);
            this.favouriteTeamWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.FavouriteTeamWorker_RunWorkerCompleted);
            // 
            // favouritePlayersWorker
            // 
            this.favouritePlayersWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.FavouritePlayersWorker_DoWork);
            this.favouritePlayersWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.FavouritePlayersWorker_RunWorkerCompleted);
            // 
            // rankingsWorker
            // 
            this.rankingsWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.RankingsWorker_DoWork);
            this.rankingsWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.RankingsWorker_RunWorkerCompleted);
            // 
            // printDialog
            // 
            this.printDialog.Document = this.printDocument;
            this.printDialog.UseEXDialog = true;
            // 
            // printDocument
            // 
            this.printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.PrintDocument_PrintPage);
            // 
            // printPreviewDialog
            // 
            resources.ApplyResources(this.printPreviewDialog, "printPreviewDialog");
            this.printPreviewDialog.Document = this.printDocument;
            this.printPreviewDialog.Name = "printPreviewDialog";
            this.printPreviewDialog.UseAntiAlias = true;
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Tabs);
            this.Controls.Add(this.menuStrip1);
            this.Name = "MainForm";
            this.Tabs.ResumeLayout(false);
            this.tabPagePlayers.ResumeLayout(false);
            this.tabPagePlayers.PerformLayout();
            this.tabPageRankings.ResumeLayout(false);
            this.tabPageRankings.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl Tabs;
        private System.Windows.Forms.TabPage tabPagePlayers;
        private System.Windows.Forms.TabPage tabPageRankings;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowPanelAllPlayers;
        private System.Windows.Forms.FlowLayoutPanel flowPanelFavPlayers;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeWorldCupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeFavouriteTeamToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker favouriteTeamWorker;
        private System.ComponentModel.BackgroundWorker favouritePlayersWorker;
        private System.Windows.Forms.FlowLayoutPanel flowPanelGoals;
        private System.Windows.Forms.Label lbVisitors;
        private System.Windows.Forms.FlowLayoutPanel flowPanelVisitors;
        private System.Windows.Forms.Label lbYellowCard;
        private System.Windows.Forms.FlowLayoutPanel flowPanelYellowCards;
        private System.Windows.Forms.Label lbGoals;
        private System.Windows.Forms.Button btnPrint;
        private System.ComponentModel.BackgroundWorker rankingsWorker;
        private System.Windows.Forms.PrintDialog printDialog;
        private System.Drawing.Printing.PrintDocument printDocument;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog;
        private System.Windows.Forms.Button btnPreview;
    }
}

