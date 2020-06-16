using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookListRazor.Model
{
    public class Book
    {
        // It is going to be a unique key so we can add this 'key' data annotation.
        // It is going to generate automatically an ID.
        [Key]
        public int Id { get; set; }

        // Required means that the annotated property cannot be null.
        [Required]
        public string Name { get; set; }
        public string Author { get; set; }
    }
}
