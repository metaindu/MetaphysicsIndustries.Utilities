using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MetaphysicsIndustries.Utilities
{
    public partial class StringSelectionForm : Form
    {
        public StringSelectionForm(object[] listItems)
            :this ("Select an item from the list", listItems)
        {
        }
        public StringSelectionForm(string caption, object[] listItems)
        {
            InitializeComponent();
            List<string> list = new List<string>(listItems.Length);
            foreach (object obj in listItems)
            {
                if (obj == null)
                {
                    list.Add("(null)");
                }  
                else
                {
                    list.Add(obj.ToString());
                }
            }
            this.Text = caption;
            _listItems = list.ToArray();
        }

        string[] _listItems;

        public int SelectedItem
        {
            get { return listBox1.SelectedIndex; }
            set { listBox1.SelectedIndex = value; }
        }
        public string SelectedString
        {
            get { return _listItems[SelectedItem]; }
        }

        private void StringSelectionForm_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.Items.AddRange(_listItems);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                _okbutton.Enabled = true;
            }
        }
    }
}