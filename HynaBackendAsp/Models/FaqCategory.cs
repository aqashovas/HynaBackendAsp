using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HynaBackendAsp.Models
{
    public class FaqCategory
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Faq> Faqs { get; set; }
    }
}