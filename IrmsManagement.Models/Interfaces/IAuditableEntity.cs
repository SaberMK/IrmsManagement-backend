using System;
using System.Collections.Generic;
using System.Text;

namespace IrmsManagement.Models.Interfaces
{
    public interface IAuditableEntity
    {
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
