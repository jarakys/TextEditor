namespace TextEditor
{
    partial class SelectFileForm
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
            this.listFiles = new System.Windows.Forms.ListBox();
            this.openButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listFiles
            // 
            this.listFiles.FormattingEnabled = true;
            this.listFiles.Items.AddRange(new object[] {
            "sdfsa",
            "sadf",
            "asdf",
            "asd",
            "fsad",
            "fsa",
            "df",
            "sadf",
            "sad",
            "f",
            "asdf",
            "sad",
            "fsa",
            "df",
            "sad",
            "fsa",
            "df",
            "sadf",
            "as",
            "df",
            "asdf",
            "asd",
            "fas",
            "df",
            "asdf",
            "sa",
            "df",
            "asdasd",
            "as",
            "da",
            "sd",
            "sd",
            "d",
            "d",
            "d",
            "d",
            "d",
            "d",
            "d",
            "d",
            "dd",
            "sa",
            "das",
            "d",
            "sd",
            "sd",
            "s",
            "ds",
            "d",
            "sd",
            "sd",
            "s",
            "ds",
            "d",
            "sd",
            "sd"});
            this.listFiles.Location = new System.Drawing.Point(12, 12);
            this.listFiles.Name = "listFiles";
            this.listFiles.Size = new System.Drawing.Size(311, 407);
            this.listFiles.TabIndex = 0;
            this.listFiles.DoubleClick += new System.EventHandler(this.OpenButtonClick);
            // 
            // openButton
            // 
            this.openButton.Location = new System.Drawing.Point(248, 433);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(75, 23);
            this.openButton.TabIndex = 1;
            this.openButton.Text = "Open";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.OpenButtonClick);
            // 
            // SelectFileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 468);
            this.Controls.Add(this.openButton);
            this.Controls.Add(this.listFiles);
            this.MaximumSize = new System.Drawing.Size(351, 507);
            this.MinimumSize = new System.Drawing.Size(351, 507);
            this.Name = "SelectFileForm";
            this.Text = "Select a file";
            this.Load += new System.EventHandler(this.SelectFileForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listFiles;
        private System.Windows.Forms.Button openButton;
    }
}