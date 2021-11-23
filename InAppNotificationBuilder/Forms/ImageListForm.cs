using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Fic.XTB.InAppNotificationBuilder.Proxy;
using Microsoft.Xrm.Sdk;
using Svg;

namespace Fic.XTB.InAppNotificationBuilder.Forms
{
    public partial class ImageListForm : Form
    {
        private readonly InAppNotificationBuilder _ianb;
        private Dictionary<Guid, int> imageDictionary = new Dictionary<Guid, int>();

        private const string SearchPlaceholder = "Enter text here...";
        private bool _placeholderActive = false;

        public ImageListForm(InAppNotificationBuilder ianb)
        {
            _ianb = ianb;

            InitializeComponent();
            InitImageList();
        }

        private void FilterImages(string searchTerm)
        {
            if (_placeholderActive) { return; }

            if (searchTerm == string.Empty && imageDictionary.Keys.Count == lvIcons.Items.Count) { return; }

            if (searchTerm.Length < 3 && searchTerm.Length != 0) { return; }

            lvIcons.Items.Clear();

            searchTerm = searchTerm.ToLower();

            foreach (var image in _ianb.Images)
            {
                var name = (string)image["name"];
                var displayName = image.Contains("displayname") ? (string)image["displayname"] : string.Empty;

                if (!string.IsNullOrEmpty(searchTerm) &&
                    (!name.ToLower().Contains(searchTerm)) && !displayName.ToLower().Contains(searchTerm)) { continue; }

                AddImageToList(image);
            }
        }

        private void InitImageList()
        {
            imageList.Images.Clear();
            imageDictionary.Clear();

            var cnt = 0;
            foreach (var image in _ianb.Images)
            {
                try
                {
                    var isVector = ((OptionSetValue)image["webresourcetype"]).Value == 11;
                    var body = (string)image["content"];

                    var img = ConvertWebResContent(body, isVector);
                    imageList.Images.Add(img);

                    imageDictionary.Add(image.Id, cnt);

                    cnt++;
                }
                catch (Exception e)
                {
                    // ignored
                }
            }

            FilterImages("");
        }

        private void AddImageToList(Entity image)
        {
            var exists = imageDictionary.TryGetValue(image.Id, out var imageIndex);

            if (!exists) { return; }

            var displayName = image.Contains("displayname")
                ? (string)image["displayname"]
                : (string)image["name"];

            var item = new ListViewItem
            {
                ImageIndex = imageIndex,
                Text = displayName,
                Tag = image
            };

            lvIcons.Items.Add(item);
        }

        public static Image ConvertWebResContent(string contentImageList, bool isVector)
        {
            var imageBytes = Convert.FromBase64String(contentImageList);

            using (var ms = new MemoryStream(imageBytes))
            {
                if (!isVector) { return Image.FromStream(ms, true, true); }

                var svgDoc = SvgDocument.Open<SvgDocument>(ms);

                return new Bitmap(svgDoc.Draw(64, 64), new Size(64, 64));
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (lvIcons.SelectedItems.Count != 1) { return; }

            var selectedIcon = (Entity)lvIcons.SelectedItems[0].Tag;

            foreach (WebresourceProxy wrp in _ianb.CbCustomIcon.Items)
            {
                if (wrp.Entity.Id != selectedIcon.Id) { continue; }

                _ianb.CbCustomIcon.SelectedItem = wrp;
            }

            this.Close();
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            FilterImages(tbSearch.Text);
        }

        private void tbSearch_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tbSearch.Text)) { return; }

            _placeholderActive = true;
            tbSearch.Text = SearchPlaceholder;
            tbSearch.ForeColor = Color.Gray;
            tbSearch.Font = new Font(tbSearch.Font, FontStyle.Italic);
        }

        private void tbSearch_Enter(object sender, EventArgs e)
        {
            if (tbSearch.Text != SearchPlaceholder) { return; }

            _placeholderActive = false;
            tbSearch.Text = "";
            tbSearch.ForeColor = SystemColors.WindowText;
            tbSearch.Font = new Font(tbSearch.Font, FontStyle.Regular);
        }
    }
}
