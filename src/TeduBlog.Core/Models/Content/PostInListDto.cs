using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeduBlog.Core.Models.Content
{
    public class PostInListDto
    {
        public Guid Id { get; set; }

        public required string Name { get; set; }

        public required string Slug { get; set; }

        public string? Description { get; set; }

        public string? Thumbnail { get; set; }

        public int ViewCount { get; set; }

        public DateTime DateCreated { get; set; }

        public class AutoMapperProfile : AutoMapper.Profile
        {
            public AutoMapperProfile()
            {
                CreateMap<Domain.Content.Post, PostInListDto>();
            }
        }
    }
}
