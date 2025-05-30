using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;

namespace COURSACH_APP_WITH_SQL
{
    public class DB
    {
        private const string connectionString = "Server=localhost;Port=5432;Database=tour_base;User Id=postgres;Password=postgres;";
        public NpgsqlConnection connection;
        private const string databaseName = "tour_base";

        public DB()
        {
            connection = new NpgsqlConnection(connectionString);
        }

        public bool OpenConnection()
        {
            try
            {
                if (connection.State == ConnectionState.Closed) //Проверяем состояние
                {
                    connection.Open();
                }
                return true;
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show($"Error opening connection to database: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public void CloseConnection()
        {
            if (connection != null && connection.State != ConnectionState.Closed)
            {
                connection.Close();
            }
        }

        public DataTable ExecuteQuery(string query, NpgsqlParameter[] parameters = null)
        {
            DataTable dataTable = new DataTable();
            try
            {
                if (!OpenConnection()) return null;
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    if (parameters != null) command.Parameters.AddRange(parameters);
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        dataTable.Load(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при выполнении запроса: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dataTable;
        }

        public string GetDatabaseName()
        {
            return databaseName;
        }

    }
}
