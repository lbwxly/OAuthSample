using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class User
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public string AvatarUrl { get; set; }
    }
}
