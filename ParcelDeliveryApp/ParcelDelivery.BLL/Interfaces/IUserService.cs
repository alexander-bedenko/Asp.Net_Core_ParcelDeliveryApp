using System.Threading.Tasks;
using ParcelDelivery.BLL.Dtos;

namespace ParcelDelivery.BLL.Interfaces
{
    public interface IUserService
    {
        UserDto AutheticateUser(string login, string password);
        UserDto FindUser(string login);
        Task RegisterUser(UserDto userDto);
        void EditUser(UserDto userDto);
        void DeleteUser(UserDto userDto);
    }
}