using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeetApp.ViewModels;
using Windows.Storage;

namespace FeatureTest.PageObjects
{
    public class MainPageObject
    {
        MainPageViewModel mainVM;

        public bool IsApiKeyStored
        {
            get { return !String.IsNullOrWhiteSpace(mainVM.ApiKey); }
        }

        public void Open(bool isApiKeyStored)
        {
            var localSettings = ApplicationData.Current.LocalSettings;
            localSettings.CreateContainer("AppSettings", ApplicationDataCreateDisposition.Always);
            if (isApiKeyStored)
            {
                localSettings.Containers["AppSettings"].Values["ApiKey"] = "ThisIsTheApiKey";
            }
            mainVM = new MainPageViewModel();
            mainVM.Init();
        }
    }
}
