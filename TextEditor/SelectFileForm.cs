using System;
using System.Windows.Forms;
using TextEditor.Database;

namespace TextEditor
{
    public partial class SelectFileForm : Form
    {
        private static bool isSelectedFile;
        public static string StartForResult()
        {
            SelectFileForm form = new SelectFileForm();
            form.ShowDialog();
            return isSelectedFile?(string)form.listFiles.SelectedItem:"";
        }
        public SelectFileForm()
        {
            isSelectedFile = false;
            InitializeComponent();
        }

        private void OpenButtonClick(object sender, EventArgs e)
        {
            isSelectedFile = true;
            Close();
        }

        private async void SelectFileForm_Load(object sender, EventArgs e)
        {
            var result = await Global.Database.GetAllRecord();
            listFiles.DataSource = result;
        }
    }
}
