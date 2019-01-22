using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace ParcelDelivery.DAL.Entities
{
    public class User : BaseEntity
    {
        public User()
        {
            Carriers = new List<Carrier>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public ICollection<Carrier> Carriers { get; set; }
    }
}
