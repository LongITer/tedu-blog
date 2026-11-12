using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeduBlog.Core.Models.Auth
{
    public class AuthenticatedResult
    {
        public required string token { get; set; }
        public required string refreshToken { get; set; }
    }
}
