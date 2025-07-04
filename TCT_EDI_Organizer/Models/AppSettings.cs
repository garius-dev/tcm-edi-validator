using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCT_EDI_Organizer.Models
{
    public class AppSettings
    {
        public List<VehicleConfig> Vehicles { get; set; }
        public List<BranchConfig> Branches { get; set; }
        public List<CollectionConfig> Collections { get; set; }
        public List<Positions322Config> Positions322 { get; set; }
        public List<Positions329Config> Positions329 { get; set; }

        public AppSettings()
        {
            // Inicializa com valores padrão para o primeiro uso
            Vehicles = new List<VehicleConfig>();
            Branches = new List<BranchConfig>();
            Collections = new List<CollectionConfig>();
            Positions322 = new List<Positions322Config>();
            Positions329 = new List<Positions329Config>();
        }
    }
}
