using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Fic.XTB.InAppNotificationBuilder.Forms;
using Fic.XTB.InAppNotificationBuilder.Helper;
using Fic.XTB.InAppNotificationBuilder.Model;
using Fic.XTB.InAppNotificationBuilder.Proxy;
using McTools.Xrm.Connection;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Rest.Serialization;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Query;
using Newtonsoft.Json;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;


namespace Fic.XTB.InAppNotificationBuilder
{
    public partial class InAppNotificationBuilder : PluginControlBase, IGitHubPlugin, IPayPalPlugin
    {
        public string RepositoryName => "InAppNotificationBuilder";
        public string UserName => "DynamicsNinja";
        public string DonationDescription => "Thanks for supporting In-App Notification Builder";
        public string EmailAccount => "ivan.ficko@outlook.com";

        private Settings _settings;
        private Notification _notification;

        public List<Entity> Users;
        public List<Entity> Images;
        public BindingList<NotificationAction> NotificationActions;

        public object[] Entities;

        public ComboBox CbCustomIcon;
        public DataGridView ActionsGrid;
        private SendTestNotificationForm _testForm;
        private ActionForm _actionForm;
        private ImageListForm _imageListForm;

        public string appBaseUrl;

        public InAppNotificationBuilder()
        {
            InitializeComponent();

            CbCustomIcon = cbCustomIcon;
            _notification = new Notification();
            ActionsGrid = dgvActions;

            NotificationActions = new BindingList<NotificationAction>();
            dgvActions.DataSource = NotificationActions;

            cbToastType.DataSource = Enum.GetValues(typeof(ToastType));
            cbExpiresIn.DataSource = Enum.GetValues(typeof(TimeUnit));
            cbExpiresIn.SelectedIndex = cbExpiresIn.Items.Count - 1;

            InitIconDropdown();

            tbTitle.Text = "New Lead Created";
            tbBody.Text = "John has created a new lead record";
        }

        #region Events

        private void MyPluginControl_Load(object sender, EventArgs e)
        {
            if (!SettingsManager.Instance.TryLoad(GetType(), out _settings))
            {
                _settings = new Settings();

                LogWarning("Settings not found => a new settings file has been created!");
            }
            else
            {
                LogInfo("Settings found and loaded");
            }
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            CloseTool();
        }

        private void MyPluginControl_OnCloseTool(object sender, EventArgs e)
        {
            SettingsManager.Instance.Save(GetType(), _settings);
        }

        public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter)
        {
            base.UpdateConnection(newService, detail, actionName, parameter);

            if (detail == null) { return; }

            appBaseUrl = $"{detail.WebApplicationUrl}main.aspx";

            ChangeUiState(false);

            ExecuteMethod(GetApps);
            ExecuteMethod(GetUsers);
            ExecuteMethod(GetEntities);
            ExecuteMethod(GetImages);
        }

        private void tbTitle_TextChanged(object sender, EventArgs e)
        {
            _notification.Title = tbTitle.Text;
            RenderNotifcation();
        }

        private void tbBody_TextChanged(object sender, EventArgs e)
        {
            _notification.Body = tbBody.Text;
            RenderNotifcation();
        }

        private void cbIcon_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedIcon = (NotificationIcon)cbIcon.SelectedItem;
            _notification.Icon = selectedIcon;

            lblCustomIcon.Visible = selectedIcon.Value == 100000005;
            cbCustomIcon.Visible = selectedIcon.Value == 100000005;
            btnBrowseImages.Visible = selectedIcon.Value == 100000005;

            cbCustomIcon.SelectedItem = null;

