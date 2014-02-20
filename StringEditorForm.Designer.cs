namespace MetaphysicsIndustries.Utilities
{
    partial class StringEditorForm
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
            this._okButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this._contentsTextBox = new System.Windows.Forms.TextBox();
            this._multilineCheckbox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // _okButton
            // 
            this._okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._okButton.Location = new System.Drawing.Point(110, 38);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(75, 23);
            this._okButton.TabIndex = 1;
            this._okButton.Text = "OK";
            this._okButton.UseVisualStyleBackColor = true;
            this._okButton.Click += new System.EventHandler(this._okButton_Click);
            // 
            // _cancelButton
            // 
            this._cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._cancelButton.Location = new System.Drawing.Point(191, 38);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(75, 23);
            this._cancelButton.TabIndex = 2;
            this._cancelButton.Text = "Cancel";
            this._cancelButton.UseVisualStyleBackColor = true;
            this._cancelButton.Click += new System.EventHandler(this._cancelButton_Click);
            // 
            // _contentsTextBox
            // 
            this._contentsTextBox.AcceptsReturn = true;
            this._contentsTextBox.AcceptsTab = true;
            this._contentsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._contentsTextBox.Location = new System.Drawing.Point(12, 12);
            this._contentsTextBox.MinimumSize = new System.Drawing.Size(156, 20);
            this._contentsTextBox.Name = "_contentsTextBox";
            this._contentsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this._contentsTextBox.Size = new System.Drawing.Size(254, 20);
            this._contentsTextBox.TabIndex = 0;
            this._contentsTextBox.TextChanged += new System.EventHandler(this._contentsTextBox_TextChanged);
            // 
            // _multilineCheckbox
            // 
            this._multilineCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._multilineCheckbox.AutoSize = true;
            this._multilineCheckbox.Location = new System.Drawing.Point(12, 42);
            this._multilineCheckbox.Name = "_multilineCheckbox";
            this._multilineCheckbox.Size = new System.Drawing.Size(64, 17);
            this._multilineCheckbox.TabIndex = 3;
            this._multilineCheckbox.Text = "Multiline";
            this._multilineCheckbox.UseVisualStyleBackColor = true;
            this._multilineCheckbox.CheckedChanged += new System.EventHandler(this._multilineCheckbox_CheckedChanged);
            // 
            // StringEditorForm
            // 
            this.AcceptButton = this._okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._cancelButton;
            this.ClientSize = new System.Drawing.Size(278, 73);
            this.Controls.Add(this._multilineCheckbox);
            this.Controls.Add(this._contentsTextBox);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._okButton);
            this.MinimumSize = new System.Drawing.Size(286, 100);
            this.Name = "StringEditorForm";
            this.Text = "Edit String";
            this.Load += new System.EventHandler(this.StringEditorForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _okButton;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.TextBox _contentsTextBox;
        private System.Windows.Forms.CheckBox _multilineCheckbox;
    }
}