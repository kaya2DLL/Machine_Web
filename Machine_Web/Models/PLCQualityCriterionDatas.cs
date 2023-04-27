using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Machine_Web.Models
{
    public class PLCQualityCriterionDatas
    {
        [Key]
        public int OID { get; set; }
        public int  MachineID { get; set; }
        public int DataExplainID { get; set; }
        public double DataValue { get; set; }
        public DateTime Times { get; set; }
        public double DataDifferenceValue { get; set; }


        
      

    }
}
