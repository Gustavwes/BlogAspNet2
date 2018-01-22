using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAspNet2.Models
{
    public class PostModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is obligatory")]
        [StringLength(50,ErrorMessage = "The title can be at most 50 characters in length.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Each post must have text content.")]
        [StringLength(2000,ErrorMessage = "The post can be max 2000 characters.")]
        public string Post { get; set; }

        public DateTime? Datetime { get; set; }
        public int? FkCategoryId { get; set; }

        public CategoryModel FkCategory { get; set; }
    }
}
