using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace it.core.Examples.Configuration
{
    partial class AppSettings : it.Configuration
    {
        private AppSettings()
        {
            It<it.Configuration>.IT.Load();
        }

        public async Task CreateNew(string settingName, string settingSection, object settingDefault)
        {
            It<it.Configuration>.IT.NewObject(); // this would be the scripty code to generate more settings in the partial
            // or rosilyn hot loading mod'd libraries
        }

    }
}
