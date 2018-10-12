using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using it.core.Examples.Entities;
using it.core.Examples.Repositories;

// ReSharper disable AsyncConverter.AsyncMethodNamingHighlighting

namespace it.core.Examples.Services
{

    // that's right bitch, who needs DI when your services are static and indempotent
    // but then they're unmockable #sadpanda
    public static class AppUserServiceExtensions
    {
        public static bool CanEditType(this It<AppUser> entity)
        {
            // wait what is a It<AppUser> ? a way to edit AppUser on the fly?
            throw new NotImplementedException();
        }

        public static async Task<bool> DidCreateNew(this AppUser entity)
        {
            var result = await entity.GetService<AppUserService>().Create(entity).ConfigureAwait(false);
            var user = entity.Repository.Get().FirstOrDefault(u => u.FullName == entity.FullName);

            return user != null && user.Id == entity.Id;
        }
    }

    public class AppUserService : AServiceFor<AppUser>
    {
        private readonly AppUsersRepository _repository = Repository as AppUsersRepository;

        public override Task<bool> CanSave()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Create(AppUser entity)
        {
            _repository.Add(entity);
            return true;
        }

        public IEnumerable<AppUser> GetSuperAdmins()
        {
            return _repository.GetAll().Where(u => u.SecurityLevel > 1024).ToList();
        }

        public Task SaveAppUser(AppUser appUser)
        {
            _repository.Add(appUser);

            return Task.CompletedTask;
        }
    }
}