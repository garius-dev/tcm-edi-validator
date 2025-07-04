using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCT_EDI_Organizer.Models
{
    public class DecodedProtocol
    {
        public string Protocol { get; set; }
        public List<string> Line322 { get; set; }
        public List<string> Line329 { get; set; }
    }

    public class AppResult
    {
        public List<DecodedProtocol> DecodedProtocols { get; set; } = new List<DecodedProtocol>();
        public List<string> ErrorList { get; set; } = new List<string>();
        public List<string> WarningList { get; set; } = new List<string>();
    }
}
