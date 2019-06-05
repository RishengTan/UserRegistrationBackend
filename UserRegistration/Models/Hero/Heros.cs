using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace UserRegistration.Models
{
    public class Heros 
    {
        [Key]
        [Required]
        public int HeroID { get; set; }
        public string HeroName { get; set; }
        public int Offense { get; set; }
        public int Speed { get; set; }
        public int Health { get; set; }
        public int Defense { get; set; }

        

       
       

    }
}