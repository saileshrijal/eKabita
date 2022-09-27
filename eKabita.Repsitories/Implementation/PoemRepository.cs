using eKabita.Data;
using eKabita.Models;
using eKabita.Repsitories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKabita.Repsitories.Implementation
{
    internal class PoemRepository : GenericRepository<Poem>, IPoemRepository
    {
        public PoemRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
