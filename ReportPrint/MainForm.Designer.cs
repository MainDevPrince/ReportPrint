namespace ReportPrint
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
            this.printPreviewControlReport = new System.Windows.Forms.PrintPreviewControl();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listViewUsers = new ReportPrint.OwnControls.UserListView();
            this.listViewUserDatas = new ReportPrint.OwnControls.UserDataListView();
            this.panelGame = new System.Windows.Forms.Panel();
            this.cbAllashiage = new System.Windows.Forms.ComboBox();
            this.btnTUGAdd = new System.Windows.Forms.Button();
            this.btnModifyUserData = new System.Windows.Forms.Button();
            this.btnDeleteUserData = new System.Windows.Forms.Button();
            this.textBoxGameScore = new System.Windows.Forms.TextBox();
            this.labelGameName = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbMarkRight = new System.Windows.Forms.Label();
            this.lbMarkNone = new System.Windows.Forms.Label();
            this.labelNotes = new System.Windows.Forms.Label();
            this.tbNotes = new System.Windows.Forms.TextBox();
            this.btnSettingGraph = new System.Windows.Forms.Button();
            this.btnSettingPath = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnSavePDF = new System.Windows.Forms.Button();
            this.buttonMakeReport = new System.Windows.Forms.Button();
            this.panelBody = new System.Windows.Forms.Panel();
            this.lbMarkLeft = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panelGame.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelBody.SuspendLayout();
            this.SuspendLayout();
            // 
            // printPreviewControlReport
            // 
            this.printPreviewControlReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.printPreviewControlReport.AutoZoom = false;
            this.printPreviewControlReport.Location = new System.Drawing.Point(276, 1);
            this.printPreviewControlReport.Name = "printPreviewControlReport";
            this.printPreviewControlReport.Size = new System.Drawing.Size(1522, 500);
            this.printPreviewControlReport.TabIndex = 3;
            this.printPreviewControlReport.UseAntiAlias = true;
            this.printPreviewControlReport.Zoom = 1.75D;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 1);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listViewUsers);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listViewUserDatas);
            this.splitContainer1.Size = new System.Drawing.Size(270, 501);
            this.splitContainer1.SplitterDistance = 234;
            this.splitContainer1.TabIndex = 4;
            // 
            // listViewUsers
            // 
            this.listViewUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewUsers.Font = new System.Drawing.Font("ＭＳ ゴシック", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.listViewUsers.FullRowSelect = true;
            this.listViewUsers.HideSelection = false;
            this.listViewUsers.Location = new System.Drawing.Point(0, 0);
            this.listViewUsers.Name = "listViewUsers";
            this.listViewUsers.Size = new System.Drawing.Size(270, 234);
            this.listViewUsers.TabIndex = 2;
            this.listViewUsers.UseCompatibleStateImageBehavior = false;
            this.listViewUsers.View = System.Windows.Forms.View.Details;
            this.listViewUsers.VirtualMode = true;
            this.listViewUsers.SelectedIndexChanged += new System.EventHandler(this.listViewUsers_SelectedIndexChanged);
            // 
            // listViewUserDatas
            // 
            this.listViewUserDatas.ColorAll_ashiage_left_bk = System.Drawing.Color.Empty;
            this.listViewUserDatas.ColorAll_ashiage_left_fr = System.Drawing.Color.Empty;
            this.listViewUserDatas.ColorAll_ashiage_none_bk = System.Drawing.Color.Empty;
            this.listViewUserDatas.ColorAll_ashiage_none_fr = System.Drawing.Color.Empty;
            this.listViewUserDatas.ColorAll_ashiage_right_bk = System.Drawing.Color.Empty;
            this.listViewUserDatas.ColorAll_ashiage_right_fr = System.Drawing.Color.Empty;
            this.listViewUserDatas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewUserDatas.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F);
            this.listViewUserDatas.FullRowSelect = true;
            this.listViewUserDatas.HideSelection = false;
            this.listViewUserDatas.Location = new System.Drawing.Point(0, 0);
            this.listViewUserDatas.Name = "listViewUserDatas";
            this.listViewUserDatas.OwnerDraw = true;
            this.listViewUserDatas.Size = new System.Drawing.Size(270, 263);
            this.listViewUserDatas.TabIndex = 1;
            this.listViewUserDatas.UseCompatibleStateImageBehavior = false;
            this.listViewUserDatas.View = System.Windows.Forms.View.Details;
            this.listViewUserDatas.VirtualMode = true;
            this.listViewUserDatas.SelectedIndexChanged += new System.EventHandler(this.listViewUserDatas_SelectedIndexChanged);
            // 
            // panelGame
            // 
            this.panelGame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelGame.Controls.Add(this.cbAllashiage);
            this.panelGame.Controls.Add(this.btnTUGAdd);
            this.panelGame.Controls.Add(this.btnModifyUserData);
            this.panelGame.Controls.Add(this.btnDeleteUserData);
            this.panelGame.Controls.Add(this.textBoxGameScore);
            this.panelGame.Controls.Add(this.labelGameName);
            this.panelGame.Location = new System.Drawing.Point(8, 518);
            this.panelGame.Name = "panelGame";
            this.panelGame.Size = new System.Drawing.Size(279, 78);
            this.panelGame.TabIndex = 0;
            // 
            // cbAllashiage
            // 
            this.cbAllashiage.BackColor = System.Drawing.SystemColors.Window;
            this.cbAllashiage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAllashiage.Font = new System.Drawing.Font("ＭＳ ゴシック", 13.25F);
            this.cbAllashiage.FormattingEnabled = true;
            this.cbAllashiage.ItemHeight = 18;
            this.cbAllashiage.Items.AddRange(new object[] {
            "なし",
            "左",
            "右"});
            this.cbAllashiage.Location = new System.Drawing.Point(97, 9);
            this.cbAllashiage.Name = "cbAllashiage";
            this.cbAllashiage.Size = new System.Drawing.Size(63, 26);
            this.cbAllashiage.TabIndex = 4;
            this.cbAllashiage.Visible = false;
            // 
            // btnTUGAdd
            // 
            this.btnTUGAdd.Enabled = false;
            this.btnTUGAdd.Font = new System.Drawing.Font("ＭＳ ゴシック", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnTUGAdd.Location = new System.Drawing.Point(92, 42);
            this.btnTUGAdd.Name = "btnTUGAdd";
            this.btnTUGAdd.Size = new System.Drawing.Size(93, 32);
            this.btnTUGAdd.TabIndex = 2;
            this.btnTUGAdd.Text = "TUG追加";
            this.btnTUGAdd.UseVisualStyleBackColor = true;
            this.btnTUGAdd.Click += new System.EventHandler(this.btnTUGAdd_Click);
            // 
            // btnModifyUserData
            // 
            this.btnModifyUserData.Enabled = false;
            this.btnModifyUserData.Font = new System.Drawing.Font("ＭＳ ゴシック", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnModifyUserData.Location = new System.Drawing.Point(192, 42);
            this.btnModifyUserData.Name = "btnModifyUserData";
            this.btnModifyUserData.Size = new System.Drawing.Size(78, 32);
            this.btnModifyUserData.TabIndex = 3;
            this.btnModifyUserData.Text = "保存";
            this.btnModifyUserData.UseVisualStyleBackColor = true;
            this.btnModifyUserData.Click += new System.EventHandler(this.btnModifyUserData_Click);
            // 
            // btnDeleteUserData
            // 
            this.btnDeleteUserData.Enabled = false;
            this.btnDeleteUserData.Font = new System.Drawing.Font("ＭＳ ゴシック", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnDeleteUserData.Location = new System.Drawing.Point(8, 42);
            this.btnDeleteUserData.Name = "btnDeleteUserData";
            this.btnDeleteUserData.Size = new System.Drawing.Size(78, 32);
            this.btnDeleteUserData.TabIndex = 1;
            this.btnDeleteUserData.Text = "消去";
            this.btnDeleteUserData.UseVisualStyleBackColor = true;
            this.btnDeleteUserData.Click += new System.EventHandler(this.btnDeleteUserData_Click);
            // 
            // textBoxGameScore
            // 
            this.textBoxGameScore.Enabled = false;
            this.textBoxGameScore.Font = new System.Drawing.Font("ＭＳ ゴシック", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxGameScore.Location = new System.Drawing.Point(159, 9);
            this.textBoxGameScore.Name = "textBoxGameScore";
            this.textBoxGameScore.Size = new System.Drawing.Size(111, 26);
            this.textBoxGameScore.TabIndex = 0;
            this.textBoxGameScore.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelGameName
            // 
            this.labelGameName.AutoSize = true;
            this.labelGameName.Enabled = false;
            this.labelGameName.Font = new System.Drawing.Font("ＭＳ ゴシック", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelGameName.Location = new System.Drawing.Point(13, 12);
            this.labelGameName.Name = "labelGameName";
            this.labelGameName.Size = new System.Drawing.Size(0, 19);
            this.labelGameName.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.lbMarkLeft);
            this.panel2.Controls.Add(this.lbMarkRight);
            this.panel2.Controls.Add(this.lbMarkNone);
            this.panel2.Controls.Add(this.labelNotes);
            this.panel2.Controls.Add(this.tbNotes);
            this.panel2.Controls.Add(this.btnSettingGraph);
            this.panel2.Controls.Add(this.btnSettingPath);
            this.panel2.Controls.Add(this.btnPrint);
            this.panel2.Controls.Add(this.btnSavePDF);
            this.panel2.Controls.Add(this.buttonMakeReport);
            this.panel2.Location = new System.Drawing.Point(294, 518);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1514, 78);
            this.panel2.TabIndex = 1;
            // 
            // lbMarkRight
            // 
            this.lbMarkRight.AutoSize = true;
            this.lbMarkRight.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.lbMarkRight.Font = new System.Drawing.Font("ＭＳ ゴシック", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbMarkRight.ForeColor = System.Drawing.Color.Red;
            this.lbMarkRight.Location = new System.Drawing.Point(441, 11);
            this.lbMarkRight.Name = "lbMarkRight";
            this.lbMarkRight.Size = new System.Drawing.Size(149, 19);
            this.lbMarkRight.TabIndex = 11;
            this.lbMarkRight.Text = "片足立ち（右）";
            // 
            // lbMarkNone
            // 
            this.lbMarkNone.AutoSize = true;
            this.lbMarkNone.BackColor = System.Drawing.Color.Orange;
            this.lbMarkNone.Font = new System.Drawing.Font("ＭＳ ゴシック", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbMarkNone.Location = new System.Drawing.Point(266, 11);
            this.lbMarkNone.Name = "lbMarkNone";
            this.lbMarkNone.Size = new System.Drawing.Size(169, 19);
            this.lbMarkNone.TabIndex = 10;
            this.lbMarkNone.Text = "片足立ち（なし）";
            // 
            // labelNotes
            // 
            this.labelNotes.AutoSize = true;
            this.labelNotes.Font = new System.Drawing.Font("ＭＳ ゴシック", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelNotes.Location = new System.Drawing.Point(214, 48);
            this.labelNotes.Name = "labelNotes";
            this.labelNotes.Size = new System.Drawing.Size(49, 19);
            this.labelNotes.TabIndex = 9;
            this.labelNotes.Text = "備考";
            // 
            // tbNotes
            // 
            this.tbNotes.Font = new System.Drawing.Font("ＭＳ ゴシック", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tbNotes.Location = new System.Drawing.Point(270, 45);
            this.tbNotes.Name = "tbNotes";
            this.tbNotes.Size = new System.Drawing.Size(430, 26);
            this.tbNotes.TabIndex = 2;
            // 
            // btnSettingGraph
            // 
            this.btnSettingGraph.Font = new System.Drawing.Font("ＭＳ ゴシック", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSettingGraph.Location = new System.Drawing.Point(3, 42);
            this.btnSettingGraph.Name = "btnSettingGraph";
            this.btnSettingGraph.Size = new System.Drawing.Size(182, 32);
            this.btnSettingGraph.TabIndex = 1;
            this.btnSettingGraph.Text = "グラフ設定";
            this.btnSettingGraph.UseVisualStyleBackColor = true;
            this.btnSettingGraph.Click += new System.EventHandler(this.btnSettingGraph_Click);
            // 
            // btnSettingPath
            // 
            this.btnSettingPath.Font = new System.Drawing.Font("ＭＳ ゴシック", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSettingPath.Location = new System.Drawing.Point(3, 5);
            this.btnSettingPath.Name = "btnSettingPath";
            this.btnSettingPath.Size = new System.Drawing.Size(182, 32);
            this.btnSettingPath.TabIndex = 0;
            this.btnSettingPath.Text = "データソース設定";
            this.btnSettingPath.UseVisualStyleBackColor = true;
            this.btnSettingPath.Click += new System.EventHandler(this.btnSettingPath_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Font = new System.Drawing.Font("ＭＳ ゴシック", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnPrint.Location = new System.Drawing.Point(1421, 42);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(84, 32);
            this.btnPrint.TabIndex = 5;
            this.btnPrint.Text = "印刷";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnSavePDF
            // 
            this.btnSavePDF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSavePDF.Font = new System.Drawing.Font("ＭＳ ゴシック", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSavePDF.Location = new System.Drawing.Point(1322, 42);
            this.btnSavePDF.Name = "btnSavePDF";
            this.btnSavePDF.Size = new System.Drawing.Size(84, 32);
            this.btnSavePDF.TabIndex = 4;
            this.btnSavePDF.Text = "保存";
            this.btnSavePDF.UseVisualStyleBackColor = true;
            this.btnSavePDF.Click += new System.EventHandler(this.btnSavePDF_Click);
            // 
            // buttonMakeReport
            // 
            this.buttonMakeReport.Enabled = false;
            this.buttonMakeReport.Font = new System.Drawing.Font("ＭＳ ゴシック", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonMakeReport.Location = new System.Drawing.Point(726, 42);
            this.buttonMakeReport.Name = "buttonMakeReport";
            this.buttonMakeReport.Size = new System.Drawing.Size(172, 32);
            this.buttonMakeReport.TabIndex = 3;
            this.buttonMakeReport.Text = "レポート作成";
            this.buttonMakeReport.UseVisualStyleBackColor = true;
            this.buttonMakeReport.Click += new System.EventHandler(this.buttonMakeReport_Click);
            // 
            // panelBody
            // 
            this.panelBody.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBody.Controls.Add(this.splitContainer1);
            this.panelBody.Controls.Add(this.printPreviewControlReport);
            this.panelBody.Location = new System.Drawing.Point(8, 8);
            this.panelBody.Name = "panelBody";
            this.panelBody.Size = new System.Drawing.Size(1800, 504);
            this.panelBody.TabIndex = 7;
            // 
            // lbMarkLeft
            // 
            this.lbMarkLeft.AutoSize = true;
            this.lbMarkLeft.BackColor = System.Drawing.Color.Silver;
            this.lbMarkLeft.Font = new System.Drawing.Font("ＭＳ ゴシック", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbMarkLeft.ForeColor = System.Drawing.Color.White;
            this.lbMarkLeft.Location = new System.Drawing.Point(596, 11);
            this.lbMarkLeft.Name = "lbMarkLeft";
            this.lbMarkLeft.Size = new System.Drawing.Size(149, 19);
            this.lbMarkLeft.TabIndex = 12;
            this.lbMarkLeft.Text = "片足立ち（左）";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1815, 601);
            this.Controls.Add(this.panelBody);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelGame);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(79, 380);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report Print";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panelGame.ResumeLayout(false);
            this.panelGame.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panelBody.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private ReportPrint.OwnControls.UserDataListView listViewUserDatas;
        private ReportPrint.OwnControls.UserListView listViewUsers;
        private System.Windows.Forms.PrintPreviewControl printPreviewControlReport;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panelGame;
        private System.Windows.Forms.Button btnModifyUserData;
        private System.Windows.Forms.Button btnDeleteUserData;
        private System.Windows.Forms.TextBox textBoxGameScore;
        private System.Windows.Forms.Label labelGameName;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnSavePDF;
        private System.Windows.Forms.Button buttonMakeReport;
        private System.Windows.Forms.Panel panelBody;
        private System.Windows.Forms.Button btnTUGAdd;
        private System.Windows.Forms.Button btnSettingPath;
        private System.Windows.Forms.Button btnSettingGraph;
        private System.Windows.Forms.Label labelNotes;
        private System.Windows.Forms.TextBox tbNotes;
        private System.Windows.Forms.ComboBox cbAllashiage;
        private System.Windows.Forms.Label lbMarkNone;
        private System.Windows.Forms.Label lbMarkRight;
        private System.Windows.Forms.Label lbMarkLeft;
    }
}

