using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrabajoGrupal.Models
{
    public class ClsUser
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}