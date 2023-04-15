using System.ComponentModel.DataAnnotations;

namespace MyWebAPI_24_03.Model1
{
    public class APINameClient
    {
        [Key]
        public int NameId { get; set; }
        public string NamePLC { get; set; }
        public string NameIP { get; set; }
        public bool Status { get; set; }
    }
}
