using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryMangment.Models
{
    public class BookViewModel
    {
        public int Book_ID { get; set; }
        public string Book_Name { get; set; }
        public string Author { get; set; }
        public bool Options { get; set; }
    }
}