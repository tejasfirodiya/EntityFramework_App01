using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework_App01.DataAccess.Models
{
    [Table("brands", Schema = "production")]

    internal class Brands
    {
        [Key]
        public int brand_id { get; set; }
        public string brand_name { get; set; }
    }
}
