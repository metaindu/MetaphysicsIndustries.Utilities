
/*
 *  MetaphysicsIndustries.Utilities
 *  Copyright (C) 2014 Metaphysics Industries, Inc., Richard Sartor
 *
 *  This program is free software; you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation; either version 2 of the License, or
 *  (at your option) any later version.
 *
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License along
 *  with this program; if not, write to the Free Software Foundation, Inc.,
 *  51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
 * 
 */

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