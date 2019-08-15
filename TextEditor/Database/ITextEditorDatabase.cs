using System.Collections.Generic;
using System.Threading.Tasks;

namespace TextEditor.Database
{
    public interface ITextEditorDatabase
    {
        Task<bool> Create(string fileName, string content);
        Task<List<string>> GetAllRecord();
        Task<string> GetFileContentByName(string name);
        Task<bool> Update(string fileName, string content);
    }
}