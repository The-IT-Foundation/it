using System;
using System.Threading.Tasks;
using it.core.Examples.Entities;

namespace it.core.Examples.Workflows
{

    // example AWorkflow instance
    // this is the kind of class that you would use in a workflow system like https://github.com/Azure/durabletask

    [ExposesSyncSignaturesInApi] // generate SYNCronous API as well (automated, obvs)
    public class UserSignupWorkflow : AWorkflowFor<UserSignupWorkflow>
    {
        private readonly AppUser _user;

        public UserSignupWorkflow(AppUser user)
        {
            _user = user;
        }

        public UserSignupWorkflow()
        {
            throw new NotImplementedException("Can't do much with a user workflow and no user huh");
        }

        public override int Status { get; }

        public bool IsValidUser() => !string.IsNullOrEmpty(_user.FullName);

        public async Task<UserSignupWorkflow> SendEmailConfirmation()
        {
            // do we return this so we can chain?
            return this;
        }

        public static async Task<UserSignupWorkflow> WithA(AppUser user)
        {
            return new UserSignupWorkflow(user);
        }

        public override async Task Save()
        {
            await base.Save();
            await this.SaveState();

            //return Task.CompletedTask;
        }

        private async Task SaveState()
        {
            // save workflow state for resumability
        }

        public override async Task<bool> CanSave() => true;

        public enum ResultStatues
        {
            NewUserSignupSuccess
        }
    }
}