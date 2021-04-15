using DAL;
using Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL

{
    public class UserService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Ticket> _repositoryTicket;

        public UserService(IRepository<User> userRepository, IRepository<Ticket> repositoryTicket)
        {
            _repositoryTicket = repositoryTicket;
            _userRepository = userRepository;
        }

        public async Task<User> Registration(string login, string password, string fio, string mail, int age)
        {
            User user = new User()
            {
                Login = login,
                Password = password,
                FullName = fio,
                Mail = mail,
                Role = "User",
                Age = age,
            };
            return await _userRepository.Create(user);
        }
        public User Login(string login, string password)
        {
            return _userRepository.Read().First(u => u.Login == login && u.Password == password);
        }

        public IEnumerable<User> GetUsers()
        {
            return _userRepository.Read();
        }

        public async Task<User> GetUserById(int id) => await _userRepository.GetById(id);

        public IEnumerable<Ticket> GetUserTicket(int id)
        {
            return _repositoryTicket.Read().Where(t => t.User.Id == id);
        }
    }
}
