using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athena_Hybrid.BackEnd.Models
{
    public class backgroundModel
    {
        public string Url { get; set; }
        public string Creator { get; set; }
    }

    public class officialBackgroundModel
    {
        public string Label { get; set; }
        public string Value { get; set; }
    }
}
