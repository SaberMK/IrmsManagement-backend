using IrmsManagement.Data.Repositories.Base;
using IrmsManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IrmsManagement.Data.Repositories.Interfaces
{
    public interface IContactRepository : IBaseRepository<Contact>
    {
        Task<IEnumerable<Contact>> GetContactsAsync();
    }
}
