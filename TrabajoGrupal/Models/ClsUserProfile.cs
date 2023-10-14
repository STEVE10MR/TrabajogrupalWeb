using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrabajoGrupal.Models
{
    public class ClsUserProfile
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FullName { get; set; }
        public bool IsPublic { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}