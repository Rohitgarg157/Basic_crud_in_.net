using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace crud_demo.Models
{
    public class Country
    {
        [Key]
        public int id { get; set; }
        public string? name { get; set; }
        public string? isocode { get; set; }
        public string? isdcode { get; set;}

    }
}
