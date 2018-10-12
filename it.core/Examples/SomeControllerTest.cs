using System.Collections.Generic;
using System.Linq;
using it.core.Examples.Entities;
using it.core.Examples.Repositories;
using it.core.Examples.Services;
using it.core.Examples.Workflows;

namespace it.core.Examples
{
    class SomeControllerTest
    {
        public SomeControllerTest()
        {
            Initialize();
        }

        private async void Initialize()
        {

            //var userFlow = new UserSignupWorkflow();
            var users = new AppUsersRepository(new List<AppUser> { new AppUser { FirstName = "Bahb", LastName = "Lahblahb", SecurityLevel = 2048 } });
            var service = AppUser.IT.GetService<AppUserService>();
            var service2 = users.GetService<AppUserService>();
            var service3 = new AppUser().Service;
            var user = service.GetSuperAdmins().First();
            var newUser = new AppUser() { FirstName = "nope" };

            // you should be able to use the api in static or obj ways like
            // actually after having seen it i don't like the static way, lots of typing
            var resultStatic = UserSignupWorkflow.WithA(newUser).Result.SendEmailConfirmation();
            var resultObj = new UserSignupWorkflow(newUser).SendEmailConfirmation();

            var workflow = new UserSignupWorkflow(newUser);
            var otherWorkflow = UserSignupWorkflow.WithA(newUser);
            var userResult = await newUser.DidCreateNew();
            var success = workflow.SendEmailConfirmation().Result
                .Then().Result
                .WaitFor(newUser.Confirmed == true).Result
                .Then().Result
                .Emit(UserSignupWorkflow.ResultStatues.NewUserSignupSuccess).Result
                .SendPersonalizedWelcomeChatMessageInApp();

            // the Emit() feature (abstract parent) allows push and status change on the webhook (these are features of durabletasks)

        }
    }
}