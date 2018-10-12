using System;
using System.Diagnostics;
using System.Threading.Tasks;
using it.core.Attributes;

// ReSharper disable AsyncConverter.AsyncMethodNamingHighlighting

namespace it.core
{
    public interface IAmIt
    {
        Guid Id { get; set; }

        Task<bool> CanSave();

        Task Save();
        Task Load();

        
    }

    public abstract class It<T> : IAmIt where T : It<T>, new()
    {
        protected It()
        {
            Initialize();
        }

        private async void Initialize()
        {
            Trace.TraceInformation("it has been initialized");
        }

        static It() { IT.Load(); }
        
        public static T IT { get; } = new T();

        public Guid Id { get; set; } = Guid.NewGuid();


        
        // if we;re going to use traditional mockable DI let's at least have a helper
        public TService GetService<TService>(params object[] dependsOn) where TService : AServiceFor<T>, new()
        {
            var svc = new TService();
            return svc;
        }

        public async Task Load()
        {
            // load it from storage

            Trace.TraceInformation("abstract Load() shows instance id of "+Id);
        }

        public virtual Task Save()
        {
            throw new NotImplementedException();
        }

        public abstract Task<bool> CanSave();

        /// <summary>
        /// Create a new It based object
        /// runs magic to scaffold your obj for you, complete with service + repo (if necessary?)
        /// </summary>
        public void NewObject() { }
    }

    public static partial class Extensions
    {
        [ListensForCancellationToken]
        public static async Task<bool> TrySaveAsync<T>(this T obj) where T : IAmIt
        {
            try
            {
                if (await obj.CanSave())
                    await obj.Save();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

            return true;
        }

    }

    public static class AWorkflowService
    {

    }

    public class ExposesSyncSignaturesInApiAttribute : Attribute
    {
    }

    public class NeedsTestAttribute : Attribute
    {
        private string[] v;

        public NeedsTestAttribute(params string[] v)
        {
            this.v = v;
        }
    }

    public class NeedsServiceAttribute : Attribute
    {
    }

    internal interface IConfiguration
    {
        T Get<T>(string key, string section = null);
    }
}
