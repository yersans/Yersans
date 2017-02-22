using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Yersans.Models
{
    public class BlogPost
    {
        public int BlogPostId { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        public string Body { get; set; }

        [StringLength(4000)]
        public string BodyOverview { get; set; }

        public bool AllowComments { get; set; }

        public int CommentCount { get; set; }

        [StringLength(50)]
        public string Tags { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<BlogComment> BlogComment { get; set; }
    }
}