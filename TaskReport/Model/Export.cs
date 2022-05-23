using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskReport.Model
{
    public class Export
    {
        public int ID { get; }
        public string exportName { get; }
        public DateTime dateAndTime { get; }
        public string userName { get; }
        public string spaceName { get; }

        public Export(int iD, string exportName, DateTime dateAndTime, string userName, string spaceName)
        {
            ID = iD;
            this.exportName = exportName;
            this.dateAndTime = dateAndTime;
            this.userName = userName;
            this.spaceName = spaceName;
        }

        public List<string> GetData()
        {
            List<string> data = new List<string>();

            data.Add(ID.ToString());
            data.Add(exportName);
            data.Add(dateAndTime.ToString("d"));
            data.Add(dateAndTime.ToString("HH:mm"));
            data.Add(userName);
            data.Add(spaceName);

            return data;
        }
    }
}
