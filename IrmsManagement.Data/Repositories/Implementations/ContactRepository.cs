using IrmsManagement.Data.Repositories.Base;
using IrmsManagement.Data.Repositories.Interfaces;
using IrmsManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IrmsManagement.Data.Repositories.Implementations
{
    public class ContactRepository : BaseRepository<Contact>, IContactRepository
    {
        public ContactRepository(IrmsManagementDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Contact>> GetContactsAsync()
        {
            return await Table
                .ToListAsync();
        }
    }
}
