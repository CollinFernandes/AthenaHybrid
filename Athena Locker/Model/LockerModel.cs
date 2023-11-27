using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athena_Locker.Model
{
    class LockerModel
    {
        public List<LockerItem> items { get; set; }
    }

    class LockerItem
    {
        public string templateId { get; set; }
    }
}
