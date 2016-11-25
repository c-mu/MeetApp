using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeetApp.ViewModels;

namespace FeatureTest.PageObjects
{
    public class LoginPageObject
    {
        public void ChooseToStoreApiKey(bool storeApiKey)
        {

        }
        
        public string GetTheApiKey(string username, string password)
        {
            var loginVM = new LoginViewModel();
            return loginVM.ApiKey;
        }

    }
}
