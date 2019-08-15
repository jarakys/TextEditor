using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SQLite;
using System.Threading.Tasks;

namespace TextEditor.Database
{
    public class DatabaseConnection : ITextEditorDatabase
    {
        public async Task<List<string>> GetAllRecord()
        {
            List<String> records = new List<string>();
            using (var sqlite = new SQLiteConnection(DbPath()))
            {
                sqlite.Open();
                SQLiteCommand command = sqlite.CreateCommand();
                command.CommandText = "select Name from Files";
                DbDataReader reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    records.Add((String)reader["Name"]);
                }
            }
            return records;
        }

        public async Task<string> GetFileContentByName(string name)
        {
            string result = string.Empty;
            using (var sqlite = new SQLiteConnection(DbPath()))
            {
                sqlite.Open();
                SQLiteCommand command = sqlite.CreateCommand();
                command.CommandText = "Select * from Files where Name like @fileName";
                command.Parameters.Add("@fileName", System.Data.DbType.String).Value = name;
                DbDataReader reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    result = (string)reader["Content"];
                }
            }
            return result;
        }

        public async Task<bool> Create(string fileName, string content)
        {
            using (var sqlite = new SQLiteConnection(DbPath()))
            {
                sqlite.Open();
                SQLiteCommand command = sqlite.CreateCommand();
                command.CommandText = "insert into Files(Name, Content) values(@fileName, @content)";
                command.Parameters.Add("@fileName", System.Data.DbType.String).Value = fileName;
                command.Parameters.Add("@content", System.Data.DbType.String).Value = content;
                int countRecords = await command.ExecuteNonQueryAsync();
                if (countRecords > 0)
                {
                    return true;
                }
                return false;
            }
        }

        public async Task<bool> Update(string fileName, string content)
        {
            using (var sqlite = new SQLiteConnection(DbPath()))
            {
                sqlite.Open();
                SQLiteCommand command = sqlite.CreateCommand();
                command.CommandText = "Update Files Set Content = @content where Name like @fileName";
                command.Parameters.Add("@content", System.Data.DbType.String).Value = content;
                command.Parameters.Add("@fileName", System.Data.DbType.String).Value = fileName;
                int count = await command.ExecuteNonQueryAsync();
                if (count > 0)
                {
                    return true;
                }
                return false;
            }
        }

        private string DbPath(string nameConnection = "Default")
        {
            return ConfigurationManager.ConnectionStrings[nameConnection].ConnectionString;
        }
    }
}
