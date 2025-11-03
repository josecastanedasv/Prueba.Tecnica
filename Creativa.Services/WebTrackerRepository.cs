using System.Configuration;
using System.Data.SqlClient;

namespace Creativa.Data.Repositories
{
    public class WebTrackerRepository
    {
        private readonly string _sqlConn;

        public WebTrackerRepository()
        {
            var efConn = ConfigurationManager.ConnectionStrings["NORTHWNDEntities"].ConnectionString;
            var start = efConn.IndexOf("provider connection string=\"") + "provider connection string=\"".Length;
            var end = efConn.IndexOf("\"", start);
            _sqlConn = efConn.Substring(start, end - start).Replace("&quot;", "\"");
        }

        public void Log(string url, string ip)
        {
            using (var conn = new SqlConnection(_sqlConn))
            {
                conn.Open();
                using (var cmd = new SqlCommand(
                    "INSERT INTO webTracker (URLRequest, SourceIp, TimeOfAction) VALUES (@url, @ip, GETDATE())", conn))
                {
                    cmd.Parameters.AddWithValue("@url", url);
                    cmd.Parameters.AddWithValue("@ip", ip);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
