using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HynaBackendAsp.Models
{
    public class Author
    {
        public int Id { get; set; }

        public string Fullname { get; set; }

        public string Position { get; set; }

        public string Photo { get; set; }

        public string Desc { get; set; }

        public List<Blog> Blogs { get; set; }


    }
}