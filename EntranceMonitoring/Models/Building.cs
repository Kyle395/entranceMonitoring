using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntranceMonitoring.Models
{
    public class Building
    {
        public int BuildingId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public ICollection<Registry> Registries { get; set; }
    }
}
