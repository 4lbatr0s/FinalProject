
using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    //Contexts help us to connect database to our entities.
    public class NorthwindContext: DbContext 
    {
        //abstract method.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) //this method decides to what database our project is based on.
        {
            //  @ helps visual studio to understand "\" as "\", otherwise we should use "\\" instead of "\". Because "\" has a syntatic meaning in C#
           optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Northwind;Trusted_Connection=true");


        }

        //we've declared which database are we going to use above, 
        //now it's time to declare which class object is equal to which db object. 
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set;}
        public DbSet<OperationClaim> OperationClaims { get; set;  }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

    }
}
