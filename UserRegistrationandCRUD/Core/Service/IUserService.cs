using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IUserService
    {
        Task<int> Delete(int homeworkId);
        Task<UserCore> Get(int homeworkId);
        Task<List<UserCore>> Get();

        Task<int> Update(UserCore homework);
    }
}
