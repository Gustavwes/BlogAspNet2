using System;
using System.Collections.Generic;

namespace BlogAspNet2.Models
{
    public partial class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Post1 { get; set; }
        public DateTime? Datetime { get; set; }
        public int? FkCategoryId { get; set; }

        public Category FkCategory { get; set; }
    }
}
