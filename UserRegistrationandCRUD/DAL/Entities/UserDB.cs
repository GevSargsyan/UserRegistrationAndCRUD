using Microsoft.AspNetCore.Identity;

namespace DAL.Entities
{
    public class UserDB : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age{ get; set; }
    }
}
