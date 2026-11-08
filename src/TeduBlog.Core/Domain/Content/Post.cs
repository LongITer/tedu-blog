using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeduBlog.Core.Domain.Content
{
    [Table("Posts")]
    public class Post
    {
        [Key]
        public Guid id { get; set; }
        [Required]
        [MaxLength(255)]
        public required string Name { get; set; }
        [Required]
        [MaxLength(255)]
        [Index(nameof(Slug), IsUnique = true)]
        [Column(TypeName = "varchar(255)")]
        public required string Slug { get; set; }
   
        [MaxLength(500)]
        public string? Description { get; set; }
        public Guid CategoryId { get; set; }
        [MaxLength(255)]
        public string? Thumbnail { get; set; }
        public string? Content { get; set; }
        public Guid AuthorUserId { get; set; }
        public string? Source { get; set; }
        [MaxLength(255)]
        public string? Tags { get; set; }
        public string? SeoDescription { get; set; }
        public int ViewCount { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public bool IsPaid { get; set; }
        public double? RoyaltyAmount { get; set; }
        public PostStatus Status { get; set; }

    }
    public enum PostStatus
    {
        Draft = 1,
        Canceled = 2,
        WaitingForApproval = 3,
        Rejected = 4,
        WaitingForPublish = 5,
        Published = 6,

    }


}
