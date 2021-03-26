using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntranceMonitoring.Models
{
    public class Registry
    {
        public int Id { get; set; }
        public DateTime Registedtime { get; set; }
        public string InOut { get; set; }
        public int UserId { get; set; }
        public int BuildingId { get; set; }

        public User User { get; set; }
        public Building Building { get; set; }
    }
}
