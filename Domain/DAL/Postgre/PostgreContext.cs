using Domain.Core.DAL.Map;
using Domain.DAL.Postgre;
using Domain.Entities;
using Domain.Entities.Abstract;
using Domain.Services.Interfaces;
using Domain.Specifications;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Core.DAL
{

    public class PostgreContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        private readonly string _connectionString = "";
        public static readonly LoggerFactory _loggerFactory = new LoggerFactory(new[] { new DebugLoggerProvider() });

        public virtual DbSet<Filiation> Filiations { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Pupil> Pupils { get; set; }

        ///// <summary>
        ///// not to use
        ///// for testing purposes only.
        ///// </summary>
        //public PostgreContext()
        //{
        //}

        public PostgreContext(DbContextOptions<PostgreContext> options, IOptions<OperationalStoreOptions> operationalStoreOptions, ILoggingService loggingService)
            : base(options, operationalStoreOptions)
        {
            try
            {
                if (Database.GetService<IRelationalDatabaseCreator>().Exists())
                {
                    Database.Migrate();
                }
            }
            catch (Exception e)
            {
                loggingService.Error(e);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new FiliationMap());
            modelBuilder.ApplyConfiguration(new GroupMap());
            modelBuilder.ApplyConfiguration(new PupilMap());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLoggerFactory(_loggerFactory)
                              .UseNpgsql(this._connectionString)
                              .ReplaceService<IHistoryRepository, PostgreHistoryRepository>();
            }
        }

        public IQueryable<T> GetBySpecification<T>(Specification<T> specification) where T : class
        {
            if (specification == null) return new List<T>().AsQueryable();

            return this.Set<T>().Where(specification);
        }

        public void InsertOrUpdate<T>(T entity) where T : class, IEntity
        {
            if (entity == null) return;

            if (entity.ID == 0)
            {
                this.Set<T>().Add(entity);
            }
            else
            {
                this.Set<T>().Attach(entity);
                this.Entry<T>(entity).State = EntityState.Modified;
            }
        }
    }
}