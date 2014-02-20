namespace MetaphysicsIndustries.Utilities
{
    partial class StringSelectionForm
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
            this._okbutton = new System.Windows.Forms.Button();
            this._cancelbutton = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // _okbutton
            // 
            this._okbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._okbutton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._okbutton.Enabled = false;
            this._okbutton.Location = new System.Drawing.Point(124, 230);
            this._okbutton.Name = "_okbutton";
            this._okbutton.Size = new System.Drawing.Size(75, 23);
            this._okbutton.TabIndex = 0;
            this._okbutton.Text = "Ok";
            this._okbutton.UseVisualStyleBackColor = true;
            // 
            // _cancelbutton
            // 
            this._cancelbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._cancelbutton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._cancelbutton.Location = new System.Drawing.Point(205, 230);
            this._cancelbutton.Name = "_cancelbutton";
            this._cancelbutton.Size = new System.Drawing.Size(75, 23);
            this._cancelbutton.TabIndex = 1;
            this._cancelbutton.Text = "Cancel";
            this._cancelbutton.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(268, 212);
            this.listBox1.TabIndex = 2;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // StringSelectionForm
            // 
            this.AcceptButton = this._okbutton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._cancelbutton;
            this.ClientSize = new System.Drawing.Size(292, 265);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this._cancelbutton);
            this.Controls.Add(this._okbutton);
            this.Name = "StringSelectionForm";
            this.Text = "StringSelectionForm";
            this.Load += new System.EventHandler(this.StringSelectionForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _okbutton;
        private System.Windows.Forms.Button _cancelbutton;
        private System.Windows.Forms.ListBox listBox1;
    }
}