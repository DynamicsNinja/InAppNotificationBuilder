using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Fic.XTB.InAppNotificationBuilder.Model;
using Fic.XTB.InAppNotificationBuilder.Proxy;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using XrmToolBox.Extensibility;

namespace Fic.XTB.InAppNotificationBuilder.Forms
{
    public partial class ActionForm : Form
    {
        private readonly InAppNotificationBuilder _inAppNotificationBuilder;
        private NotificationAction _action;

        public ActionForm(InAppNotificationBuilder inAppNotificationBuilder, NotificationAction action)
        {
            _inAppNotificationBuilder = inAppNotificationBuilder;
            _action = action;

            InitializeComponent();
            InitForm();
        }

        #region Events

        private void cbActionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider.SetError(tbUrl, string.Empty);

            var selectedType = (ActionType)cbActionType.SelectedItem;

            tbUrl.Enabled = selectedType == ActionType.Url;
            cbEntity.Visible = selectedType != ActionType.Url;
            lblEntity.Visible = selectedType != ActionType.Url;
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
            lblWebresource.Visible = selectedType == ActionType.Webresource;
            cbWebresource.Visible = selectedType == ActionType.Webresource;
            lblDataParams.Visible = selectedType == ActionType.Webresource;
            dgvDataParams.Visible = selectedType == ActionType.Webresource;

            switch (selectedType)
            {
                case ActionType.CustomPage:
                    GetCustomPages();
                    break;
                case ActionType.Dashboard:
                    GetDashboards();
                    break;
                case ActionType.Webresource:
                    GetHtmlWebresources();
                    break;
            }

            tbUrl.Text = "";
            tbRecordId.Text = selectedType == ActionType.Record ? Guid.Empty.ToString("D") : "";
        }

        private void cbEntity_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedEntity = (EntityMetadataProxy)cbEntity.SelectedItem;

            GetForms(selectedEntity.Entity.LogicalName);
            GetViews(selectedEntity.Entity.LogicalName);

