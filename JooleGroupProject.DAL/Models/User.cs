using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JooleGroupProject.DAL.Models
{
    public class User
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserID { get; set; }

        //[Required]
        //[StringLength(50)]
        public string UserName { get; set; }

        //[Required]
        //[StringLength(50)]
        public string Password { get; set; }

        //[Required]
        //[StringLength(50)]
        public string EmailAddress { get; set; }
    }
}
