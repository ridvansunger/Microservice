﻿using Microservice.Catalog.Api.Features.Categories;
using Microservice.Catalog.Api.Features.Courses;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using System.Reflection;

namespace Microservice.Catalog.Api.Repositories
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {

        public DbSet<Course> Courses { get; set; }
        public DbSet<Category> Categories { get; set; }



        public static AppDbContext Create(IMongoDatabase database)
        {
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<AppDbContext>
                ().UseMongoDB(database.Client,database.DatabaseNamespace.DatabaseName);
            return new AppDbContext(dbContextOptionsBuilder.Options);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());



            base.OnModelCreating(modelBuilder);
        }


    }



}