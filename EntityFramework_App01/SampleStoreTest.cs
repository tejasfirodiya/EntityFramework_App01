using EntityFramework_App01.DataAccess;
using EntityFramework_App01.DataAccess.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework_App01;

internal class SampleStoreTest
{
    /*
    1. create model class = this should match with the structure of the table
    2. Create Context class inheriting from DbContext
    3. provide the connection string in context class in OnConfiguring
    4. Create DbSet in context class, the datatype of the DbSet should be one of the models created
    */

    public void Select()
    {
        using (var Context = new SampleStoreContext())
        {
            var persons = Context.Persons.ToList();

            Console.WriteLine("---------------Person------------------");
            foreach (var person in persons)
            {
                Console.WriteLine($"{person.person_Id}, {person.first_Name}, {person.last_Name}, {person.dob}");
            }
            Console.WriteLine("---------------------------------------");
        }
    }

    public void Add()
    {
        var context = new SampleStoreContext();
        var person = new Person
        {
            first_Name = "Tejas",
            last_Name = "Firodiya",
            dob = new DateTime(2000, 06, 26)
        };

        context.Persons.Add(person);
        context.SaveChanges();

        context.Dispose();
    }

    public void Delete()
    {
        Console.WriteLine("Enter the person Id to be deleted ");
        var personIdText = Console.ReadLine();
        var personIdToBeDeleted = int.Parse(personIdText);

        using var context = new SampleStoreContext();

        var person = context.Persons.FirstOrDefault(xyz => xyz.person_Id == personIdToBeDeleted);

        if (person == null)
        {
            Console.WriteLine($"Person with id = {personIdToBeDeleted} not found");
            return;
        }

        context.Persons.Remove(person);
        context.SaveChanges();

        context.Dispose();
    }

    public void Update()
    {
        Console.WriteLine("Enter the person Id to be updated ");
        var personIdText = Console.ReadLine();
        var personIdToBeUpdated = int.Parse(personIdText);

        using var context = new SampleStoreContext();

        var person = context.Persons.FirstOrDefault(xyz => xyz.person_Id == personIdToBeUpdated);

        if (person == null)
        {
            Console.WriteLine($"Person with id = {personIdToBeUpdated} not found");
            return;
        }

        person.first_Name = person.first_Name + "00";
        person.last_Name = person.last_Name + "00";
        person.dob = DateTime.Now;

        context.Persons.Update(person);
        context.SaveChanges();
    }

    public void SelectWithSP()
    {
        var sqlParameterPersonId = new SqlParameter("@person_id", System.Data.SqlDbType.Int);
        sqlParameterPersonId.Value = 0;

        using var context = new SampleStoreContext();
        var person = context.Persons.FromSqlRaw("dbo.GetAllPersons @person_id", sqlParameterPersonId);

        Console.WriteLine("-----------Person-----------");
        foreach(var p in person)
        {
            Console.WriteLine($"{p.person_Id}, {p.first_Name}, {p.last_Name}, {p.dob}");
        }
        Console.WriteLine("----------------------------");
    }

    //[GetBrandProductInfo]

    public void SelectWithCustomEntity()
    {
        //@minPrice
        var sqlParameterMinPrice = new SqlParameter("@minPrice", System.Data.SqlDbType.Decimal);
        sqlParameterMinPrice.Value = 400;

        using var context = new SampleStoreContext();
        var products = context.Set<BrandProductInfoResult>().FromSqlRaw("dbo.GetBrandProductInfo @minPrice", sqlParameterMinPrice).ToList();

        Console.WriteLine("-----------Person-----------");
        foreach (var p in products)
        {
            Console.WriteLine($"{p.product_id},{p.product_name}, {p.brand_name}, {p.category_name}, {p.list_price}");
        }
        Console.WriteLine("----------------------------");

    }

    public void SelectRelatedData()
    {
        using var context = new SampleStoreContext();

        //select * from products
        var product1 = context.Products.ToList();

        //select product_id from product
        var product2 = context.Products.Select(p => p.product_id).ToList();

        //select * from product where brand_id = 5
        var product3 = context.Products.Where(p => p.brand_id == 5).ToList();

        //select * from product order by category id
        var product4 = context.Products.OrderBy(p => p.category_id).ToList();




        var products = context.Products.Include("brand").Include("categories").ToList();

        Console.WriteLine("-----------Person-----------");
        foreach (var p in products)
        {
            Console.WriteLine($"{p.product_name}, {p.brand_id}, {p.brand.brand_id}, {p.categories.category_name}");
        }
        Console.WriteLine("----------------------------");

    }
}




