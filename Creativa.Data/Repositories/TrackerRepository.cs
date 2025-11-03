using System;
using System.Data.Entity;

namespace Creativa.Data
{
    public class TrackerRepository : ITrackerRepository
    {
        public void Log(string url, string ip)
        {
            using (var db = new NORTHWNDEntities()) 
            {
                //db.Database.ExecuteSqlCommand(
                //    "INSERT INTO dbo.webTracker (URLRequest, SourceIp, TimeOfAction) VALUES (@p0, @p1, SYSDATETIME())",
                //    url ?? string.Empty,
                //    ip ?? string.Empty
                //);

                 var item = new webTracker { URLRequest = url ?? "", SourceIp = ip ?? "", TimeOfAction = DateTime.Now };
                db.webTracker.Add(item);
                db.SaveChanges();
            }
        }
    }
}
