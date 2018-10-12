using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using it.core.Examples.Entities;
using it.core.Examples.Services;

namespace it.core.Examples.Repositories
{
    public class AppUsersRepository : ARepositoryOf<AppUser>
    {
        // feed it the DBcontext instead
        public AppUsersRepository(List<AppUser> appUsers) : base(appUsers) { }
        public AppUsersRepository() : base(new List<AppUser>()) { }
        
        public IQueryable<AppUser> GetAll() => base.Get();

        public override async Task<bool> CanSave()
        {
            throw new NotImplementedException();
        }


        /* TESTS */
        public static void AppUsersCanBeGotFromService()
        {
            List<AppUser> someUsers = GetTestUsers();
            var svc = IT.GetService<AppUserService>(someUsers); // todo: how inject someUsers (context) into the repo via GetService?
            var supers = svc.GetSuperAdmins();

            if (supers.Count() != 1)
                throw new InvalidOperationException();
        }

        public static void AppUsersCanBeQueriedTest()
        {
            IT.Load();
            List<AppUser> someUsers = GetTestUsers();

            var repo = new AppUsersRepository(someUsers);
            var aUser = repo.FirstOrDefault(u => u.FirstName == "Bob");
            var supers = repo.GetAll().Where(u => u.SecurityLevel > 1024).ToList();

            // Assert..
            if (supers.Count != 1 || supers.Single(u => u.FullName == "Chuck Norris") == null)
                throw new InvalidOperationException();

            if (aUser == null || aUser.FirstName != "Bob")
                throw new InvalidOperationException();

            if (aUser != repo.GetById(aUser.Id))
                throw new InvalidOperationException();
        }

        private static List<AppUser> GetTestUsers()
        {
            return new List<AppUser>
            {
                new AppUser { FirstName = "Bob", LastName = "Blahblah", SecurityLevel = 100 },
                new AppUser { FirstName = "Chuck", LastName = "Norris", SecurityLevel = int.MaxValue }
            };
        }
    }
}