using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NameAPI.Models
{
    public class NameDetail
    {
        [Key]
        public int NameDatailId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
