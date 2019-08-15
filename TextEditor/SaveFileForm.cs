using System;
using System.IO;
using System.Windows.Forms;
using TextEditor.Untils;

namespace TextEditor
{
    public partial class SaveFileForm : Form
    {
        private string content;
        private string pathToFile;
        private bool isSaved;

        public static bool StartForResult(string content, string fileName, string pathToFile="")
        {
            SaveFileForm form = new SaveFileForm(content, fileName, pathToFile);
            form.ShowDialog();
            return form.isSaved;
        }

        private SaveFileForm(string content, string fileName, string pathToFile = "")
        {
            InitializeComponent();
            this.content = content;
            fileNameText.Text = fileName;
            this.pathToFile = pathToFile;
        }

        private bool ValidateFilename()
        {
            return !String.IsNullOrEmpty(fileNameText.Text);
        }

        private void ItemSaveSuccess()
        {
            isSaved = true;
            MessageBox.Show("Success");
            Close();
        }

        private async void OnSaveToDatabaseButtonClick(object sender, EventArgs e)
        {
            if (!ValidateFilename())
            {
                return;
            }
            if (!await Global.Database.Update(fileNameText.Text, content.Compress()))
            {
                await Global.Database.Create(fileNameText.Text, content.Compress());
            }
            ItemSaveSuccess();
        }

        private void OnSaveToDesctopButtonClick(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = pathToFile.Replace(fileNameText.Text+".txt","");
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                pathToFile = folderBrowserDialog.SelectedPath+"\\"+ fileNameText.Text + ".txt";
                File.WriteAllText(pathToFile, content);
                ItemSaveSuccess();
            }
        }
    }
}
