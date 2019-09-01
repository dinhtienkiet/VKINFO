using System;
using System.Collections.Generic;
using System.Text;

namespace VKINFO.DOMAIN.Entities
{
    public class User
    {
        public int Id { get; set; } // Id (Primary key)
        public string Username { get; set; } // Username (length: 50)
        public string Password { get; set; } // Password (length: 64)
        public int Role { get; set; } // Role
        public int Status { get; set; } // Status
        public DateTime DateCreated { get; set; } // DateCreated
        public DateTime DateModified { get; set; } // DateModified

        public User()
        {
            Status = 1;
            DateCreated = DateTime.Now;
            DateModified = DateCreated;
        }
    }
}
