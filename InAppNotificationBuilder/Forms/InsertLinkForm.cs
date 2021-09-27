using System;
using System.Linq;
using System.Windows.Forms;
using Fic.XTB.InAppNotificationBuilder.Model;
using Fic.XTB.InAppNotificationBuilder.Proxy;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using XrmToolBox.Extensibility;

namespace Fic.XTB.InAppNotificationBuilder.Forms
{
    public partial class InsertLinkForm : Form
    {
        private readonly InAppNotificationBuilder _inAppNotificationBuilder;

        public InsertLinkForm(InAppNotificationBuilder inAppNotificationBuilder)
        {
            _inAppNotificationBuilder = inAppNotificationBuilder;

            InitializeComponent();
            InitForm();
        }

        #region Events

        private void cbActionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider.SetError(tbUrl, string.Empty);

            var selectedType = (ActionType)cbActionType.SelectedItem;

            tbUrl.Enabled = selectedType == ActionType.Url;
            cbEntity.Visible = selectedType == ActionType.Record || selectedType == ActionType.List;
            lblEntity.Visible = selectedType == ActionType.Record || selectedType == ActionType.List;
            cbForm.Visible = selectedType == ActionType.Record;
            lblForm.Visible = selectedType == ActionType.Record;
            cbView.Visible = selectedType == ActionType.List;
            lblView.Visible = selectedType == ActionType.List;
            tbRecordId.Visible = selectedType == ActionType.Record;
            lblRecordId.Visible = selectedType == ActionType.Record;
            cbCustomPage.Visible = selectedType == ActionType.CustomPage;
            lblCustomPage.Visible = selectedType == ActionType.CustomPage;
            lblDashboard.Visible = selectedType == ActionType.Dashboard;
            cbDashboard.Visible = selectedType == ActionType.Dashboard;

            switch (selectedType)
            {
                case ActionType.CustomPage:
                    GetCustomPages();
                    break;
                case ActionType.Dashboard:
                    GetDashboards();
                    break;
            }

            tbUrl.Text = string.Empty;
            tbRecordId.Text = selectedType == ActionType.Record ? Guid.Empty.ToString("D") : "";
        }

        private void cbEntity_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedEntity = (EntityMetadataProxy)cbEntity.SelectedItem;

            GetForms(selectedEntity.Entity.LogicalName);
            GetViews(selectedEntity.Entity.LogicalName);

