using System;
using System.Threading.Tasks;
using it.core.Examples.Interfaces;
using it.core.Examples.Repositories;
using it.core.Examples.Services;
using it.core.Interfaces;

namespace it.core.Examples.Entities
{
    public class AppUserDto : ADtoFor<AppUser> { }

    public class AppUser : DataContextBase<AppUser>, IPerson, IGetStored<AppUser>, INeedService<AppUser>
    {
        public AppUser() { }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        
        public int SecurityLevel { get; set; }
        public bool Confirmed { get; set; }

        public override async Task<bool> CanSave() => true;

        public async Task Save()
        {
            if (! await CanSave().ConfigureAwait(false)) return;

            var svc = IT.GetService<AppUserService>(GetDataContext());
            await svc.SaveAppUser(this).ConfigureAwait(false);

            // put into permanent storage
            // notify any watchers
            // log
            throw new NotImplementedException();
        }

        public override ARepositoryOf<AppUser> Repository => new AppUsersRepository(GetDataContext());

        public override AServiceFor<AppUser> Service => IT.GetService<AppUserService>();
    }
}