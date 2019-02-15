using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HynaBackendAsp.Models
{
    public class Blog
    {
        public int Id { get; set; }

        [Required]
        public string Tittle { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [MinLength(100)]
        public string Desc { get; set; }

        public string Photo { get; set; }

        [Column(name:"ntext")]
        public string Text { get; set; }

        public int CategoryId { get; set; }

        public int AuthorId { get; set; }

        public Author Author { get; set; }

        public Category Category { get; set; }


    }
}