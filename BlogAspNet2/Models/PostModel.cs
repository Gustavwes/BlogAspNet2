using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAspNet2.Models
{
    public class PostModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Post { get; set; }
        public DateTime? Datetime { get; set; }
        public int? FkCategoryId { get; set; }

        public CategoryModel FkCategory { get; set; }
    }
}
