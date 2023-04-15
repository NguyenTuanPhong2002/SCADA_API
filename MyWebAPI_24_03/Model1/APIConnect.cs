using System.ComponentModel.DataAnnotations;

namespace MyWebAPI_24_03.Model1
{
    public class APIConnect
    {
        //internal object Id;
        

        [Key]
        public int ConnId { get; set; }
        public bool Conn { get; set; }
        [MaxLength(100)]
        public string UserClient { get; set; }
        [MaxLength(100)]
        public string PasswordClient { get; set; }
    }
}
