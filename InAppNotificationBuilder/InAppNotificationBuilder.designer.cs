
using System.Drawing;

namespace Fic.XTB.InAppNotificationBuilder
{
    partial class InAppNotificationBuilder
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InAppNotificationBuilder));
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.tssSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tscbApp = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.tsbEnabled = new System.Windows.Forms.ToolStripLabel();
            this.tsbDisabled = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSendTest = new System.Windows.Forms.ToolStripButton();
            this.btnGetCode = new System.Windows.Forms.ToolStripSplitButton();
            this.btnCSharp = new System.Windows.Forms.ToolStripMenuItem();
            this.btnJs = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPowerAutomate = new System.Windows.Forms.ToolStripMenuItem();
            this.gbPreview = new System.Windows.Forms.GroupBox();
            this.wbPreview = new System.Windows.Forms.WebBrowser();
            this.gbData = new System.Windows.Forms.GroupBox();
            this.tbExpiresIn = new System.Windows.Forms.TextBox();
            this.cbExpiresIn = new System.Windows.Forms.ComboBox();
            this.lblExpiresIn = new System.Windows.Forms.Label();
            this.btnH1 = new System.Windows.Forms.Button();
            this.cbCustomIcon = new System.Windows.Forms.ComboBox();
            this.lblCustomIcon = new System.Windows.Forms.Label();
            this.btnInsertImage = new System.Windows.Forms.Button();
            this.btnItalic = new System.Windows.Forms.Button();
            this.btnBold = new System.Windows.Forms.Button();
            this.btnInsertLink = new System.Windows.Forms.Button();
            this.tbBody = new System.Windows.Forms.TextBox();
            this.cbToastType = new System.Windows.Forms.ComboBox();
            this.lblToastType = new System.Windows.Forms.Label();
            this.gbActions = new System.Windows.Forms.GroupBox();
            this.btnDeleteAction = new System.Windows.Forms.Button();
            this.btnEditAction = new System.Windows.Forms.Button();
            this.btnAddAction = new System.Windows.Forms.Button();
            this.dgvActions = new System.Windows.Forms.DataGridView();
            this.cbIcon = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStripMenu.SuspendLayout();
            this.gbPreview.SuspendLayout();
            this.gbData.SuspendLayout();
            this.gbActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActions)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbClose,
            this.tssSeparator1,
            this.toolStripLabel1,
            this.tscbApp,
            this.toolStripLabel2,
            this.tsbEnabled,
            this.tsbDisabled,
            this.toolStripSeparator1,
            this.tsbSendTest,
            this.btnGetCode});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Size = new System.Drawing.Size(1258, 34);
            this.toolStripMenu.TabIndex = 4;
            this.toolStripMenu.Text = "toolStrip1";
            // 
            // tsbClose
            // 
            this.tsbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbClose.Image = ((System.Drawing.Image)(resources.GetObject("tsbClose.Image")));
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(34, 29);
            this.tsbClose.Text = "x";
            this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);
            // 
            // tssSeparator1
            // 
            this.tssSeparator1.Name = "tssSeparator1";
            this.tssSeparator1.Size = new System.Drawing.Size(6, 34);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(46, 29);
            this.toolStripLabel1.Text = "App";
            // 
            // tscbApp
            // 
            this.tscbApp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscbApp.DropDownWidth = 150;
            this.tscbApp.Name = "tscbApp";
            this.tscbApp.Size = new System.Drawing.Size(150, 34);
            this.tscbApp.SelectedIndexChanged += new System.EventHandler(this.tscbApp_SelectedIndexChanged);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(165, 29);
            this.toolStripLabel2.Text = "Notifications Status";
            // 
            // tsbEnabled
            // 
            this.tsbEnabled.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEnabled.Image = ((System.Drawing.Image)(resources.GetObject("tsbEnabled.Image")));
            this.tsbEnabled.Name = "tsbEnabled";
            this.tsbEnabled.Size = new System.Drawing.Size(24, 29);
            this.tsbEnabled.Text = "toolStripLabel3";
            this.tsbEnabled.Visible = false;
            this.tsbEnabled.Click += new System.EventHandler(this.tsbEnabled_Click);
            // 
            // tsbDisabled
            // 
            this.tsbDisabled.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDisabled.Image = ((System.Drawing.Image)(resources.GetObject("tsbDisabled.Image")));
            this.tsbDisabled.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDisabled.Name = "tsbDisabled";
            this.tsbDisabled.Size = new System.Drawing.Size(34, 29);
            this.tsbDisabled.Text = "toolStripButton1";
            this.tsbDisabled.Visible = false;
            this.tsbDisabled.Click += new System.EventHandler(this.tsbDisabled_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 34);
            // 
            // tsbSendTest
            // 
            this.tsbSendTest.Image = ((System.Drawing.Image)(resources.GetObject("tsbSendTest.Image")));
            this.tsbSendTest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSendTest.Name = "tsbSendTest";
            this.tsbSendTest.Size = new System.Drawing.Size(70, 29);
            this.tsbSendTest.Text = "Test";
            this.tsbSendTest.Click += new System.EventHandler(this.tsbSendTest_Click);
            // 
            // btnGetCode
            // 
            this.btnGetCode.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCSharp,
            this.btnJs,
            this.btnPowerAutomate});
            this.btnGetCode.Image = ((System.Drawing.Image)(resources.GetObject("btnGetCode.Image")));
            this.btnGetCode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGetCode.Name = "btnGetCode";
            this.btnGetCode.Size = new System.Drawing.Size(131, 29);
            this.btnGetCode.Text = "Get Code";
            this.btnGetCode.ButtonClick += new System.EventHandler(this.btnGetCode_ButtonClick);
            // 
            // btnCSharp
            // 
            this.btnCSharp.Image = ((System.Drawing.Image)(resources.GetObject("btnCSharp.Image")));
            this.btnCSharp.Name = "btnCSharp";
            this.btnCSharp.Size = new System.Drawing.Size(246, 34);
            this.btnCSharp.Text = "C# Code";
            this.btnCSharp.Click += new System.EventHandler(this.btnCSharp_Click);
            // 
            // btnJs
            // 
            this.btnJs.Image = ((System.Drawing.Image)(resources.GetObject("btnJs.Image")));
            this.btnJs.Name = "btnJs";
            this.btnJs.Size = new System.Drawing.Size(246, 34);
            this.btnJs.Text = "JavaScript Code";
            this.btnJs.Click += new System.EventHandler(this.btnJs_Click);
            // 
            // btnPowerAutomate
            // 
            this.btnPowerAutomate.Image = ((System.Drawing.Image)(resources.GetObject("btnPowerAutomate.Image")));
            this.btnPowerAutomate.Name = "btnPowerAutomate";
            this.btnPowerAutomate.Size = new System.Drawing.Size(246, 34);
            this.btnPowerAutomate.Text = "Power Automate";
            this.btnPowerAutomate.Click += new System.EventHandler(this.btnPowerAutomate_Click);
            // 
            // gbPreview
            // 
            this.gbPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbPreview.Controls.Add(this.wbPreview);
            this.gbPreview.Location = new System.Drawing.Point(629, 3);
            this.gbPreview.Name = "gbPreview";
            this.gbPreview.Size = new System.Drawing.Size(620, 790);
            this.gbPreview.TabIndex = 6;
            this.gbPreview.TabStop = false;
            this.gbPreview.Text = "Preview";
            // 
            // wbPreview
            // 
            this.wbPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wbPreview.Location = new System.Drawing.Point(6, 25);
            this.wbPreview.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbPreview.Name = "wbPreview";
            this.wbPreview.ScrollBarsEnabled = false;
            this.wbPreview.Size = new System.Drawing.Size(608, 759);
            this.wbPreview.TabIndex = 5;
            // 
            // gbData
            // 
            this.gbData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbData.Controls.Add(this.tbExpiresIn);
            this.gbData.Controls.Add(this.cbExpiresIn);
            this.gbData.Controls.Add(this.lblExpiresIn);
            this.gbData.Controls.Add(this.btnH1);
            this.gbData.Controls.Add(this.cbCustomIcon);
            this.gbData.Controls.Add(this.lblCustomIcon);
            this.gbData.Controls.Add(this.btnInsertImage);
            this.gbData.Controls.Add(this.btnItalic);
            this.gbData.Controls.Add(this.btnBold);
            this.gbData.Controls.Add(this.btnInsertLink);
            this.gbData.Controls.Add(this.tbBody);
            this.gbData.Controls.Add(this.cbToastType);
            this.gbData.Controls.Add(this.lblToastType);
            this.gbData.Controls.Add(this.gbActions);
            this.gbData.Controls.Add(this.cbIcon);
            this.gbData.Controls.Add(this.label3);
            this.gbData.Controls.Add(this.label1);
            this.gbData.Controls.Add(this.label2);
            this.gbData.Controls.Add(this.tbTitle);
            this.gbData.Location = new System.Drawing.Point(3, 3);
            this.gbData.Name = "gbData";
            this.gbData.Size = new System.Drawing.Size(620, 790);
            this.gbData.TabIndex = 7;
            this.gbData.TabStop = false;
            this.gbData.Text = "Data";
            // 
            // tbExpiresIn
            // 
            this.tbExpiresIn.Location = new System.Drawing.Point(99, 393);
            this.tbExpiresIn.Name = "tbExpiresIn";
            this.tbExpiresIn.Size = new System.Drawing.Size(303, 26);
            this.tbExpiresIn.TabIndex = 29;
            this.tbExpiresIn.Text = "2";
            // 
            // cbExpiresIn
            // 
            this.cbExpiresIn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbExpiresIn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbExpiresIn.FormattingEnabled = true;
            this.cbExpiresIn.Location = new System.Drawing.Point(408, 393);
            this.cbExpiresIn.Name = "cbExpiresIn";
            this.cbExpiresIn.Size = new System.Drawing.Size(206, 28);
            this.cbExpiresIn.TabIndex = 28;
            // 
            // lblExpiresIn
            // 
            this.lblExpiresIn.AutoSize = true;
            this.lblExpiresIn.Location = new System.Drawing.Point(6, 396);
            this.lblExpiresIn.Name = "lblExpiresIn";
            this.lblExpiresIn.Size = new System.Drawing.Size(79, 20);
            this.lblExpiresIn.TabIndex = 27;
            this.lblExpiresIn.Text = "Expires In";
            // 
            // btnH1
            // 
            this.btnH1.Image = ((System.Drawing.Image)(resources.GetObject("btnH1.Image")));
            this.btnH1.Location = new System.Drawing.Point(271, 98);
            this.btnH1.Name = "btnH1";
            this.btnH1.Size = new System.Drawing.Size(80, 40);
            this.btnH1.TabIndex = 26;
            this.btnH1.UseVisualStyleBackColor = true;
            this.btnH1.Click += new System.EventHandler(this.btnH1_Click);
            // 
            // cbCustomIcon
            // 
            this.cbCustomIcon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCustomIcon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCustomIcon.FormattingEnabled = true;
            this.cbCustomIcon.Location = new System.Drawing.Point(99, 504);
            this.cbCustomIcon.Name = "cbCustomIcon";
            this.cbCustomIcon.Size = new System.Drawing.Size(515, 28);
            this.cbCustomIcon.TabIndex = 25;
            this.cbCustomIcon.Visible = false;
            this.cbCustomIcon.SelectedIndexChanged += new System.EventHandler(this.cbCustomIcon_SelectedIndexChanged);
            // 
            // lblCustomIcon
            // 
            this.lblCustomIcon.AutoSize = true;
            this.lblCustomIcon.Location = new System.Drawing.Point(8, 507);
            this.lblCustomIcon.Name = "lblCustomIcon";
            this.lblCustomIcon.Size = new System.Drawing.Size(54, 20);
            this.lblCustomIcon.TabIndex = 24;
            this.lblCustomIcon.Text = "Image";
            this.lblCustomIcon.Visible = false;
            // 
            // btnInsertImage
            // 
            this.btnInsertImage.Image = ((System.Drawing.Image)(resources.GetObject("btnInsertImage.Image")));
            this.btnInsertImage.Location = new System.Drawing.Point(443, 98);
            this.btnInsertImage.Name = "btnInsertImage";
            this.btnInsertImage.Size = new System.Drawing.Size(80, 40);
            this.btnInsertImage.TabIndex = 23;
            this.btnInsertImage.UseVisualStyleBackColor = true;
            this.btnInsertImage.Click += new System.EventHandler(this.btnInsertImage_Click);
            // 
            // btnItalic
            // 
            this.btnItalic.Image = ((System.Drawing.Image)(resources.GetObject("btnItalic.Image")));
            this.btnItalic.Location = new System.Drawing.Point(185, 98);
            this.btnItalic.Name = "btnItalic";
            this.btnItalic.Size = new System.Drawing.Size(80, 40);
            this.btnItalic.TabIndex = 22;
            this.btnItalic.UseVisualStyleBackColor = true;
            this.btnItalic.Click += new System.EventHandler(this.btnItalic_Click);
            // 
            // btnBold
            // 
            this.btnBold.Image = ((System.Drawing.Image)(resources.GetObject("btnBold.Image")));
            this.btnBold.Location = new System.Drawing.Point(99, 98);
            this.btnBold.Name = "btnBold";
            this.btnBold.Size = new System.Drawing.Size(80, 40);
            this.btnBold.TabIndex = 21;
            this.btnBold.UseVisualStyleBackColor = true;
            this.btnBold.Click += new System.EventHandler(this.btnBold_Click);
            // 
            // btnInsertLink
            // 
            this.btnInsertLink.Image = ((System.Drawing.Image)(resources.GetObject("btnInsertLink.Image")));
            this.btnInsertLink.Location = new System.Drawing.Point(357, 98);
            this.btnInsertLink.Name = "btnInsertLink";
            this.btnInsertLink.Size = new System.Drawing.Size(80, 40);
            this.btnInsertLink.TabIndex = 20;
            this.btnInsertLink.UseVisualStyleBackColor = true;
            this.btnInsertLink.Click += new System.EventHandler(this.btnInsertLink_Click);
            // 
            // tbBody
            // 
            this.tbBody.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbBody.Location = new System.Drawing.Point(99, 144);
            this.tbBody.Multiline = true;
            this.tbBody.Name = "tbBody";
            this.tbBody.Size = new System.Drawing.Size(515, 170);
            this.tbBody.TabIndex = 19;
            this.tbBody.TextChanged += new System.EventHandler(this.tbBody_TextChanged);
            // 
            // cbToastType
            // 
            this.cbToastType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbToastType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbToastType.FormattingEnabled = true;
            this.cbToastType.Location = new System.Drawing.Point(99, 338);
            this.cbToastType.Name = "cbToastType";
            this.cbToastType.Size = new System.Drawing.Size(515, 28);
            this.cbToastType.TabIndex = 18;
            // 
            // lblToastType
            // 
            this.lblToastType.AutoSize = true;
            this.lblToastType.Location = new System.Drawing.Point(6, 341);
            this.lblToastType.Name = "lblToastType";
            this.lblToastType.Size = new System.Drawing.Size(87, 20);
            this.lblToastType.TabIndex = 17;
            this.lblToastType.Text = "Toast Type";
            // 
            // gbActions
            // 
            this.gbActions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbActions.Controls.Add(this.btnDeleteAction);
            this.gbActions.Controls.Add(this.btnEditAction);
            this.gbActions.Controls.Add(this.btnAddAction);
            this.gbActions.Controls.Add(this.dgvActions);
            this.gbActions.Location = new System.Drawing.Point(6, 547);
            this.gbActions.Name = "gbActions";
            this.gbActions.Size = new System.Drawing.Size(608, 237);
            this.gbActions.TabIndex = 16;
            this.gbActions.TabStop = false;
            this.gbActions.Text = "Actions";
            // 
            // btnDeleteAction
            // 
            this.btnDeleteAction.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteAction.Image")));
            this.btnDeleteAction.Location = new System.Drawing.Point(258, 25);
            this.btnDeleteAction.Name = "btnDeleteAction";
            this.btnDeleteAction.Size = new System.Drawing.Size(120, 50);
            this.btnDeleteAction.TabIndex = 3;
            this.btnDeleteAction.Text = "Delete";
            this.btnDeleteAction.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDeleteAction.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDeleteAction.UseVisualStyleBackColor = true;
            this.btnDeleteAction.Click += new System.EventHandler(this.btnDeleteAction_Click);
            // 
            // btnEditAction
            // 
            this.btnEditAction.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnEditAction.Image = ((System.Drawing.Image)(resources.GetObject("btnEditAction.Image")));
            this.btnEditAction.Location = new System.Drawing.Point(132, 25);
            this.btnEditAction.Name = "btnEditAction";
            this.btnEditAction.Size = new System.Drawing.Size(120, 50);
            this.btnEditAction.TabIndex = 2;
            this.btnEditAction.Text = "Edit";
            this.btnEditAction.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditAction.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEditAction.UseVisualStyleBackColor = true;
            this.btnEditAction.Click += new System.EventHandler(this.btnEditAction_Click);
            // 
            // btnAddAction
            // 
            this.btnAddAction.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddAction.Image = ((System.Drawing.Image)(resources.GetObject("btnAddAction.Image")));
            this.btnAddAction.Location = new System.Drawing.Point(6, 25);
            this.btnAddAction.Name = "btnAddAction";
            this.btnAddAction.Size = new System.Drawing.Size(120, 50);
            this.btnAddAction.TabIndex = 1;
            this.btnAddAction.Text = "Add";
            this.btnAddAction.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddAction.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddAction.UseVisualStyleBackColor = true;
            this.btnAddAction.Click += new System.EventHandler(this.btnAddAction_Click);
            // 
            // dgvActions
            // 
            this.dgvActions.AllowUserToAddRows = false;
            this.dgvActions.AllowUserToDeleteRows = false;
            this.dgvActions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvActions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvActions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvActions.Location = new System.Drawing.Point(6, 86);
            this.dgvActions.Name = "dgvActions";
            this.dgvActions.ReadOnly = true;
            this.dgvActions.RowHeadersWidth = 62;
            this.dgvActions.RowTemplate.Height = 28;
            this.dgvActions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvActions.Size = new System.Drawing.Size(596, 145);
            this.dgvActions.TabIndex = 0;
            this.dgvActions.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvActions_CellContentDoubleClick);
            // 
            // cbIcon
            // 
            this.cbIcon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbIcon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIcon.FormattingEnabled = true;
            this.cbIcon.Location = new System.Drawing.Point(99, 448);
            this.cbIcon.Name = "cbIcon";
            this.cbIcon.Size = new System.Drawing.Size(515, 28);
            this.cbIcon.TabIndex = 13;
            this.cbIcon.SelectedIndexChanged += new System.EventHandler(this.cbIcon_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 451);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "Icon";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Body";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Title";
            // 
            // tbTitle
            // 
            this.tbTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTitle.Location = new System.Drawing.Point(99, 39);
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.Size = new System.Drawing.Size(515, 26);
            this.tbTitle.TabIndex = 7;
            this.tbTitle.TextChanged += new System.EventHandler(this.tbTitle_TextChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.gbData, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.gbPreview, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 41);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1252, 796);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // InAppNotificationBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.toolStripMenu);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "InAppNotificationBuilder";
            this.Size = new System.Drawing.Size(1258, 840);
            this.Load += new System.EventHandler(this.MyPluginControl_Load);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            this.gbPreview.ResumeLayout(false);
            this.gbData.ResumeLayout(false);
            this.gbData.PerformLayout();
            this.gbActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvActions)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.ToolStripSeparator tssSeparator1;
        private System.Windows.Forms.ToolStripComboBox tscbApp;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripButton tsbSendTest;
        private System.Windows.Forms.ToolStripLabel tsbEnabled;
        private System.Windows.Forms.ToolStripButton tsbDisabled;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox gbData;
        private System.Windows.Forms.ComboBox cbIcon;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbTitle;
        private System.Windows.Forms.GroupBox gbPreview;
        private System.Windows.Forms.WebBrowser wbPreview;
        private System.Windows.Forms.GroupBox gbActions;
        private System.Windows.Forms.DataGridView dgvActions;
        private System.Windows.Forms.Button btnAddAction;
        private System.Windows.Forms.Button btnDeleteAction;
        private System.Windows.Forms.Button btnEditAction;
        private System.Windows.Forms.ToolStripSplitButton btnGetCode;
        private System.Windows.Forms.ToolStripMenuItem btnCSharp;
        private System.Windows.Forms.ToolStripMenuItem btnJs;
        private System.Windows.Forms.ToolStripMenuItem btnPowerAutomate;
        private System.Windows.Forms.ComboBox cbToastType;
        private System.Windows.Forms.Label lblToastType;
        private System.Windows.Forms.TextBox tbBody;
        private System.Windows.Forms.Button btnInsertLink;
        private System.Windows.Forms.Button btnBold;
        private System.Windows.Forms.Button btnItalic;
        private System.Windows.Forms.Button btnInsertImage;
        private System.Windows.Forms.ComboBox cbCustomIcon;
        private System.Windows.Forms.Label lblCustomIcon;
        private System.Windows.Forms.Button btnH1;
        private System.Windows.Forms.TextBox tbExpiresIn;
        private System.Windows.Forms.ComboBox cbExpiresIn;
        private System.Windows.Forms.Label lblExpiresIn;
    }
}
