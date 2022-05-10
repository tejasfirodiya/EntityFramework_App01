using EntityFramework_App01.DataAccess;
using EntityFramework_App01.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework_App01
{
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
    }
}




