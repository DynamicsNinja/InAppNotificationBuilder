
namespace Fic.XTB.InAppNotificationBuilder.Forms
{
    partial class ActionForm
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
            this.lblActionText = new System.Windows.Forms.Label();
            this.cbActionType = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSaveAction = new System.Windows.Forms.Button();
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
            this.lblNavigationTarget = new System.Windows.Forms.Label();
            this.cbNavigationTarget = new System.Windows.Forms.ComboBox();
            this.cbCustomPage = new System.Windows.Forms.ComboBox();
            this.lblCustomPage = new System.Windows.Forms.Label();
            this.cbDashboard = new System.Windows.Forms.ComboBox();
            this.lblDashboard = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblActionText
            // 
            this.lblActionText.AutoSize = true;
            this.lblActionText.Location = new System.Drawing.Point(12, 29);
            this.lblActionText.Name = "lblActionText";
            this.lblActionText.Size = new System.Drawing.Size(88, 20);
            this.lblActionText.TabIndex = 0;
            this.lblActionText.Text = "Action Text";
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
            this.cbActionType.Location = new System.Drawing.Point(106, 126);
            this.cbActionType.Name = "cbActionType";
            this.cbActionType.Size = new System.Drawing.Size(682, 28);
            this.cbActionType.TabIndex = 1;
            this.cbActionType.SelectedIndexChanged += new System.EventHandler(this.cbActionType_SelectedIndexChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(689, 390);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(99, 48);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSaveAction
            // 
            this.btnSaveAction.Location = new System.Drawing.Point(584, 390);
            this.btnSaveAction.Name = "btnSaveAction";
            this.btnSaveAction.Size = new System.Drawing.Size(99, 48);
            this.btnSaveAction.TabIndex = 3;
            this.btnSaveAction.Text = "Add";
            this.btnSaveAction.UseVisualStyleBackColor = true;
            this.btnSaveAction.Click += new System.EventHandler(this.btnSaveAction_Click);
            // 
            // lblActionType
            // 
            this.lblActionType.AutoSize = true;
            this.lblActionType.Location = new System.Drawing.Point(12, 129);
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
            // 
            // lblUrl
            // 
            this.lblUrl.AutoSize = true;
            this.lblUrl.Location = new System.Drawing.Point(12, 181);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(29, 20);
            this.lblUrl.TabIndex = 6;
            this.lblUrl.Text = "Url";
            // 
            // tbUrl
            // 
            this.tbUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbUrl.Enabled = false;
            this.tbUrl.Location = new System.Drawing.Point(106, 178);
            this.tbUrl.Name = "tbUrl";
            this.tbUrl.Size = new System.Drawing.Size(682, 26);
            this.tbUrl.TabIndex = 7;
            // 
            // lblEntity
            // 
            this.lblEntity.AutoSize = true;
            this.lblEntity.Location = new System.Drawing.Point(12, 230);
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
            this.cbEntity.Location = new System.Drawing.Point(106, 230);
            this.cbEntity.Name = "cbEntity";
            this.cbEntity.Size = new System.Drawing.Size(682, 28);
            this.cbEntity.TabIndex = 9;
            this.cbEntity.SelectedIndexChanged += new System.EventHandler(this.cbEntity_SelectedIndexChanged);
            // 
            // lblForm
            // 
            this.lblForm.AutoSize = true;
            this.lblForm.Location = new System.Drawing.Point(12, 285);
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
            this.cbForm.Location = new System.Drawing.Point(106, 282);
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
            this.cbView.Location = new System.Drawing.Point(106, 282);
            this.cbView.Name = "cbView";
            this.cbView.Size = new System.Drawing.Size(682, 28);
            this.cbView.TabIndex = 13;
            this.cbView.SelectedIndexChanged += new System.EventHandler(this.cbView_SelectedIndexChanged);
            // 
            // lblView
            // 
            this.lblView.AutoSize = true;
            this.lblView.Location = new System.Drawing.Point(12, 285);
            this.lblView.Name = "lblView";
            this.lblView.Size = new System.Drawing.Size(43, 20);
            this.lblView.TabIndex = 12;
            this.lblView.Text = "View";
            // 
            // tbRecordId
            // 
            this.tbRecordId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbRecordId.Location = new System.Drawing.Point(106, 339);
            this.tbRecordId.Name = "tbRecordId";
            this.tbRecordId.Size = new System.Drawing.Size(682, 26);
            this.tbRecordId.TabIndex = 15;
            this.tbRecordId.TextChanged += new System.EventHandler(this.tbRecordId_TextChanged);
            // 
            // lblRecordId
            // 
            this.lblRecordId.AutoSize = true;
            this.lblRecordId.Location = new System.Drawing.Point(12, 342);
            this.lblRecordId.Name = "lblRecordId";
            this.lblRecordId.Size = new System.Drawing.Size(23, 20);
            this.lblRecordId.TabIndex = 14;
            this.lblRecordId.Text = "Id";
            // 
            // lblNavigationTarget
            // 
            this.lblNavigationTarget.AutoSize = true;
            this.lblNavigationTarget.Location = new System.Drawing.Point(12, 77);
            this.lblNavigationTarget.Name = "lblNavigationTarget";
            this.lblNavigationTarget.Size = new System.Drawing.Size(71, 20);
            this.lblNavigationTarget.TabIndex = 17;
            this.lblNavigationTarget.Text = "Open As";
            // 
            // cbNavigationTarget
            // 
            this.cbNavigationTarget.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbNavigationTarget.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNavigationTarget.FormattingEnabled = true;
            this.cbNavigationTarget.Location = new System.Drawing.Point(106, 74);
            this.cbNavigationTarget.Name = "cbNavigationTarget";
            this.cbNavigationTarget.Size = new System.Drawing.Size(682, 28);
            this.cbNavigationTarget.TabIndex = 16;
            // 
            // cbCustomPage
            // 
            this.cbCustomPage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCustomPage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCustomPage.FormattingEnabled = true;
            this.cbCustomPage.Location = new System.Drawing.Point(106, 230);
            this.cbCustomPage.Name = "cbCustomPage";
            this.cbCustomPage.Size = new System.Drawing.Size(682, 28);
            this.cbCustomPage.TabIndex = 19;
            this.cbCustomPage.SelectedIndexChanged += new System.EventHandler(this.cbCustomPage_SelectedIndexChanged);
            // 
            // lblCustomPage
            // 
            this.lblCustomPage.AutoSize = true;
            this.lblCustomPage.Location = new System.Drawing.Point(12, 230);
            this.lblCustomPage.Name = "lblCustomPage";
            this.lblCustomPage.Size = new System.Drawing.Size(46, 20);
            this.lblCustomPage.TabIndex = 18;
            this.lblCustomPage.Text = "Page";
            // 
            // cbDashboard
            // 
            this.cbDashboard.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbDashboard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDashboard.FormattingEnabled = true;
            this.cbDashboard.Location = new System.Drawing.Point(106, 230);
            this.cbDashboard.Name = "cbDashboard";
            this.cbDashboard.Size = new System.Drawing.Size(682, 28);
            this.cbDashboard.TabIndex = 21;
            this.cbDashboard.SelectedIndexChanged += new System.EventHandler(this.cbDashboard_SelectedIndexChanged);
            // 
            // lblDashboard
            // 
            this.lblDashboard.AutoSize = true;
            this.lblDashboard.Location = new System.Drawing.Point(12, 233);
            this.lblDashboard.Name = "lblDashboard";
            this.lblDashboard.Size = new System.Drawing.Size(88, 20);
            this.lblDashboard.TabIndex = 20;
            this.lblDashboard.Text = "Dashboard";
            // 
            // ActionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cbDashboard);
            this.Controls.Add(this.lblDashboard);
            this.Controls.Add(this.cbCustomPage);
            this.Controls.Add(this.lblCustomPage);
            this.Controls.Add(this.lblNavigationTarget);
            this.Controls.Add(this.cbNavigationTarget);
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
            this.Controls.Add(this.btnSaveAction);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.cbActionType);
            this.Controls.Add(this.lblActionText);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ActionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Action";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblActionText;
        private System.Windows.Forms.ComboBox cbActionType;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSaveAction;
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
        private System.Windows.Forms.Label lblNavigationTarget;
        private System.Windows.Forms.ComboBox cbNavigationTarget;
        private System.Windows.Forms.ComboBox cbCustomPage;
        private System.Windows.Forms.Label lblCustomPage;
        private System.Windows.Forms.ComboBox cbDashboard;
        private System.Windows.Forms.Label lblDashboard;
    }
}