using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserRegistrationandCRUD.Core.Entities;

namespace Core.Repositories
{
   public interface IUserRepository
    {
        Task<int> Update(UserUpdate user);
        Task<int> Delete(int userId);
        Task<List<UserCore>> Get();
        Task<UserCore> Get(int userId);

    }
}