            RenderNotifcation();
        }

        private void tscbApp_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedApp = ((AppProxy)tscbApp.SelectedItem);

            tsbDisabled.Visible = !selectedApp.NotificationsEnabled;
            tsbEnabled.Visible = selectedApp.NotificationsEnabled;
        }

        private void tsbSendTest_Click(object sender, EventArgs e)
        {
            _testForm = _testForm ?? new SendTestNotificationForm(this);

            _testForm.ShowDialog();
        }

        private void tsbEnabled_Click(object sender, EventArgs e)
        {
            OpenUpdateSettingsDialog(false);
        }

        private void tsbDisabled_Click(object sender, EventArgs e)
        {
            OpenUpdateSettingsDialog(true);
        }

        private void dgvActions_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var action = (NotificationAction)dgvActions.CurrentRow?.DataBoundItem;

            OpenActionDialog(action);
        }

        private void btnEditAction_Click(object sender, EventArgs e)
        {
            var action = (NotificationAction)dgvActions.CurrentRow?.DataBoundItem;

            if (action == null) { return; }

            OpenActionDialog(action);
        }

        private void btnDeleteAction_Click(object sender, EventArgs e)
        {
            var action = (NotificationAction)dgvActions.CurrentRow?.DataBoundItem;

            if (action == null) { return; }

            var confirmResult = MessageBox.Show(
                $@"Are you sure you want to delete this action?",
                $@"Delete action",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirmResult != DialogResult.Yes) { return; }

            NotificationActions.Remove(action);
            RenderNotifcation();
        }

        private void btnCSharp_Click(object sender, EventArgs e)
        {
            var code = GenerateCSharpCode();

            var codeForm = new CodeForm(code);
            codeForm.ShowDialog();
        }

        private void btnAddAction_Click(object sender, EventArgs e)
        {
            OpenActionDialog(null);
        }

        private void btnJs_Click(object sender, EventArgs e)
        {
            var code = GenerateJsCode();

            var codeForm = new CodeForm(code);
            codeForm.ShowDialog();
        }

        private void btnPowerAutomate_Click(object sender, EventArgs e)
        {
            var req = GenerateNotificationCreateRequest();

            var powerAutomateForm = new PowerAutomateForm(req);
            powerAutomateForm.ShowDialog();
        }

        private void btnGetCode_ButtonClick(object sender, EventArgs e)
        {
            btnGetCode.ShowDropDown();
        }

        private void btnInsertLink_Click(object sender, EventArgs e)
        {
            var insertLinkForm = new InsertLinkForm(this);

            insertLinkForm.ShowDialog();
        }

        private void btnBold_Click(object sender, EventArgs e)
        {
            if (tbBody.SelectedText == "") { return; }

            var insertText = "**";
            var start = tbBody.SelectionStart;
            var end = tbBody.SelectionStart + tbBody.SelectionLength + insertText.Length;

            tbBody.Text = tbBody.Text.Insert(start, insertText);
            tbBody.Text = tbBody.Text.Insert(end, insertText);

            tbBody.SelectionStart = start + insertText.Length;
        }

        private void btnItalic_Click(object sender, EventArgs e)
        {
            if (tbBody.SelectedText == "") { return; }

            var insertText = "*";
            var start = tbBody.SelectionStart;
            var end = tbBody.SelectionStart + tbBody.SelectionLength + insertText.Length;

            tbBody.Text = tbBody.Text.Insert(start, insertText);
            tbBody.Text = tbBody.Text.Insert(end, insertText);

            tbBody.SelectionStart = start + insertText.Length;
        }

        private void btnInsertImage_Click(object sender, EventArgs e)
        {
            var insertImageForm = new InsertImageForm(this);

            insertImageForm.ShowDialog();
        }

        private void cbCustomIcon_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedImage = (WebresourceProxy)cbCustomIcon.SelectedItem;

            if (selectedImage == null) { return; }

            var webresourceType = ((OptionSetValue)selectedImage.Entity["webresourcetype"]).Value;
            var mimeType = webresourceType == 11 ? "image/svg+xml" : "image/png";
            var content = (string)selectedImage.Entity["content"];
            _notification.Icon.Image = $"data:{mimeType};base64,{content}";

            RenderNotifcation();
        }

        private void btnH1_Click(object sender, EventArgs e)
        {
            if (tbBody.SelectedText == "") { return; }

            var insertText = "# ";
            var start = tbBody.SelectionStart;

            tbBody.Text = tbBody.Text.Insert(start, insertText);
            tbBody.SelectionStart = start + insertText.Length;
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            var index = dgvActions.CurrentRow?.Index;

            if (index == null || index == 0) { return; }

            SwapRows(NotificationActions, (int)index, (int)index - 1);

            SetSelectedActionRow((int)index - 1);

            RenderNotifcation();
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            var index = dgvActions.CurrentRow?.Index;

            if (index == null || index == NotificationActions.Count - 1) { return; }

            SwapRows(NotificationActions, (int)index, (int)index + 1);

            SetSelectedActionRow((int)index + 1);

            RenderNotifcation();
        }

        private void btnBrowseImages_Click(object sender, EventArgs e)
        {
            btnBrowseImages.Enabled = false;

            if (_imageListForm == null)
            {
                WorkAsync(
                    new WorkAsyncInfo("Loading image dialog...",
                        (eventargs) =>
                        {
                            _imageListForm = new ImageListForm(this);
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
                                _imageListForm.ShowDialog();
                            }

                            btnBrowseImages.Enabled = true;
                        }
                    });
            }
            else
            {
                _imageListForm.ShowDialog();
                btnBrowseImages.Enabled = true;
            }
        }

        #endregion

        #region Methods

        private string GetBase64Image(Bitmap bmp)
        {
            var ms = new MemoryStream();
            bmp.Save(ms, ImageFormat.Png);
            var byteImage = ms.ToArray();
            var base64String = Convert.ToBase64String(byteImage);

            return $"data:image/png;base64,{base64String}";
        }

        private void InitIconDropdown()
        {
            var icons = new List<NotificationIcon>
            {
                new NotificationIcon
                {
                    Name = "Info",
                    Image = GetBase64Image(Properties.Resources.Info),
                    Value = 100000000
                },
                new NotificationIcon
                {
                    Name = "Success",
                    Image = GetBase64Image(Properties.Resources.Success),
                    Value = 100000001
                },
                new NotificationIcon
                {
                    Name = "Failure",
                    Image = GetBase64Image(Properties.Resources.Failure),
                    Value = 100000002
                },
                new NotificationIcon
                {
                    Name = "Warning",
                    Image = GetBase64Image(Properties.Resources.Warning),
                    Value = 100000003
                },
                new NotificationIcon
                {
                    Name = "Mention",
                    Image = GetBase64Image(Properties.Resources.Mention),
                    Value = 100000004
                },
                new NotificationIcon
                {
                    Name = "Custom",
                    Image = GetBase64Image(Properties.Resources.Mention),
                    Value = 100000005
                }
            };

            foreach (var icon in icons)
            {
                cbIcon.Items.Add(icon);
            }

            cbIcon.SelectedIndex = 0;
        }

        public void RenderNotifcation()
        {

            var html = Properties.Resources.notification;

            if (_notification.Title == null || _notification.Body == null || _notification.Icon == null)
            {
                return;
            }

            var actionsHtml = GenerateActionsHtml();

            var htmlBody = Markdig.Markdown.ToHtml(tbBody.Text);

            html = html
                .Replace("NOTIFICATION_TITLE", _notification.Title)
                .Replace("NOTIFICATION_BODY", htmlBody)
                .Replace("NOTIFICATION_ICON", _notification.Icon.Image)
                .Replace("NOTIFICATION_ACTIONS", actionsHtml);

            if (html == wbPreview.DocumentText) { return; }

            wbPreview.DocumentText = html;
        }

        private string GenerateActionsHtml()
        {
            var actionsHtml = "";

            foreach (DataGridViewRow row in dgvActions.Rows)
            {
                var action = (NotificationAction)row.DataBoundItem;

                actionsHtml += $@"<div class='action'>{action.ActionText}</div>";
            }

            var actionsContainer = $@"<div class='body-actions'>{actionsHtml}</div>";

            return dgvActions.Rows.Count == 0 ? "" : actionsContainer;
        }

        private void GetNotificationSettings()
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Getting notification settings",
                Work = (worker, args) =>
                {

                    var settingsKey = "AllowNotificationsEarlyAccess";
                    var qe = new QueryExpression("appsetting");
                    qe.ColumnSet.AddColumns("value", "parentappmoduleid");
                    var qeLink = qe.AddLink("settingdefinition", "settingdefinitionid", "settingdefinitionid");
                    qeLink.LinkCriteria.AddCondition("uniquename", ConditionOperator.Equal, settingsKey);

                    args.Result = Service.RetrieveMultiple(qe);
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (!(args.Result is EntityCollection result)) { return; }

                        foreach (AppProxy appProxy in tscbApp.Items)
                        {
                            var settingsExists = result.Entities.Any(s =>
                                ((EntityReference)s["parentappmoduleid"]).Id == appProxy.Entity.Id &&
                                (string)s["value"] == "true");

                            appProxy.NotificationsEnabled = settingsExists;
                        }

                        tscbApp.SelectedIndex = 0;
                    }
                }
            });
        }

        private void GetApps()
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Getting apps",
                Work = (worker, args) =>
                {
                    var qe = new QueryExpression("appmodule")
                    {
                        ColumnSet = new ColumnSet(true),
                        Orders = { new OrderExpression("name", OrderType.Ascending) }
                    };

                    args.Result = Service.RetrieveMultiple(qe);
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (!(args.Result is EntityCollection result)) { return; }

                        var apps = result.Entities.Select(a => new AppProxy(a)).OrderBy(a => a.ToString()).ToArray();

                        tscbApp.Items.Clear();
                        tscbApp.Items.AddRange(apps);

                        GetNotificationSettings();
                    }
                }
            });
        }

        private void GetUsers()
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Getting users",
                Work = (worker, args) =>
                {
                    var qe = new QueryExpression("systemuser")
                    {
                        ColumnSet = new ColumnSet(true),
                        Orders = { new OrderExpression("fullname", OrderType.Ascending) }
                    };

                    args.Result = RetrieveAllRecords(Service, qe);
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (!(args.Result is List<Entity> result)) { return; }

                        Users = result;
                    }
                }
            });
        }

        private void ChangeUiState(bool isEnabled)
        {
            toolStripMenu.Enabled = isEnabled;
            gbActions.Enabled = isEnabled;
            gbData.Enabled = isEnabled;
            gbPreview.Enabled = isEnabled;
        }

        private string GetBodyAsMarkdown()
        {
            return tbBody.Text;
        }

        private int CalculateExpirationTime()
        {
            var selectedUnit = (int)cbExpiresIn.SelectedItem;
            var expiresIn = int.Parse(tbExpiresIn.Text);

            var total = selectedUnit * expiresIn;

            return total;
        }

        public NotificationCreateRequest GenerateNotificationCreateRequest()
        {
            var notificationRequest = new NotificationCreateRequest();
            notificationRequest.Title = tbTitle.Text;
            notificationRequest.Body = GetBodyAsMarkdown();
            notificationRequest.Ownerid = Guid.Empty.ToString("D");
            notificationRequest.Icontype = _notification.Icon;
            notificationRequest.ToastType = (ToastType)cbToastType.SelectedItem;
            notificationRequest.Data = GenerateNotificationDataJson();
            notificationRequest.TtlInSeconds = CalculateExpirationTime();

            return notificationRequest;
        }

        public void SendTestNotification(Guid userId)
        {
            _testForm.Close();

            var notificationRequest = GenerateNotificationCreateRequest();

            WorkAsync(new WorkAsyncInfo
            {

                Message = "Sending notification",
                Work = (worker, args) =>
                {
                    var newNotifcation = new Entity("appnotification")
                    {
                        ["title"] = notificationRequest.Title,
                        ["body"] = notificationRequest.Body,
                        ["ownerid"] = new EntityReference("systemuser", userId),
                        ["icontype"] = new OptionSetValue(notificationRequest.Icontype.Value),
                        ["toasttype"] = new OptionSetValue((int)notificationRequest.ToastType),
                        ["ttlinseconds"] = notificationRequest.TtlInSeconds,
                        ["data"] = notificationRequest.Data
                    };

                    args.Result = Service.Create(newNotifcation);
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (!(args.Result is Guid result)) { return; }
                    }
                }
            });
        }

        private string GenerateNotificationDataJson()
        {
            var notificationData = new NotificationData();

            if (dgvActions.Rows.Count == 0 && cbCustomIcon.SelectedItem == null) { return ""; }

            foreach (DataGridViewRow row in dgvActions.Rows)
            {
                var action = (NotificationAction)row.DataBoundItem;

                notificationData.Actions.Add(new NotificationActionJson
                {
                    Title = action.ActionText,
                    Data = new NotificationActionDataJson
                    {
                        Url = action.Url,
                        NavigationTarget = action.NavigationTarget
                    }
                });
            }

            var selectedImage = (WebresourceProxy)cbCustomIcon.SelectedItem;

            if (selectedImage != null)
            {
                var imageName = (string)selectedImage.Entity["name"];
                notificationData.IconUrl = $"/WebResources/{imageName}";
            }

            var json = JsonConvert.SerializeObject(notificationData, Formatting.Indented);

            return json;
        }

        private void OpenUpdateSettingsDialog(bool enable)
        {
            var confirmResult = MessageBox.Show(
                $@"Are you sure you want to {(enable ? "enable" : "disable")} in-app notifications for this app?",
                $@"Confirm {(enable ? "enable" : "disable")}",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Exclamation
            );

            if (confirmResult != DialogResult.Yes) { return; }

            UpdateInAppSettings(enable);
        }

        public void UpdateInAppSettings(bool enabled)
        {
            var selectedAppProxy = (AppProxy)tscbApp.SelectedItem;

            WorkAsync(new WorkAsyncInfo
            {
                Message = $"{(enabled ? "Enabling" : "Disabling")} in-app notifications",
                Work = (worker, args) =>
                {
                    var settingsKey = "AllowNotificationsEarlyAccess";

                    var query = new QueryExpression("settingdefinition");
                    query.ColumnSet.AddColumns("settingdefinitionid");
                    query.ColumnSet.AllColumns = true;
                    query.Criteria.AddCondition("uniquename", ConditionOperator.Equal, settingsKey);

                    var settingsDefinition = Service.RetrieveMultiple(query).Entities.FirstOrDefault();

                    var qe = new QueryExpression("appsetting");
                    qe.ColumnSet.AddColumns("value", "parentappmoduleid");
                    qe.Criteria.AddCondition("parentappmoduleid", ConditionOperator.Equal, selectedAppProxy.Entity.Id);
                    var qeLink = qe.AddLink("settingdefinition", "settingdefinitionid", "settingdefinitionid");
                    qeLink.LinkCriteria.AddCondition("uniquename", ConditionOperator.Equal, settingsKey);

                    var notificationSettings = Service.RetrieveMultiple(qe).Entities.FirstOrDefault();

                    var newSettings = new Entity("appsetting");
                    newSettings["value"] = enabled ? "true" : "false";

                    if (notificationSettings != null)
                    {
                        newSettings.Id = notificationSettings.Id;
                        Service.Update(newSettings);
                    }
                    else
                    {
                        newSettings["settingdefinitionid"] = settingsDefinition?.ToEntityReference();
                        newSettings["parentappmoduleid"] = selectedAppProxy.Entity.ToEntityReference();
                        newSettings.Id = Service.Create(newSettings);
                    }

                    var publishRequest = new PublishAllXmlRequest();
                    Service.Execute(publishRequest);

                    args.Result = true;
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (!(args.Result is bool result)) { return; }

                        tsbEnabled.Visible = enabled;
                        tsbDisabled.Visible = !enabled;

                        selectedAppProxy.NotificationsEnabled = enabled;
                    }
                }
            });
        }

        private void GetImages()
        {
            WorkAsync(
                new WorkAsyncInfo("Loading images...",
                    (eventargs) =>
                    {

                        var query = new QueryExpression("webresource");
                        query.ColumnSet.AddColumns("name", "displayname", "content", "webresourcetype");
                        var fe = new FilterExpression();
                        query.Criteria.AddFilter(fe);
                        fe.FilterOperator = LogicalOperator.Or;
                        fe.AddCondition("webresourcetype", ConditionOperator.Equal, 5);
                        fe.AddCondition("webresourcetype", ConditionOperator.Equal, 11);

                        var imagesList = RetrieveAllRecords(Service, query);

                        this.Images = imagesList;
                        eventargs.Result = imagesList;
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
                            if (!(completedargs.Result is List<Entity> result)) { return; }

                            var images = result.Select(f => new WebresourceProxy(f)).OrderBy(f => f.ToString()).ToArray();

                            cbCustomIcon.Items.Clear();
                            cbCustomIcon.Items.AddRange(images);

                            ChangeUiState(true);
                        }
                    }
                });
        }

        private void GetEntities()
        {
            WorkAsync(
                new WorkAsyncInfo("Loading entities...",
                    (eventargs) =>
                    {
                        eventargs.Result = MetadataHelper.LoadEntities(Service);
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
                            if (!(completedargs.Result is RetrieveMetadataChangesResponse result)) { return; }

                            var entites = result.EntityMetadata.Select(f => new EntityMetadataProxy(f)).OrderBy(f => f.ToString()).ToArray();

                            Entities = entites;
                        }
                    }
                });
        }

        private void OpenActionDialog(NotificationAction action)
        {
            _actionForm = new ActionForm(this, action);
            _actionForm.ShowDialog();
            RenderNotifcation();
        }

        private string GenerateJsCode()
        {
            var req = GenerateNotificationCreateRequest();

            var code = $@"
var systemuserid = '<user-guid>';
{(req.Data != "" ? $"var data = {req.Data};" : "DELETED_LINE")}
var notificationRecord = 
{{
    'title': '{req.Title}',
    'body': `{req.Body}`,
    'ownerid@odata.bind': '/systemusers(' + systemuserid + ')',
    'icontype': {req.Icontype.Value}, // {req.Icontype.Name}
    'toasttype': {(int)req.ToastType}, // {Enum.GetName(typeof(ToastType), req.ToastType)}
    'ttlinseconds': {req.TtlInSeconds},
    {(req.Data == "" ? "DELETED_LINE" : "'data': JSON.stringify(data)")}
}}
Xrm.WebApi.createRecord('appnotification', notificationRecord).
  then(
      function success(result) {{
          console.log('notification created with single action: ' + result.id);
      }},
      function (error) {{
          console.log(error.message);
          // handle error conditions
      }}
  );".Trim();

            code = CleanUpCode(code);

            return code;
        }

        private string GenerateCSharpCode()
        {
            var req = GenerateNotificationCreateRequest();

            var escapedDataJson = req.Data.Replace("\"", "\"\"");

            var code = $@"
var notification = new Entity(""appnotification"")
{{
    [""title""] = @""{req.Title}"",
    [""body""] = @""{req.Body}"",
    [""ownerid""] = new EntityReference(""systemuser"", new Guid(""{req.Ownerid}"")),
    [""icontype""] = new OptionSetValue({req.Icontype.Value}), // {req.Icontype.Name}
    [""toasttype""] = new OptionSetValue({(int)req.ToastType}), // {Enum.GetName(typeof(ToastType), req.ToastType)}
    [""ttlinseconds""] = {req.TtlInSeconds},
    {(req.Data == "" ? "DELETED_LINE" : $@"[""data""] = @""{escapedDataJson}""")}
}};

service.Create(notification);".Trim();

            code = CleanUpCode(code);

            return code;
        }

        private string CleanUpCode(string code)
        {
            var cleanCode = "";

            using (var reader = new StringReader(code))
            {
                for (var line = reader.ReadLine(); line != null; line = reader.ReadLine())
                {
                    if (line.Contains("DELETED_LINE")) { continue; }

                    cleanCode = cleanCode + line + Environment.NewLine;
                }
            }

            return cleanCode;
        }

        public void InsertImage(string altText, string url)
        {
            var insertText = $"![{altText}]({url})";
            var selectionIndex = tbBody.SelectionStart;
            tbBody.Text = tbBody.Text.Insert(selectionIndex, insertText);
            tbBody.SelectionStart = selectionIndex + insertText.Length;
        }

        public void InsertLink(string altText, string url)
        {
            var insertText = $"[{altText}]({url})";
            var selectionIndex = tbBody.SelectionStart;
            tbBody.Text = tbBody.Text.Insert(selectionIndex, insertText);
            tbBody.SelectionStart = selectionIndex + insertText.Length;
        }

        public static void SwapRows<T>(IList<T> list, int indexA, int indexB)
        {
            var tmp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = tmp;
        }

        private void SetSelectedActionRow(int index)
        {
            foreach (DataGridViewRow row in dgvActions.Rows)
            {
                if (row.Index == index)
                {
                    dgvActions.CurrentCell = dgvActions.Rows[index].Cells[0];
                }
            }
        }

        public static List<Entity> RetrieveAllRecords(IOrganizationService service, QueryExpression query)
        {
            var pageNumber = 1;
            var pagingCookie = string.Empty;
            var result = new List<Entity>();
            EntityCollection resp;
            do
            {
                if (pageNumber != 1)
                {
                    query.PageInfo.PageNumber = pageNumber;
                    query.PageInfo.PagingCookie = pagingCookie;
                }
                resp = service.RetrieveMultiple(query);
                if (resp.MoreRecords)
                {
                    pageNumber++;
                    pagingCookie = resp.PagingCookie;
                }

                result.AddRange(resp.Entities);
            }
            while (resp.MoreRecords);

            return result;
        }

        #endregion
    }
}