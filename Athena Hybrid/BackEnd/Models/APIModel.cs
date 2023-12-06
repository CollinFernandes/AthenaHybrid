using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athena_Hybrid.BackEnd.Models
{
    class APIModel
    {
        public string Version { get; set; }
        public bool IsEnabled { get; set; }
        public List<updateLog> updateLogs { get; set; }
        public List<reasonToUse> reasonsToUse { get; set; }
        public List<Credit> Credits { get; set; }
    }

    public class updateLog
    {
        public string Icon {  get; set; }
        public string Title {  get; set; }
        public string Description {  get; set; }
    }

    class reasonToUse
    {
        public string Icon { get; set; }
        public string Title { get; set; }
        public string Description {  get; set; }
    }

    class Credit
    {
        string username { set; get; }
        string Globalname { set; get; }
        string ProfilePicture { set; get; }
    }
}
