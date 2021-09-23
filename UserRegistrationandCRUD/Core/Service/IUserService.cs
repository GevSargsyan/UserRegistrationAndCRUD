using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserRegistrationandCRUD.Core.Entities;

namespace Core.Service
{
    public interface IUserService
    {
        Task<int> Delete(int userId);
        Task<UserCore> Get(int userId);
        Task<List<UserCore>> Get();

        Task<int> Update(UserUpdate user);
    }
}
