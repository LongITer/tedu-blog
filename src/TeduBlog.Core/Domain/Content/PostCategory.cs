using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeduBlog.Core.Domain.Content
{
    [Table("PostCategories")]
    
    public class PostCategory
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(250)]
        public required string Name { get; set; }

        [Column(TypeName = "varchar(250)")]
        [Index(nameof(Slug), IsUnique = true)]
        public required string Slug { get; set; }

        public Guid? ParentId { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public string? SeoKeywords { get; set; }
        public string? SeoDescription { get; set; }
        public int SortOrder { get; set; }

    }
}
