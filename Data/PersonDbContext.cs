using System.Collections.Generic;
using System.Reflection.Emit;
using System;
using Microsoft.EntityFrameworkCore;
using PersoModels;

namespace Labb3APIv2.Data
{
    public class PersonDbConxtext : DbContext
    {
        public PersonDbConxtext(DbContextOptions<PersonDbConxtext> options) : base(options) { }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<Interest> Interests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>().HasData(new Person
            {
                PersonId = 1,
                FirstName = "Bob",
                LastName = "Dylan",
                Tel = "1234567",
            
            });
            modelBuilder.Entity<Person>().HasData(new Person
            {
                PersonId = 2,
                FirstName = "Carl",
                LastName = "Larsson",
                Tel = "1234567",
             
            });
            modelBuilder.Entity<Person>().HasData(new Person
            {
                PersonId = 3,
                FirstName = "Karin",
                LastName = "Larsson",
                Tel = "1234567",

            });
            modelBuilder.Entity<Interest>().HasData(new Interest
            {
                InterestId = 1,
                Title = "Music",
                Description = "Playing guitar"
            });
            modelBuilder.Entity<Interest>().HasData(new Interest
            {
                InterestId = 2,
                Title = "Art",
                Description = "Painting"
            });
            modelBuilder.Entity<Interest>().HasData(new Interest
            {
                InterestId = 3,
                Title = "Dance",
                Description = "Waltz"
            });
            modelBuilder.Entity<Link>().HasData(new Link
            {
                LinkId = 1,
                LinkAddress = "https://www.bobdylan.com/"
            });
            modelBuilder.Entity<Link>().HasData(new Link
            {
                LinkId = 2,
                LinkAddress = "https://www.carllarsson.se/"
            });
            modelBuilder.Entity<Link>().HasData(new Link
            {
                LinkId = 3,
                LinkAddress = "https://www.karinforeningen.se/"
            });
        }
    }
}
