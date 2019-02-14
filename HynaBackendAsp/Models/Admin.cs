using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HynaBackendAsp.Models
{
    public class Admin
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [MaxLength(100)]
        public string Password { get; set; }

        public string Fullname { get; set; }
    }
}