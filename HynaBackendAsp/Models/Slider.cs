using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HynaBackendAsp.Models
{
    public class Slider
    {
        public int Id { get; set; }

        public string Tittle { get; set; }

        public string Slogan { get; set; }

        public string More_url { get; set; }

        public string More_text { get; set; }



    }
}