            GenerateUrl();
        }

        private void btnSaveAction_Click(object sender, EventArgs e)
        {
            tbUrl.CausesValidation = true;
            tbActionText.CausesValidation = true;

            var isValid = ValidateChildren();

            if (!isValid) { return; }

            var isNew = _action == null;

            _action = _action ?? new NotificationAction();
            _action.ActionText = tbActionText.Text;
            _action.ActionType = (ActionType)cbActionType.SelectedItem;
            _action.NavigationTarget = ((NavigationTarget)cbNavigationTarget.SelectedItem)?.Value;
            _action.Url = tbUrl.Text;
            _action.EntityName = ((EntityMetadataProxy)cbEntity.SelectedItem)?.Entity.LogicalName;
            _action.FormId = _action.ActionType == ActionType.Record
                ? ((FormProxy)cbForm.SelectedItem)?.Entity.Id.ToString("D")
                : "";
            _action.ViewId = _action.ActionType == ActionType.List
                ? ((ViewProxy)cbView.SelectedItem)?.Entity.Id.ToString("D")
                : "";
            _action.CustomPageName = _action.ActionType == ActionType.CustomPage
                ? ((CustomPageProxy)cbCustomPage.SelectedItem)?.Entity["name"].ToString()
                : "";
            _action.DashboardId = _action.ActionType == ActionType.Dashboard
                ? ((DashboardProxy)cbDashboard.SelectedItem)?.Entity.Id.ToString("D")
                : "";
            _action.WebresourceName = _action.ActionType == ActionType.Webresource
                ? ((WebresourceProxy) cbWebresource.SelectedItem)?.Entity["name"].ToString()
                : "";
            _action.RecordId = tbRecordId.Text;

            _action.WebresourceParams.Clear();

            foreach (DataGridViewRow row in dgvDataParams.Rows)
            {
                var key = row.Cells["Key"].Value?.ToString();
                var value = row.Cells["Value"].Value?.ToString();

                if (key == null && value == null) { continue; }

                _action.WebresourceParams.Add(key, value);
            }

            if (isNew)
            {
                _inAppNotificationBuilder.NotificationActions.Add(_action);
            }

            _inAppNotificationBuilder.ActionsGrid.Refresh();

            Close();
        }

        private void cbWebresource_SelectedIndexChanged(object sender, EventArgs e)
        {
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

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

        private void tbActionText_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var text = tbActionText.Text.Trim();

            if (text == string.Empty)
            {
                errorProvider.SetIconAlignment(tbActionText, ErrorIconAlignment.MiddleLeft);
                errorProvider.SetIconPadding(tbActionText, 5);
                errorProvider.SetError(tbActionText, "Action text should not be empty.");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(tbActionText, "");
            }
        }

        private void dgvDataParams_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            GenerateUrl();
        }

        private void cbNavigationTarget_SelectedIndexChanged(object sender, EventArgs e)
        {
            GenerateUrl();
        }

        #endregion

        #region Methods

        private void InitForm()
        {
            cbActionType.DataSource = Enum.GetValues(typeof(ActionType));
            cbEntity.Items.AddRange(_inAppNotificationBuilder.Entities);
            InitNavigationTargetDropdown();

            Text = _action == null ? "Create Action" : "Update Action";
            btnSaveAction.Text = _action == null ? "Create" : "Update";

            if (_action == null) { return; }

            tbActionText.Text = _action.ActionText;
            cbActionType.SelectedItem = _action.ActionType;

            foreach (NavigationTarget nt in cbNavigationTarget.Items)
            {
                if (nt.Value != _action.NavigationTarget) { continue; }
                cbNavigationTarget.SelectedItem = nt;
                break;
            }

            tbUrl.Text = _action.Url;

            foreach (EntityMetadataProxy emp in cbEntity.Items)
            {
                if (emp.Entity.LogicalName != _action.EntityName) { continue; }
                cbEntity.SelectedItem = emp;
                break;
            }

            foreach (var key in _action.WebresourceParams.Keys)
            {
                var index = dgvDataParams.Rows.Add();
                dgvDataParams.Rows[index].Cells["Key"].Value = key;
                dgvDataParams.Rows[index].Cells["Value"].Value = _action.WebresourceParams[key];
            }

            tbRecordId.Text = _action.RecordId;
        }

        private void InitNavigationTargetDropdown()
        {
            object[] navigationTargets = new List<NavigationTarget>
            {
                new NavigationTarget {DisplayName = "Dialog", Value = "dialog"},
                new NavigationTarget {DisplayName = "Inline", Value = "inline"},
                new NavigationTarget {DisplayName = "New Window", Value = "newWindow"}
            }.ToArray();

            cbNavigationTarget.Items.AddRange(navigationTargets);
            cbNavigationTarget.SelectedIndex = 0;
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

                        foreach (CustomPageProxy cpp in cbCustomPage.Items)
                        {
                            var customPageName = (string)cpp.Entity["name"];
                            if (customPageName != _action?.CustomPageName) { continue; }
                            cbCustomPage.SelectedItem = cpp;
                            break;
                        }
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

                        foreach (DashboardProxy dp in cbDashboard.Items)
                        {
                            var dashboardId = ((Guid)dp.Entity["formid"]).ToString("D");
                            if (dashboardId != _action?.DashboardId) { continue; }
                            cbDashboard.SelectedItem = dp;
                            break;
                        }
                    }

                    cbDashboard.Enabled = true;
                }
            });
        }

        private void GetHtmlWebresources()
        {
            cbWebresource.Enabled = false;

            _inAppNotificationBuilder.WorkAsync(new WorkAsyncInfo("Loading webresources...",
                (eventargs) =>
                {
                    var query = new QueryExpression("webresource");
                    query.ColumnSet.AddColumns("name");
                    query.AddOrder("name", OrderType.Ascending);
                    query.Criteria.AddCondition("webresourcetype", ConditionOperator.Equal, 1);
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
                        var webresources = result.Entities.Select(f => new WebresourceProxy(f)).OrderBy(f => f.ToString()).ToArray();
                        cbWebresource.Items.Clear();
                        cbWebresource.Items.AddRange(webresources);

                        foreach (WebresourceProxy wrp in cbWebresource.Items)
                        {
                            var webresourceName = (string)wrp.Entity["name"];
                            if (webresourceName != _action?.WebresourceName) { continue; }
                            cbWebresource.SelectedItem = wrp;
                            break;
                        }
                    }

                    cbWebresource.Enabled = true;
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


                        foreach (FormProxy fp in cbForm.Items)
                        {
                            if (fp.Entity.Id.ToString("D") != _action?.FormId) { continue; }
                            cbForm.SelectedItem = fp;
                            break;
                        }
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

                        foreach (ViewProxy vp in cbView.Items)
                        {
                            if (vp.Entity.Id.ToString("D") != _action?.ViewId) { continue; }
                            cbView.SelectedItem = vp;
                            break;
                        }
                    }

                    cbView.Enabled = true;
                }
            });
        }

        private void GenerateUrl()
        {
            var selectedType = (ActionType)cbActionType.SelectedItem;
            var navigationTarget = (NavigationTarget)cbNavigationTarget.SelectedItem;

            var baseUrl = navigationTarget.Value == "newWindow" ? _inAppNotificationBuilder.appBaseUrl : "";

            EntityMetadataProxy selectedEntity;
            switch (selectedType)
            {
                case ActionType.Record:
                    if (cbEntity.SelectedItem == null) { return; }

                    if (cbForm.SelectedItem == null) { return; }

                    selectedEntity = (EntityMetadataProxy)cbEntity.SelectedItem;

                    var selectedForm = (FormProxy)cbForm.SelectedItem;
                    var recordId = tbRecordId.Text == "" ? Guid.Empty.ToString("D") : tbRecordId.Text;

                    tbUrl.Text = $@"{baseUrl}?pagetype=entityrecord&etn={selectedEntity.Entity.LogicalName}&id={recordId}&formid={selectedForm.Entity.Id:D}";
                    break;
                case ActionType.List:
                    if (cbEntity.SelectedItem == null) { return; }

                    if (cbView.SelectedItem == null) { return; }

                    selectedEntity = (EntityMetadataProxy)cbEntity.SelectedItem;


                    var selectedView = (ViewProxy)cbView.SelectedItem;

                    tbUrl.Text = $@"{baseUrl}?pagetype=entitylist&etn={selectedEntity.Entity.LogicalName}&viewid={selectedView.Entity.Id:D}";
                    break;
                case ActionType.CustomPage:
                    if (cbCustomPage.SelectedItem == null) { return; }

                    var selectedPage = (CustomPageProxy)cbCustomPage.SelectedItem;
                    var pageName = (string)selectedPage.Entity["name"];

                    tbUrl.Text = $@"{baseUrl}?pagetype=custom&name={pageName}";
                    break;
                case ActionType.Dashboard:
                    if (cbDashboard.SelectedItem == null) { return; }

                    var selectedDashboard = (DashboardProxy)cbDashboard.SelectedItem;

                    tbUrl.Text = $@"{baseUrl}?pagetype=dashboard&id={selectedDashboard.Entity.Id:D}";
                    break;
                case ActionType.Webresource:
                    if (cbWebresource.SelectedItem == null) { return; }

                    var selectedWebresource = (WebresourceProxy)cbWebresource.SelectedItem;
                    var webresourceName = (string)selectedWebresource.Entity["name"];

                    var dataParamsList = new List<string>();

                    foreach (DataGridViewRow row in dgvDataParams.Rows)
                    {
                        var key = row.Cells["Key"].Value;
                        var value = row.Cells["Value"].Value;

                        if (key == null && value == null) { continue; }

                        dataParamsList.Add($"{key}={value}");
                    }

                    var dataParams = dataParamsList.Count != 0
                        ? $"&data={string.Join("&", dataParamsList)}"
                        : string.Empty;

                    tbUrl.Text = $@"{baseUrl}?pagetype=webresource&webresourceName={webresourceName}{dataParams}";
                    break;
            }
        }

        #endregion
    }
}
