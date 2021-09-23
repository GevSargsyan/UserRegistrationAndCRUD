using Core.Entities;
using Core.Repositories;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserRegistrationandCRUD.BusinessLogic.Entities;

namespace BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public async Task<int> Delete(int userid)
        {
            if (userid == default(int))
            {
                throw new ArgumentException(nameof(userid));
            }

            return await _userRepository.Delete(userid);
        }

        public async Task<UserCore> Get(int userid)
        {
           

            return await _userRepository.Get(userid);
        }

        public async Task<List<UserCore>> Get()
        {
            return await _userRepository.Get();
        }


        public async Task<int> Update(UserRegistrationandCRUD.Core.Entities.UserUpdate userCore)
        {
            return await _userRepository.Update(userCore);
        }
    }
}
