using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MetaphysicsIndustries.Utilities
{
    public partial class StringEditorForm : Form
    {
        public static string GetString(string contents, string caption, IWin32Window owner)
        {
            using (StringEditorForm form = new StringEditorForm(contents, caption))
            {
                if (form.ShowDialog(owner) == DialogResult.OK)
                {
                    return form.Contents;
                }
            }
            return contents;
        }
        public static string GetString(string contents, string caption)
        {
            using (StringEditorForm form = new StringEditorForm(contents, caption))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    return form.Contents;
                }
            }
            return contents;
        }

        public StringEditorForm(string contents, string caption)
            : this(contents)
        {
            if (!string.IsNullOrEmpty(caption))
            {
                this.Text = caption;
            }
        }
        public StringEditorForm(string contents)
        {
            InitializeComponent();

            _contents = contents ?? string.Empty;

            if (_contents.Contains("\r") || _contents.Contains("\n"))
            {
                Height += 25;
            }
        }

        private string _contents;

        public string Contents
        {
            get { return _contents; }
            set { _contents = value ?? string.Empty; }
        }

        private void _okButton_Click(object sender, EventArgs e)
        {
            Contents = _contentsTextBox.Text;
        }

        private void _cancelButton_Click(object sender, EventArgs e)
        {

        }

        private void StringEditorForm_Load(object sender, EventArgs e)
        {
            _contentsTextBox.Text = _contents;

            if (_contents.Contains("\r") || _contents.Contains("\n"))
            {
                _multilineCheckbox.Checked = true;
            }
        }

        private void _contentsTextBox_TextChanged(object sender, EventArgs e)
        {
            if (_contentsTextBox.Text.Contains("\r") || _contentsTextBox.Text.Contains("\n"))
            {
                _multilineCheckbox.Checked = true;
                _multilineCheckbox.Enabled = false;
            }
            else
            {
                _multilineCheckbox.Enabled = true;
            }
        }

        private void _multilineCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (_multilineCheckbox.Checked)
            {
                _contentsTextBox.AcceptsReturn = true;
                _contentsTextBox.AcceptsTab = true;
                _contentsTextBox.Multiline = true;
            }
            else
            {
                _contentsTextBox.AcceptsReturn = false;
                _contentsTextBox.AcceptsTab = false;
                _contentsTextBox.Multiline = false;
            }
        }


    }
}