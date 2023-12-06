using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athena_Hybrid.BackEnd.Models
{
    public class FilesModelResponse
    {
        public List<FilesModel> files { get; set; }
        public string injectorFileName { get; set; }
        public bool injectorStatus { get; set; }
        public bool DevInventory { get; set; }
        public string DevPak { get; set; }
        public string DevSearch { get; set; }
        public string DevReplace { get; set; }
    }

    public class FilesModel
    {
        public string fileName {  get; set; }
        public string url {  get; set; }
        public bool premiumNeeded {  get; set; }
        public bool download { get; set; }
    }
}
