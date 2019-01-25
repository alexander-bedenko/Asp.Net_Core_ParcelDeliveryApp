using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ParcelDelivery.BLL.Dtos;
using ParcelDelivery.BLL.Interfaces;
using ParcelDelivery.BLL.Providers;
using ParcelDelivery.DAL.Entities;
using ParcelDelivery.DAL.Interfaces;

namespace ParcelDelivery.BLL.Services
{
    public class UserService : BaseService, IUserService
    {
        public UserService(IUnitOfWork uow)
            : base(uow)
        {
        }

        public UserDto AutheticateUser(string login, string password)
        {
            var user = _uow.Repository<User>().GetAll(x => x.Login == login).FirstOrDefault();
            while (true)
            {
                if (IsUserValid(user, password))
                    break;
                return null;
            }

            return Mapper.Map<UserDto>(user);
        }

        public UserDto FindUser(string login)
        {
            var user = _uow.Repository<User>().GetAll(u => u.Login == login).FirstOrDefault();
            return Mapper.Map<User, UserDto>(user);
        }

        public async Task RegisterUser(UserDto userDto)
        {
            userDto.Password = HashProvider.Hash(userDto.Password);
            var regUser = Mapper.Map<User>(userDto);
            await _uow.Repository<User>().Create(regUser);
            await _uow.Commit();
        }

        public void EditUser(UserDto userDto)
        {
            var user = _uow.Repository<User>().GetAll(u => u.Login == userDto.Login).FirstOrDefault();

            if (user != null)
            {
                user.FirstName = userDto.FirstName;
                user.LastName = userDto.LastName;
                user.Password = HashProvider.Hash(userDto.Password);
                user.Email = userDto.Email;

                _uow.Repository<User>().UpdateAsync(user);
            }

            _uow.Commit();
        }

        public void DeleteUser(UserDto userDto)
        {
            var user = _uow.Repository<User>().GetAll(u => u.Login == userDto.Login).FirstOrDefault();

            _uow.Repository<User>().DeleteAsync(user);
            _uow.Commit();
        }

        private bool IsUserValid(User user, string password)
        {
            var hashedPassword = HashProvider.Hash(password);
            return user?.Password == hashedPassword;
        }
    }
}
