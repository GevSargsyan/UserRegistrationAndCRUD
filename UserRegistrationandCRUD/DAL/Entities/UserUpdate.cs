using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserRegistrationandCRUD.DAL.Entities
{
    public class UserUpdate
    {
        public int Id { get; set; }
        public string FirstName{ get; set; }
        public string LastName{ get; set; }
        public int Age { get; set; }
    }
}
