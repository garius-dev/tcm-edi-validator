using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCT_EDI_Organizer.Models
{
    public class BranchConfig
    {
        public string Name { get; set; } // Ex: "São Bernado do Campo"
        public string EdiCode { get; set; } 
        public string Code { get; set; } 
        public int OddCode { get; set; } // Ex: 1
        public int EvenCode { get; set; } // Ex: 2
    }
}
