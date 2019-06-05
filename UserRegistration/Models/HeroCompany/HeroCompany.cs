/*using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UserRegistration.Models.HeroCompany
{
    public class HeroCompanys
    {
        [Key]
        public int companyID { get; set; }

        [ForeignKey("Heros")]
        public int HeroID { get; set; }
        

        public string companyName { get; set; }

        public virtual Heros Heros { get; set; }
    }
}
*/