using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace it.core.Examples.Configuration.it
{
    //#generated code (?)

    [NeedsTest(
        "shouldCreateAppConfigKeysForAllNewSettings",
        "shouldCreateConstantsForAllSettingsKeys")]
    [NeedsService]
    public class Configuration : It<Configuration>
    {
        private Dictionary<string, object> Settings { get; set; }

        public T Get<T>(string key, string section = null, T defaultValue = default(T))
        {
            var id = IT.Id;
            Debug.WriteLine("tasst");
            Trace.TraceInformation("Configuration instance has id " + Id);
            Trace.TraceInformation("Configuration instance reports singleton It.Instance Id of " + id);

            base.Load();
            this.Load();
            IT.Load();

            return default(T);
        }

        public override async Task Save()
        {
            throw new NotImplementedException();
        }

        public override async Task<bool> CanSave()
        {
            return true; // could be based on some logic
        }
    }
}
