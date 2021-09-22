using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
   public interface IUserRepository
    {
        Task<int> Update(UserCore homework);
        Task<int> Delete(int homeworkId);
        Task<List<UserCore>> Get();
        Task<UserCore> Get(int homeworkId);

    }
}
