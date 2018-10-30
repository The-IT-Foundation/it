using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using it.core.Examples.Interfaces;
using it.core.Examples.Repositories;
using it.core.Examples.Services;
using it.core.Interfaces;

namespace it.core.Examples.Entities
{
    public abstract class HasAccessTo<T> : IHaveAccessTo<AppUser> where T : It<T>, IAmAnEntity, new()
    {
        public AppUser ThisEntity { get; set; }
    }

    public class AppUserDto : HasAccessTo<AppUser>, IAmADtoFor<AppUser>
    {
        public AppUser RootEntity => base.ThisEntity;

        public string UserSalutation;

        internal void SampleProc()
        {
            Trace.WriteLine("User prefers to be addressed as " + UserSalutation);
        }

        // map to|from viewModels or data models (or export models/contracts)
        public AppUserProfilePageViewModel AppUserProfilePageViewModel { get; set; }
    }

    public class AppUserProfilePageViewModel : AppUserDto
    {
        public string[] SalutationSelectionDropDownValues = {"Mrs.", "Mr.", "Dr.", "Yo.", "N/A"}; 

        [DisplayName("Your First Name")] // language
        public string FirstName { get; set; }
    }

    public class AppUser : DataContextBase<AppUser>, IAmAnEntity, IPerson, IGetStored<AppUser>, INeedService<AppUser>
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