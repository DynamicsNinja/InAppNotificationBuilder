
namespace Fic.XTB.InAppNotificationBuilder.Forms
{
    partial class InsertLinkForm
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
            this.components = new System.ComponentModel.Container();
            this.lblActionText = new System.Windows.Forms.Label();
            this.cbActionType = new System.Windows.Forms.ComboBox();
            this.btnInsertLink = new System.Windows.Forms.Button();
            this.lblActionType = new System.Windows.Forms.Label();
            this.tbActionText = new System.Windows.Forms.TextBox();
            this.lblUrl = new System.Windows.Forms.Label();
            this.tbUrl = new System.Windows.Forms.TextBox();
            this.lblEntity = new System.Windows.Forms.Label();
            this.cbEntity = new System.Windows.Forms.ComboBox();
            this.lblForm = new System.Windows.Forms.Label();
            this.cbForm = new System.Windows.Forms.ComboBox();
            this.cbView = new System.Windows.Forms.ComboBox();
            this.lblView = new System.Windows.Forms.Label();
            this.tbRecordId = new System.Windows.Forms.TextBox();
            this.lblRecordId = new System.Windows.Forms.Label();
            this.cbCustomPage = new System.Windows.Forms.ComboBox();
            this.lblCustomPage = new System.Windows.Forms.Label();
            this.lblDashboard = new System.Windows.Forms.Label();
            this.cbDashboard = new System.Windows.Forms.ComboBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblWebresource = new System.Windows.Forms.Label();
            this.cbWebresource = new System.Windows.Forms.ComboBox();
            this.dgvDataParams = new System.Windows.Forms.DataGridView();
            this.Key = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblDataParams = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataParams)).BeginInit();
            this.SuspendLayout();
            // 
            // lblActionText
            // 
            this.lblActionText.AutoSize = true;
            this.lblActionText.Location = new System.Drawing.Point(12, 29);
            this.lblActionText.Name = "lblActionText";
            this.lblActionText.Size = new System.Drawing.Size(39, 20);
            this.lblActionText.TabIndex = 0;
            this.lblActionText.Text = "Text";
            // 
            // cbActionType
            // 
            this.cbActionType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbActionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbActionType.FormattingEnabled = true;
            this.cbActionType.Items.AddRange(new object[] {
            "Url",
            "Record",
            "List"});
            this.cbActionType.Location = new System.Drawing.Point(106, 73);
            this.cbActionType.Name = "cbActionType";
            this.cbActionType.Size = new System.Drawing.Size(682, 28);
            this.cbActionType.TabIndex = 1;
            this.cbActionType.SelectedIndexChanged += new System.EventHandler(this.cbActionType_SelectedIndexChanged);
            // 
            // btnInsertLink
            // 
            this.btnInsertLink.Location = new System.Drawing.Point(355, 436);
            this.btnInsertLink.Name = "btnInsertLink";
            this.btnInsertLink.Size = new System.Drawing.Size(99, 48);
            this.btnInsertLink.TabIndex = 3;
            this.btnInsertLink.Text = "Insert";
            this.btnInsertLink.UseVisualStyleBackColor = true;
            this.btnInsertLink.Click += new System.EventHandler(this.btnSaveAction_Click);
            // 
            // lblActionType
            // 
            this.lblActionType.AutoSize = true;
            this.lblActionType.Location = new System.Drawing.Point(12, 76);
            this.lblActionType.Name = "lblActionType";
            this.lblActionType.Size = new System.Drawing.Size(43, 20);
            this.lblActionType.TabIndex = 4;
            this.lblActionType.Text = "Type";
            // 
            // tbActionText
            // 
            this.tbActionText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbActionText.Location = new System.Drawing.Point(106, 26);
            this.tbActionText.Name = "tbActionText";
            this.tbActionText.Size = new System.Drawing.Size(682, 26);
            this.tbActionText.TabIndex = 5;
            this.tbActionText.Validating += new System.ComponentModel.CancelEventHandler(this.tbActionText_Validating);
            // 
            // lblUrl
            // 
            this.lblUrl.AutoSize = true;
            this.lblUrl.Location = new System.Drawing.Point(12, 128);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(29, 20);
            this.lblUrl.TabIndex = 6;
            this.lblUrl.Text = "Url";
            // 
            // tbUrl
            // 
            this.tbUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbUrl.CausesValidation = false;
            this.tbUrl.Enabled = false;
            this.tbUrl.Location = new System.Drawing.Point(106, 125);
            this.tbUrl.Name = "tbUrl";
            this.tbUrl.Size = new System.Drawing.Size(682, 26);
            this.tbUrl.TabIndex = 7;
            this.tbUrl.Validating += new System.ComponentModel.CancelEventHandler(this.tbUrl_Validating);
            // 
            // lblEntity
            // 
            this.lblEntity.AutoSize = true;
            this.lblEntity.Location = new System.Drawing.Point(12, 177);
            this.lblEntity.Name = "lblEntity";
            this.lblEntity.Size = new System.Drawing.Size(49, 20);
            this.lblEntity.TabIndex = 8;
            this.lblEntity.Text = "Entity";
            // 
            // cbEntity
            // 
            this.cbEntity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbEntity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEntity.FormattingEnabled = true;
            this.cbEntity.Location = new System.Drawing.Point(106, 177);
            this.cbEntity.Name = "cbEntity";
            this.cbEntity.Size = new System.Drawing.Size(682, 28);
            this.cbEntity.TabIndex = 9;
            this.cbEntity.SelectedIndexChanged += new System.EventHandler(this.cbEntity_SelectedIndexChanged);
            // 
            // lblForm
            // 
            this.lblForm.AutoSize = true;
            this.lblForm.Location = new System.Drawing.Point(12, 232);
            this.lblForm.Name = "lblForm";
            this.lblForm.Size = new System.Drawing.Size(46, 20);
            this.lblForm.TabIndex = 10;
            this.lblForm.Text = "Form";
            // 
            // cbForm
            // 
            this.cbForm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbForm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbForm.FormattingEnabled = true;
            this.cbForm.Location = new System.Drawing.Point(106, 229);
            this.cbForm.Name = "cbForm";
            this.cbForm.Size = new System.Drawing.Size(682, 28);
            this.cbForm.TabIndex = 11;
            this.cbForm.SelectedIndexChanged += new System.EventHandler(this.cbForm_SelectedIndexChanged);
            // 
            // cbView
            // 
            this.cbView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbView.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbView.FormattingEnabled = true;
            this.cbView.Location = new System.Drawing.Point(106, 229);
            this.cbView.Name = "cbView";
            this.cbView.Size = new System.Drawing.Size(682, 28);
            this.cbView.TabIndex = 13;
            this.cbView.SelectedIndexChanged += new System.EventHandler(this.cbView_SelectedIndexChanged);
            // 
            // lblView
            // 
            this.lblView.AutoSize = true;
            this.lblView.Location = new System.Drawing.Point(12, 232);
            this.lblView.Name = "lblView";
            this.lblView.Size = new System.Drawing.Size(43, 20);
            this.lblView.TabIndex = 12;
            this.lblView.Text = "View";
            // 
            // tbRecordId
            // 
            this.tbRecordId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbRecordId.Location = new System.Drawing.Point(106, 286);
            this.tbRecordId.Name = "tbRecordId";
            this.tbRecordId.Size = new System.Drawing.Size(682, 26);
            this.tbRecordId.TabIndex = 15;
            this.tbRecordId.TextChanged += new System.EventHandler(this.tbRecordId_TextChanged);
            // 
            // lblRecordId
            // 
            this.lblRecordId.AutoSize = true;
            this.lblRecordId.Location = new System.Drawing.Point(12, 289);
            this.lblRecordId.Name = "lblRecordId";
            this.lblRecordId.Size = new System.Drawing.Size(23, 20);
            this.lblRecordId.TabIndex = 14;
            this.lblRecordId.Text = "Id";
            // 
            // cbCustomPage
            // 
            this.cbCustomPage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCustomPage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCustomPage.FormattingEnabled = true;
            this.cbCustomPage.Location = new System.Drawing.Point(106, 177);
            this.cbCustomPage.Name = "cbCustomPage";
            this.cbCustomPage.Size = new System.Drawing.Size(682, 28);
            this.cbCustomPage.TabIndex = 21;
            this.cbCustomPage.SelectedIndexChanged += new System.EventHandler(this.cbCustomPage_SelectedIndexChanged);
            // 
            // lblCustomPage
            // 
            this.lblCustomPage.AutoSize = true;
            this.lblCustomPage.Location = new System.Drawing.Point(12, 177);
            this.lblCustomPage.Name = "lblCustomPage";
            this.lblCustomPage.Size = new System.Drawing.Size(46, 20);
            this.lblCustomPage.TabIndex = 20;
            this.lblCustomPage.Text = "Page";
            // 
            // lblDashboard
            // 
            this.lblDashboard.AutoSize = true;
            this.lblDashboard.Location = new System.Drawing.Point(12, 177);
            this.lblDashboard.Name = "lblDashboard";
            this.lblDashboard.Size = new System.Drawing.Size(88, 20);
            this.lblDashboard.TabIndex = 22;
            this.lblDashboard.Text = "Dashboard";
            // 
            // cbDashboard
            // 
            this.cbDashboard.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbDashboard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDashboard.FormattingEnabled = true;
            this.cbDashboard.Location = new System.Drawing.Point(106, 177);
            this.cbDashboard.Name = "cbDashboard";
            this.cbDashboard.Size = new System.Drawing.Size(682, 28);
            this.cbDashboard.TabIndex = 23;
            this.cbDashboard.SelectedIndexChanged += new System.EventHandler(this.cbDashboard_SelectedIndexChanged);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // lblWebresource
            // 
            this.lblWebresource.AutoSize = true;
            this.lblWebresource.Location = new System.Drawing.Point(12, 177);
            this.lblWebresource.Name = "lblWebresource";
            this.lblWebresource.Size = new System.Drawing.Size(52, 20);
            this.lblWebresource.TabIndex = 24;
            this.lblWebresource.Text = "HTML";
            // 
            // cbWebresource
            // 
            this.cbWebresource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbWebresource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWebresource.FormattingEnabled = true;
            this.cbWebresource.Location = new System.Drawing.Point(106, 177);
            this.cbWebresource.Name = "cbWebresource";
            this.cbWebresource.Size = new System.Drawing.Size(682, 28);
            this.cbWebresource.TabIndex = 25;
            this.cbWebresource.SelectedIndexChanged += new System.EventHandler(this.cbWebresource_SelectedIndexChanged);
            // 
            // dgvDataParams
            // 
            this.dgvDataParams.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDataParams.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDataParams.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Key,
            this.Value});
            this.dgvDataParams.Location = new System.Drawing.Point(106, 229);
            this.dgvDataParams.Name = "dgvDataParams";
            this.dgvDataParams.RowHeadersWidth = 62;
            this.dgvDataParams.RowTemplate.Height = 28;
            this.dgvDataParams.Size = new System.Drawing.Size(682, 157);
            this.dgvDataParams.TabIndex = 26;
            this.dgvDataParams.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDataParams_CellEndEdit);
            // 
            // Key
            // 
            this.Key.HeaderText = "Key";
            this.Key.MinimumWidth = 8;
            this.Key.Name = "Key";
            // 
            // Value
            // 
            this.Value.HeaderText = "Value";
            this.Value.MinimumWidth = 8;
            this.Value.Name = "Value";
            // 
            // lblDataParams
            // 
            this.lblDataParams.AutoSize = true;
            this.lblDataParams.Location = new System.Drawing.Point(12, 232);
            this.lblDataParams.Name = "lblDataParams";
            this.lblDataParams.Size = new System.Drawing.Size(44, 20);
            this.lblDataParams.TabIndex = 27;
            this.lblDataParams.Text = "Data";
            // 
            // InsertLinkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 517);
            this.Controls.Add(this.lblDataParams);
            this.Controls.Add(this.dgvDataParams);
            this.Controls.Add(this.lblWebresource);
            this.Controls.Add(this.cbWebresource);
            this.Controls.Add(this.lblDashboard);
            this.Controls.Add(this.cbDashboard);
            this.Controls.Add(this.lblCustomPage);
            this.Controls.Add(this.cbCustomPage);
            this.Controls.Add(this.tbRecordId);
            this.Controls.Add(this.lblRecordId);
            this.Controls.Add(this.cbView);
            this.Controls.Add(this.lblView);
            this.Controls.Add(this.cbForm);
            this.Controls.Add(this.lblForm);
            this.Controls.Add(this.cbEntity);
            this.Controls.Add(this.lblEntity);
            this.Controls.Add(this.tbUrl);
            this.Controls.Add(this.lblUrl);
            this.Controls.Add(this.tbActionText);
            this.Controls.Add(this.lblActionType);
            this.Controls.Add(this.btnInsertLink);
            this.Controls.Add(this.cbActionType);
            this.Controls.Add(this.lblActionText);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InsertLinkForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Insert Link";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataParams)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblActionText;
        private System.Windows.Forms.ComboBox cbActionType;
        private System.Windows.Forms.Button btnInsertLink;
        private System.Windows.Forms.Label lblActionType;
        private System.Windows.Forms.TextBox tbActionText;
        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.TextBox tbUrl;
        private System.Windows.Forms.Label lblEntity;
        private System.Windows.Forms.ComboBox cbEntity;
        private System.Windows.Forms.Label lblForm;
        private System.Windows.Forms.ComboBox cbForm;
        private System.Windows.Forms.ComboBox cbView;
        private System.Windows.Forms.Label lblView;
        private System.Windows.Forms.TextBox tbRecordId;
        private System.Windows.Forms.Label lblRecordId;
        private System.Windows.Forms.ComboBox cbCustomPage;
        private System.Windows.Forms.Label lblCustomPage;
        private System.Windows.Forms.Label lblDashboard;
        private System.Windows.Forms.ComboBox cbDashboard;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label lblWebresource;
        private System.Windows.Forms.ComboBox cbWebresource;
        private System.Windows.Forms.DataGridView dgvDataParams;
        private System.Windows.Forms.DataGridViewTextBoxColumn Key;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.Label lblDataParams;
    }
}