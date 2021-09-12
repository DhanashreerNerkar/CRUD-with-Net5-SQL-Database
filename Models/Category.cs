using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreApp2.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        
        [DisplayName("Category")]
        [Required]
        public string CategoryName{ get; set; }
        
    }
}
