using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace MichangerAPIControl.Forms
{
    public partial class AdbTextPickerForm : Form
    {
        public string SelectedCommand { get; private set; }
        private string _xmlData;

        public AdbTextPickerForm(string xmlData)
        {
            InitializeComponent();
            _xmlData = xmlData;
            LoadTextElements();
        }

        private void LoadTextElements()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Text");
            dt.Columns.Add("Bounds");
            dt.Columns.Add("ContentDesc");

            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(_xmlData);
                XmlNodeList nodes = doc.SelectNodes("//node");
                
                foreach (XmlNode node in nodes)
                {
                    string text = node.Attributes["text"]?.Value;
                    string contentDesc = node.Attributes["content-desc"]?.Value;
                    string bounds = node.Attributes["bounds"]?.Value;

                    if (!string.IsNullOrEmpty(text) || !string.IsNullOrEmpty(contentDesc))
                    {
                        dt.Rows.Add(text, bounds, contentDesc);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error parsing UI: " + ex.Message);
            }

            dgvText.DataSource = dt;
            dgvText.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnAddIfFound_Click(object sender, EventArgs e)
        {
            if (dgvText.CurrentRow == null) return;
            string text = dgvText.CurrentRow.Cells["Text"].Value?.ToString();
            if (string.IsNullOrEmpty(text)) text = dgvText.CurrentRow.Cells["ContentDesc"].Value?.ToString();
            
            if (!string.IsNullOrEmpty(text))
            {
                SelectedCommand = $"IfTextFound|{text}|Goto:LABEL_NAME|Else:Continue";
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnAddTapText_Click(object sender, EventArgs e)
        {
            if (dgvText.CurrentRow == null) return;
            string text = dgvText.CurrentRow.Cells["Text"].Value?.ToString();
            if (string.IsNullOrEmpty(text)) text = dgvText.CurrentRow.Cells["ContentDesc"].Value?.ToString();

            if (!string.IsNullOrEmpty(text))
            {
                SelectedCommand = $"TapText|{text}";
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
