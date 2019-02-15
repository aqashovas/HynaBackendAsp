using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HynaBackendAsp.Models
{
    public class Setting
    {
        public int Id { get; set; }

        [Required]
        public string Logo { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string Facebook { get; set; }

        public string Youtube { get; set; }

        public string Instagram { get; set; }

        public string Lat { get; set; }

        public string Lng { get; set; }
    }
}