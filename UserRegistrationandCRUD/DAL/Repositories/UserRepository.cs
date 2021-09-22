using AutoMapper;
using Core.Entities;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public UserRepository(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> Delete(int userId)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == userId);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return user.Id;
            }

            return 0;
        }

        public async Task<List<UserCore>> Get()
        {
            var users = await _context.Users.ToListAsync();
            if (users != null)
            {
                var userscore = _mapper.Map<List<Core.Entities.UserCore>>(users);

                return userscore;
            }


            return null;
        }

        public async Task<UserCore> Get(int userid)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userid);
            if (user != null)
            {
                

                var usercore = _mapper.Map<Core.Entities.UserCore>(user);
                return usercore;
            }

            return null;

        }

        public async Task<int> Update(UserCore user)
        {
            var userentity = _mapper.Map<DAL.Entities.UserDB>(user);
            var userforupdate = await _context.Users.FirstOrDefaultAsync(x=>x.Id == user.Id);
            if (userforupdate != null)
            {
                userforupdate.FirstName = userentity.FirstName;
                await _context.SaveChangesAsync();
                return userforupdate.Id;
            };
            return 0;
        }

    }
}
