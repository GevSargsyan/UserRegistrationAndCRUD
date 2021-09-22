using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class Context : IdentityDbContext<UserDB,UserRole,int>
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
           
        }

    }
}
