using System.Threading.Tasks;

namespace KeepInControl.Services.Interfaces
{
    public interface IUserService
    {
        Task AutenticateAsync(string userName, string password);
        Task<bool> IsLoggedAsync();
    }
}