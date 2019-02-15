using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HynaBackendAsp.Models
{
    public class Fact
    {
        public int Id { get; set; }

        [Required]
        public int Orderby { get; set; }

        [Required]
        public string Key { get; set; }

        [Required]
        public string Value { get; set; }



    }
}