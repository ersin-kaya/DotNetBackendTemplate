using System;
namespace DotNetBackendTemplate.Core.Entities.Concrete
{
    public class Account : IEntity
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public int StatusId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public string PhoneNumber { get; set; }
        public string ProfilePhotoPath { get; set; }
    }
}

