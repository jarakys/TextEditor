using System;
using System.IO;
using System.Windows.Forms;
using TextEditor.Untils;

namespace TextEditor
{
    public partial class MainForm : Form
    {
        private string fileName;
        private string pathToFile;
        public MainForm()
        {
            fileName = string.Empty;
            InitializeComponent();
        }

        private void OnNewFileClick(object sender, EventArgs e)
        {
            textContainer.Clear();
        }

        private void OnOpenFileClick(object sender, EventArgs e)
        {
            textContainer.SelectionStart = textContainer.Text.Length;
            textContainer.Modified = false;
        }

        private void OnSaveFileClick(object sender, EventArgs e)
        {
            if (SaveFileForm.StartForResult(textContainer.Text, fileName, pathToFile))
            {
                textContainer.Modified = false;
            }
        }

        private DialogResult GetResultFromMessageBox()
        {
            return MessageBox.Show(
                        "Save Changes",
                        "Do you want to save the changes?",
                        MessageBoxButtons.YesNo);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(fileName) && textContainer.Modified)
            {
                e.Cancel = (GetResultFromMessageBox() == DialogResult.Yes);
            }
            else if (!String.IsNullOrWhiteSpace(textContainer.Text) && String.IsNullOrWhiteSpace(fileName))
            {
                e.Cancel = (GetResultFromMessageBox() == DialogResult.Yes);
            }
            if (e.Cancel)
            {
                OnSaveFileClick(null, null);
            }
            e.Cancel = false;
        }

        private void OnLoadFromDesktopClick(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pathToFile = openFileDialog.FileName;
                fileName = openFileDialog.SafeFileName.Replace(".txt", "");
                textContainer.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        private async void OnLoadFromDatabaseClick(object sender, EventArgs e)
        {
            fileName = SelectFileForm.StartForResult();
            if (!String.IsNullOrEmpty(fileName))
            {
                string result = await Global.Database.GetFileContentByName(fileName);
                textContainer.Text = result.Decompress();
            }
        }
    }
}
