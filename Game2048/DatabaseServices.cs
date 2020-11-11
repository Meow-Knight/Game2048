using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game2048 {
    static class DatabaseServices {
        private static SqlConnection connection;
        private static SqlCommand command;
        private static SqlDataAdapter dataAdapter;

        static DatabaseServices() {
            connection = new SqlConnection();
            dataAdapter = new SqlDataAdapter();
            command = new SqlCommand();

            command.Connection = connection;
            command.CommandType = CommandType.Text;

            getConnection();
        }

        public static async void getConnection() {
            string connectionString = @"Data Source=MINH-COMPUTER\SQLEXPRESS;Initial Catalog=Data2048Game;Integrated Security=True;";
            connection.ConnectionString = connectionString;
            connection.Open();
        }

        public static DataTable getData(int level) {
            command.CommandText = $"SELECT * FROM ScoreLevel{level}";
            dataAdapter.SelectCommand = command;

            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            return dataTable;
        }

        public static void update() {
            DataTable data = getData(Controller.Level);
            DataRow row = data.NewRow();

            row["UserName"] = "Minh";
            row["Score"] = Controller.score;

            data.Rows.Add(row);

            Console.WriteLine(row["UserName"]);

            dataAdapter.Update(data);
        }
    }
}
