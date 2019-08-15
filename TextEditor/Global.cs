using TextEditor.Database;

namespace TextEditor
{
    public static class Global
    {
        public static ITextEditorDatabase Database { get; set; } = new DatabaseConnection();
    }
}
