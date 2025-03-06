namespace QB_Remote_GUI.GUI.Forms
{
    partial class ListViewColumnSelector
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
            btnOK = new Button();
            btnCancel = new Button();
            btnUp = new Button();
            btnDown = new Button();
            listColumns = new ListView();
            SuspendLayout();
            // 
            // btnOK
            // 
            btnOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnOK.DialogResult = DialogResult.OK;
            btnOK.Location = new Point(272, 277);
            btnOK.Margin = new Padding(12);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(100, 30);
            btnOK.TabIndex = 0;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(272, 319);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 30);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnUp
            // 
            btnUp.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnUp.Location = new Point(272, 12);
            btnUp.Margin = new Padding(12);
            btnUp.Name = "btnUp";
            btnUp.Size = new Size(100, 30);
            btnUp.TabIndex = 2;
            btnUp.Text = "Move up";
            btnUp.UseVisualStyleBackColor = true;
            btnUp.Click += btnUp_Click;
            // 
            // btnDown
            // 
            btnDown.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDown.Location = new Point(272, 54);
            btnDown.Margin = new Padding(12);
            btnDown.Name = "btnDown";
            btnDown.Size = new Size(100, 30);
            btnDown.TabIndex = 3;
            btnDown.Text = "Move down";
            btnDown.UseVisualStyleBackColor = true;
            btnDown.Click += btnDown_Click;
            // 
            // listColumns
            // 
            listColumns.CheckBoxes = true;
            listColumns.Location = new Point(12, 12);
            listColumns.Name = "listColumns";
            listColumns.Size = new Size(245, 337);
            listColumns.TabIndex = 4;
            listColumns.UseCompatibleStateImageBehavior = false;
            listColumns.View = View.List;
            // 
            // ListViewColumnSelector
            // 
            AcceptButton = btnOK;
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(384, 361);
            Controls.Add(listColumns);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(btnDown);
            Controls.Add(btnUp);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ListViewColumnSelector";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "ListViewColumnSelector";
            ResumeLayout(false);
        }

        #endregion
        private Button btnCancel;
        private Button btnOK;
        private Button btnUp;
        private Button btnDown;
        private ListView listColumns;
    }
}