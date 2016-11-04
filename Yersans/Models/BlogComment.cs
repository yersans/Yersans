using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Yersans.Models
{
    public class BlogComment
    {
        public int BlogCommentId { get; set; }

        public int BlogPostId { get; set; }

        [StringLength(128)]
        public string UserId { get; set; }

        [Required]
        [StringLength(4000)]
        public string CommentText { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual BlogPost BlogPost { get; set; }
    }
}