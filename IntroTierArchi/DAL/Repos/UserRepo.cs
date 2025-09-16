using DAL.EF;
using DAL.EF.Tables;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class UserRepo : IRepo<User, int, bool>,IAuth
    {
        UMSContext db;
        public UserRepo() {
            db = new UMSContext();
        }
        public User Authenticate(string uname, string pass)
        {
            var user = (from u in db.Users
                        where u.Uname.Equals(uname) &&
                        u.Password.Equals(pass)
                        select u).SingleOrDefault();

            return user;
        }

        public bool Create(User obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> Get()
        {
            throw new NotImplementedException();
        }

        public User Get(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(User obj)
        {
            throw new NotImplementedException();
        }
    }
}
