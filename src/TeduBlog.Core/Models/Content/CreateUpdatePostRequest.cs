using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduBlog.Core.Domain.Content;

namespace TeduBlog.Core.Models.Content
{
    public class CreateUpdatePostRequest
    {
        public Guid CategoryId { get; set; }
        public string? Content { get; set; }
        public string? Source { get; set; }
        public string? Tags { get; set; }
        public string? SeoDescription { get; set; }

        public class AutoMapperProfile : AutoMapper.Profile
        {
            public AutoMapperProfile()
            {
                CreateMap<CreateUpdatePostRequest, Post>();
            }
        }
    }
}
