using eKabita.Repsitories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKabita.Repsitories.Configuration
{
    public interface IUnitOfWork
    {
        IPoemRepository Poem { get; }
        ILikeRepository Like { get; }
        Task Save();
    }
}
