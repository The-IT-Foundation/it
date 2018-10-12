using System.Threading;
using System.Threading.Tasks;
using it.core.Examples.Workflows;

namespace it.core
{
    /// <summary>
    /// Create a workflow of type T that simplifies workflow patterns like promises & cancellation
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class AWorkflowFor<T> : It<T> where T : It<T>, new()
    {
        public async Task StartAsync() { }
        
        public abstract int Status { get; }

        public async Task Cancel(Task task, CancellationToken cancellationToken) { }

        // this would be where the offloading of work could/should happen via durabletasks etc
        public async void Do(Task task)
        {
            //todo: omg so much
            task.Start();
        }

        public async Task<AWorkflowFor<T>> Then() => this;

        public async Task<AWorkflowFor<T>> WaitFor() => this;

        public async Task<AWorkflowFor<T>> WaitFor(bool conditionality) => this;

        public async Task<AWorkflowFor<T>> Emit(UserSignupWorkflow.ResultStatues resultStatus) => this;

        public async Task<AWorkflowFor<T>> SendPersonalizedWelcomeChatMessageInApp() => this;
    }
}