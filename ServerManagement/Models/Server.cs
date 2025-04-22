using System.ComponentModel.DataAnnotations;

namespace ServerManagement.Models
{
    public class Server
    {
        public Server()
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 2);
            //0 ise false değil ise true döndür
            IsOnline = randomNumber == 0 ? false : true;
        }
        public int ServerId { get; set; }
        public bool IsOnline { get; set; }
        [Required]
        //bir alanın boş geçirilemeyeceğini belirtir
        public string? Name { get; set; }
        [Required]
        public string? City { get; set; }
    }
}
