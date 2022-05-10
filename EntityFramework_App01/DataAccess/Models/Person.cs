using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework_App01.DataAccess.Models;

//[Table("persons", Schema = "dbo")]

internal class Person
{

    [Key]
    //variables_names / properties exactly same as person table variables / column_names in entity framework core       
    public int person_Id { get; set; }
    public string first_Name { get; set; }
    public string last_Name { get; set; }
    public DateTime dob { get; set; }
}
