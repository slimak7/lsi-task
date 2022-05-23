using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskReport.Repos;

namespace TaskReport.Managers
{
    public class DBManager
    {
        private SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\SzymonKlewicki\\source\\repos\\lsi-task\\TaskReport\\Database\\reportsDB.mdf;Integrated Security=True");
        
        
        public List<string> LoadSpacesNames()
        {
            connection.Open();

            List<string> names = new List<string>();

            SqlCommand sqlCommand = new SqlCommand("SELECT DISTINCT placeName FROM reports", connection);

            SqlDataReader dataReader;

            dataReader = sqlCommand.ExecuteReader();

            while(dataReader.Read())
            {
                names.Add(dataReader.GetString(0));
            }

            connection.Close();

            return names;
        }

        public void LoadAllExports(ExportRepo repo, string placeName, DateTime dateTimeFrom, DateTime dateTimeTo)
        {
            repo.exports.Clear();
            connection.Open();

            string query = "SELECT * FROM reports WHERE placeName = '" + placeName + "' AND " +
                "DateAndTime >= '" + dateTimeFrom.ToString("yyyy-MM-dd") + "' AND DateAndTime <= '" + dateTimeTo.ToString("yyyy-MM-dd") + "'";

            SqlCommand sqlCommand = new SqlCommand(query, connection);

            SqlDataReader dataReader;

            dataReader = sqlCommand.ExecuteReader();

            while (dataReader.Read())
            {
                repo.exports.Add(new Model.Export(dataReader.GetInt32(0), dataReader.GetString(1), dataReader.GetDateTime(2),
                    dataReader.GetString(3), dataReader.GetString(4)));
            }

            connection.Close();
        }
    }
}
