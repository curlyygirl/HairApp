﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace HairApp.Models
{
    public class DB_Entities : DbContext
    {
        public DB_Entities() : base("DatabaseHairApp") { }
        public DbSet<User> Users { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Wash> Washes { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Quiz>().ToTable("Quizzes");
            modelBuilder.Entity<Ingredient>().ToTable("Ingredients");
            modelBuilder.Entity<Wash>().ToTable("Washes");
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}