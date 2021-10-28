using ITManager.Domain.Entities;
using ITManager.Domain.Repositories;
using ITManager.Repositories.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITManager.Repositories
{
    public class UserRepository : CrudRepository<User>, IUserRepository
    {
        public UserRepository(ITManagerDbContext context) : base(context)
        {
        }
    }
}
