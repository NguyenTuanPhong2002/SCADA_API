using System.ComponentModel.DataAnnotations;

namespace MyWebAPI_24_03.Model1
{
    public class APIData
    {
        [Key]
        public int DataId { get; set; }
        public string NameTank { get; set; }
        public bool StartStop { get; set; }
        public bool CmdMotor { get; set; }
        public double DataTemperature { get; set; }
        public double DataLevel { get; set; }
        public String TimeStanp { get; set; }
    }
}
