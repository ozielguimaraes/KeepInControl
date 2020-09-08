using KeepInControl.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace KeepInControl.Services
{
    sealed class UserService : IUserService
    {
        private const string UserIsLogged = "UserIsLogged";
        public async Task AutenticateAsync(string userName, string password)
        {
            await SecureStorage.SetAsync(UserIsLogged, "true");
        }

        public async Task<bool> IsLoggedAsync()
        {
            bool.TryParse(await SecureStorage.GetAsync(UserIsLogged), out bool isLogged);

            return isLogged;
        }
    }
}