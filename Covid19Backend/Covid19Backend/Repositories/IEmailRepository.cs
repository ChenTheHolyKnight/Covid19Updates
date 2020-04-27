using Covid19Backend.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19Backend.Repositories
{
    public interface IEmailRepository
    {
        public void AddEmail(string email);
        public List<UserProfile> Get();
        public void Delete(string email);
    }
}