            GenerateUrl();
        }

        private void cbView_SelectedIndexChanged(object sender, EventArgs e)
        {
            GenerateUrl();
        }

        private void tbRecordId_TextChanged(object sender, EventArgs e)
        {
            GenerateUrl();
        }

        private void cbForm_SelectedIndexChanged(object sender, EventArgs e)
        {
            GenerateUrl();
        }

        private void cbCustomPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            GenerateUrl();
        }

        private void cbDashboard_SelectedIndexChanged(object sender, EventArgs e)
        {
            GenerateUrl();
        }

        private void btnSaveAction_Click(object sender, EventArgs e)
        {
            tbUrl.CausesValidation = true;

            var isValid = ValidateChildren();

            if (!isValid) { return; }

            var url = tbUrl.Text;
            var linkText = tbActionText.Text;

            _inAppNotificationBuilder.InsertLink(linkText, url);

            Close();
        }

        #endregion

        #region Methods

        private void InitForm()
        {
            cbActionType.DataSource = Enum.GetValues(typeof(ActionType));
            cbEntity.Items.AddRange(_inAppNotificationBuilder.Entities);
        }

        private void GetCustomPages()
        {
            cbCustomPage.Enabled = false;

            _inAppNotificationBuilder.WorkAsync(new WorkAsyncInfo("Loading custom pages...",
                (eventargs) =>
                {
                    var query = new QueryExpression("canvasapp");
                    query.ColumnSet.AddColumns("displayname", "name");
                    query.AddOrder("displayname", OrderType.Ascending);
                    query.Criteria.AddCondition("canvasapptype", ConditionOperator.Equal, 2);

                    eventargs.Result = _inAppNotificationBuilder.Service.RetrieveMultiple(query);
                })
            {
                PostWorkCallBack = (completedargs) =>
                {
                    if (completedargs.Error != null)
                    {
                        MessageBox.Show(completedargs.Error.Message);
                    }
                    else
                    {
                        if (!(completedargs.Result is EntityCollection)) { return; }

                        var result = (EntityCollection)completedargs.Result;
                        var customPages = result.Entities.Select(f => new CustomPageProxy(f)).OrderBy(f => f.ToString()).ToArray();
                        cbCustomPage.Items.Clear();
                        cbCustomPage.Items.AddRange(customPages);
                    }

                    cbCustomPage.Enabled = true;
                }
            });
        }

        private void GetDashboards()
        {
            cbDashboard.Enabled = false;

            _inAppNotificationBuilder.WorkAsync(new WorkAsyncInfo("Loading dashboards...",
                (eventargs) =>
                {
                    var query = new QueryExpression("systemform");
                    query.ColumnSet.AddColumns("name", "formid");
                    query.AddOrder("name", OrderType.Ascending);
                    query.Criteria.AddCondition("type", ConditionOperator.In, 0, 10, 13);
                    eventargs.Result = _inAppNotificationBuilder.Service.RetrieveMultiple(query);
                })
            {
                PostWorkCallBack = (completedargs) =>
                {
                    if (completedargs.Error != null)
                    {
                        MessageBox.Show(completedargs.Error.Message);
                    }
                    else
                    {
                        if (!(completedargs.Result is EntityCollection)) { return; }

                        var result = (EntityCollection)completedargs.Result;
                        var dashboards = result.Entities.Select(f => new DashboardProxy(f)).OrderBy(f => f.ToString()).ToArray();
                        cbDashboard.Items.Clear();
                        cbDashboard.Items.AddRange(dashboards);
                    }

                    cbDashboard.Enabled = true;
                }
            });
        }

        private void GetForms(string entityName)
        {
            cbForm.Enabled = false;

            _inAppNotificationBuilder.WorkAsync(new WorkAsyncInfo("Loading forms...",
                (eventargs) =>
                {
                    var qx = new QueryExpression("systemform");
                    qx.ColumnSet = new ColumnSet("name");
                    qx.Criteria.AddCondition("objecttypecode", ConditionOperator.Equal, entityName);
                    qx.Criteria.AddCondition("type", ConditionOperator.Equal, 2);
                    eventargs.Result = _inAppNotificationBuilder.Service.RetrieveMultiple(qx);
                })
            {
                PostWorkCallBack = (completedargs) =>
                {
                    if (completedargs.Error != null)
                    {
                        MessageBox.Show(completedargs.Error.Message);
                    }
                    else
                    {
                        if (!(completedargs.Result is EntityCollection)) { return; }

                        var result = (EntityCollection)completedargs.Result;
                        var forms = result.Entities.Select(f => new FormProxy(f)).OrderBy(f => f.ToString()).ToArray();
                        cbForm.Items.Clear();
                        cbForm.Items.AddRange(forms);
                    }

                    cbForm.Enabled = true;
                }
            });
        }

        private void GetViews(string entityName)
        {
            cbView.Enabled = false;

            _inAppNotificationBuilder.WorkAsync(new WorkAsyncInfo("Loading views...",
                (eventargs) =>
                {
                    var query = new QueryExpression("savedquery");
                    query.ColumnSet.AddColumns("name");
                    query.AddOrder("name", OrderType.Ascending);
                    query.Criteria.AddCondition("returnedtypecode", ConditionOperator.Equal, entityName);
                    query.Criteria.AddCondition("querytype", ConditionOperator.Equal, 0);

                    eventargs.Result = _inAppNotificationBuilder.Service.RetrieveMultiple(query);
                })
            {
                PostWorkCallBack = (completedargs) =>
                {
                    if (completedargs.Error != null)
                    {
                        MessageBox.Show(completedargs.Error.Message);
                    }
                    else
                    {
                        if (!(completedargs.Result is EntityCollection)) { return; }

                        var result = (EntityCollection)completedargs.Result;
                        var views = result.Entities.Select(f => new ViewProxy(f)).OrderBy(f => f.ToString()).ToArray();
                        cbView.Items.Clear();
                        cbView.Items.AddRange(views);
                    }

                    cbView.Enabled = true;
                }
            });
        }

        private void GenerateUrl()
        {
            var selectedType = (ActionType)cbActionType.SelectedItem;


            EntityMetadataProxy selectedEntity;
            switch (selectedType)
            {
                case ActionType.Record:
                    if (cbForm.SelectedItem == null) { return; }

                    if (cbEntity.SelectedItem == null) { return; }

                    selectedEntity = (EntityMetadataProxy)cbEntity.SelectedItem;
                    var selectedForm = (FormProxy)cbForm.SelectedItem;
                    var recordId = tbRecordId.Text == "" ? Guid.Empty.ToString("D") : tbRecordId.Text;

                    tbUrl.Text = $@"?pagetype=entityrecord&etn={selectedEntity.Entity.LogicalName}&id={recordId}&formid={selectedForm.Entity.Id:D}";
                    break;
                case ActionType.List:
                    if (cbView.SelectedItem == null) { return; }

                    if (cbEntity.SelectedItem == null) { return; }

                    selectedEntity = (EntityMetadataProxy)cbEntity.SelectedItem;
                    var selectedView = (ViewProxy)cbView.SelectedItem;

                    tbUrl.Text = $@"?pagetype=entitylist&etn={selectedEntity.Entity.LogicalName}&viewid={selectedView.Entity.Id:D}";
                    break;
                case ActionType.CustomPage:
                    if (cbCustomPage.SelectedItem == null) { return; }

                    var selectedPage = (CustomPageProxy)cbCustomPage.SelectedItem;
                    var pageName = (string)selectedPage.Entity["name"];

                    tbUrl.Text = $@"?pagetype=custom&name={pageName}";
                    break;
                case ActionType.Dashboard:
                    if (cbDashboard.SelectedItem == null) { return; }

                    var selectedDashboard = (DashboardProxy)cbDashboard.SelectedItem;

                    tbUrl.Text = $@"?pagetype=dashboard&id={selectedDashboard.Entity.Id:D}";
                    break;
            }
        }

        #endregion

        private void tbUrl_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var selectedType = (ActionType)cbActionType.SelectedItem;

            var url = tbUrl.Text;

            var isValidUrl = selectedType == ActionType.Url
                ? Uri.TryCreate(url, UriKind.Absolute, out var uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps)
                : !string.IsNullOrWhiteSpace(url);

            if (!isValidUrl)
            {
                errorProvider.SetIconAlignment(tbUrl, ErrorIconAlignment.MiddleLeft);
                errorProvider.SetIconPadding(tbUrl, 5);
                errorProvider.SetError(tbUrl, "Please enter valid URL.");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(tbUrl, "");
            }
        }
    }
}
