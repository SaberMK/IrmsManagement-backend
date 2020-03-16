using IrmsManagement.Models.Interfaces;
using System;

namespace IrmsManagement.Models
{
    public class Contact : IEntity, IAuditableEntity
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string FullName { get; set; }

        public string PreferredName { get; set; }

        public string Email { get; set; }

        public string MobileNumber { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
