
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using CoronaTest.Persistence.Repositories;
using CoronaTest.Core.Contracts;

namespace CoronaTest.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ApplicationDbContext _dbContext;
        private bool _disposed;

        public IVerificationTokenRepository VerificationTokens { get; private set; }

        public UnitOfWork() : this(new ApplicationDbContext())
        {

        }

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

            VerificationTokens = new TokenVerificationRepository(_dbContext);
        }

        public async Task<int> SaveChangesAsync()
        {
            var entities = _dbContext.ChangeTracker.Entries()
                .Where(entity => entity.State == EntityState.Added
                                                    || entity.State == EntityState.Modified)
                .Select(e => e.Entity);
            foreach (var entity in entities)
            {
                /*await*/
                ValidateEntity(entity);
            }
            return await _dbContext.SaveChangesAsync();
        }

        private /*async Task*/ void ValidateEntity(object entity)
        {
            /*if(entity is Participant participant)
            {
                if(await _dbContext.Participant.AnyAsync(p => p.Id != participant.Id && p.SocialSecurityNumber == participant.SocialSecurityNumber))
                {
                    throw new ValidationException($"Eine Person mit der Sozialversicherungsnummer {participant.SocialSecurityNumber} ist bereits registriert.");
                }
            }*/
        }

        public async Task DeleteDatabaseAsync() => await _dbContext.Database.EnsureDeletedAsync();
        public async Task MigrateDatabaseAsync() => await _dbContext.Database.MigrateAsync();
        public async Task CreateDatabaseAsync() => await _dbContext.Database.EnsureCreatedAsync();

        public async ValueTask DisposeAsync()
        {
            await DisposeAsync();
            GC.SuppressFinalize(this);
        }

        protected virtual async ValueTask DisposeAsync(bool disposing)
        {
            if (!_disposed && disposing)
            {
                await _dbContext.DisposeAsync();
            }
            _disposed = true;
        }
    }
}
