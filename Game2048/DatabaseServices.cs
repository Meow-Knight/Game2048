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
        private static Dictionary<string, SqlDataAdapter> dataAdapters;
        private static DataSet dataSet;

        static DatabaseServices() {
            connection = new SqlConnection();
            command = new SqlCommand();
            dataAdapters = new Dictionary<string, SqlDataAdapter>();

            SqlDataAdapter dataAdapterScoreLevel4 = new SqlDataAdapter();
            SqlDataAdapter dataAdapterScoreLevel5 = new SqlDataAdapter();
            SqlDataAdapter dataAdapterScoreLevel6 = new SqlDataAdapter();

            dataAdapters.Add("lv4", dataAdapterScoreLevel4);
            dataAdapters.Add("lv5", dataAdapterScoreLevel5);
            dataAdapters.Add("lv6", dataAdapterScoreLevel6);

            command.Connection = connection;
            command.CommandType = CommandType.Text;

            getConnection();
        }

        public static void getConnection() {
            string connectionString = @"Data Source=DESKTOP-5I6056Q\SQLEXPRESS;Initial Catalog=Data2048Game;Integrated Security=True;";
            connection.ConnectionString = connectionString;
            connection.Open();

            DataTable tableScoreLevel4 = new DataTable("ScoreLevel4");
            tableScoreLevel4.Columns.Add("ID", typeof(Int32));
            tableScoreLevel4.PrimaryKey = new DataColumn[] { tableScoreLevel4.Columns["ID"] };
            tableScoreLevel4.Columns["ID"].AutoIncrement = true;
            tableScoreLevel4.Columns["ID"].AutoIncrementStep = 1;
            tableScoreLevel4.Columns.Add("UserName", typeof(string));
            tableScoreLevel4.Columns.Add("Score", typeof(Int32));

            DataTable tableScoreLevel5 = new DataTable("ScoreLevel5");
            tableScoreLevel5.Columns.Add("ID", typeof(Int32));
            tableScoreLevel5.PrimaryKey = new DataColumn[] { tableScoreLevel5.Columns["ID"] };
            tableScoreLevel5.Columns["ID"].AutoIncrement = true;
            tableScoreLevel5.Columns["ID"].AutoIncrementStep = 1;
            tableScoreLevel5.Columns.Add("UserName", typeof(string));
            tableScoreLevel5.Columns.Add("Score", typeof(Int32));

            DataTable tableScoreLevel6 = new DataTable("ScoreLevel6");
            tableScoreLevel6.Columns.Add("ID", typeof(Int32));
            tableScoreLevel6.PrimaryKey = new DataColumn[] { tableScoreLevel6.Columns["ID"] };
            tableScoreLevel6.Columns["ID"].AutoIncrement = true;
            tableScoreLevel6.Columns["ID"].AutoIncrementStep = 1;
            tableScoreLevel6.Columns.Add("UserName", typeof(string));
            tableScoreLevel6.Columns.Add("Score", typeof(Int32));

            dataSet = new DataSet("LeaderBoard");

            dataSet.Tables.Add(tableScoreLevel4);
            dataSet.Tables.Add(tableScoreLevel5);
            dataSet.Tables.Add(tableScoreLevel6);

            for (int level = 4; level <= 6; ++level) {
                command.CommandText = $"SELECT * FROM ScoreLevel{level}";
                SqlDataAdapter dataAdapter = dataAdapters[$"lv{level}"];

                dataAdapter.SelectCommand = command;
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                dataAdapter.Fill(dataSet.Tables[$"ScoreLevel{level}"]);

                dataAdapter.DeleteCommand = commandBuilder.GetDeleteCommand();
                dataAdapter.InsertCommand = commandBuilder.GetInsertCommand();
                dataAdapter.UpdateCommand = commandBuilder.GetUpdateCommand();
            }
        }

        public static DataTable getData(int level) {
            return dataSet.Tables[$"ScoreLevel{level}"];
        }

        public static int getHighScore(int level) {
            DataTable table = getData(level);

            int bestScore = 0;
            foreach (DataRow row in table.Rows) {
                bestScore = ((int)row["Score"]) > bestScore ? (int)row["Score"] : bestScore;
            }

            return bestScore;
        }

        public static void update(int level, string userName, int score) {
            DataTable table = getData(level);
            DataRow row = table.NewRow();

            row["UserName"] = userName;
            row["Score"] = score;

            table.Rows.Add(row);

            dataAdapters[$"lv{level}"].Update(table);
        }

        public static void clear(int level) {
            DataTable table = getData(level);

            DialogResult resultMessage = MessageBox.Show(
                "Do you want to clear all the score?", "Warning",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button3);

            switch (resultMessage) {
                case DialogResult.Yes:
                    table.Rows.Clear();
                    table.AcceptChanges();
                    break;
                case DialogResult.No:
                    break;
            }

            string sqlTrunc = $"TRUNCATE TABLE ScoreLevel{level}";
            SqlCommand cmdTruncate = new SqlCommand(sqlTrunc, connection);
            cmdTruncate.ExecuteNonQuery();
        }
    }
}
