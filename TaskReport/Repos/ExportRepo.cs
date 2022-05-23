using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskReport.Model;

namespace TaskReport.Repos
{
    public class ExportRepo
    {
        public List<Export> exports;

        public ExportRepo ()
        {
            exports = new List<Export>();
        }

        public List<List<string>> GetAllData()
        {
            List<List<string>> allData = new List<List<string>>();
            foreach (var e in exports)
            {
                allData.Add(e.GetData());
            }

            return allData;
        } 
    }
}
