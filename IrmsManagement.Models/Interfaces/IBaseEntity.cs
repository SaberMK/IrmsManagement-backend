using System;
using System.Collections.Generic;
using System.Text;

namespace IrmsManagement.Models.Interfaces
{
    public interface IBaseEntity<TKey> where TKey : struct
    {
        public TKey Id { get; set; }
    }
}
