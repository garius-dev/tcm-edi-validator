using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCT_EDI_Organizer.Models
{
    public class DecodedRecord
    {
        [DisplayName("Minuta")]
        public string Minuta { get; set; }

        [DisplayName("Filial")]
        public string BranchName { get; set; }

        [DisplayName("Cód. Filial")]
        public string BranchCode { get; set; }

        [DisplayName("Veículo")]
        public string Vehicle { get; set; }

        [DisplayName("Protocolo")]
        public string ProtocolNumber { get; set; }

        [DisplayName("Fluxo")]
        public string FlowType { get; set; }

        [DisplayName("Status")]
        public string Status { get; set; } // "OK" ou "Erro"

        [DisplayName("Erros")]
        public string Errors { get; set; } // Lista de erros concatenada

        // Propriedade interna para a lógica
        [Browsable(false)]
        public List<string> ErrorList { get; set; } = new List<string>();
    }
}
