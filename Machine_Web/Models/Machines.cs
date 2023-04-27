using System.ComponentModel.DataAnnotations;

namespace Machine_Web.Models
{
    public class Machines
    {


        [Key]
        public int ID { get; set; }
        public int ConnectionID { get; set; }
        public string? Module { get; set; }
        public string? Name { get; set; }
        public string? ProductionAddress { get; set; }
        public string? ProductionValue { get; set; }
        public string? CurrentProductionaddress { get; set; }

      
    }
  
}
