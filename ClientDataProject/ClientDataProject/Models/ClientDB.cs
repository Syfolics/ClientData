using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClientDataProject.Models
{
    public class ClientDB
    {
        [Key]
        public int ClientID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string Email { get; set; }

        public string contact { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateTimeStamp { get; set; }

        public bool cancelled { get; set; }
    }
    public enum Cgender
    {
        Male,
        Female
    }
}