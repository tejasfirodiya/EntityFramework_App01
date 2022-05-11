using EntityFramework_App01.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework_App01.DataAccess;

//DbContext : class used to manage database connection 

internal class SampleStoreContext : DbContext
{
    //DbContext chya aat DbSet asto

    //DbSet is object representation of table
    //For every table there is one DbSet
    public DbSet<Person> Persons { get; set; }
    public DbSet<BrandProductInfoResult> brandInfo { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Brands> brands { get; set; }
    public DbSet<Categories> categories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=WAIANGDESK14\MSSQLSERVER01;Initial Catalog=SampleStore;Integrated Security=True");
    }
}
