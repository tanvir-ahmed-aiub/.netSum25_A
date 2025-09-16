using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AuthService
    {
        public static Mapper GetMapper() {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Token,TokenDTO>();
            });
            return new Mapper(config);
        }
        public static TokenDTO Authenticate(string uname, string pass) {
            //pass = MD5(pass);
            var user = DataAccessFactory.AuthData().Authenticate(uname, pass);
            if (user != null) {
                var token = new Token() { 
                    Key = Guid.NewGuid().ToString(),
                    CreatedAt = DateTime.Now,
                    ExpiredAt = null,
                    UserId = user.Id
                };
                var tk =DataAccessFactory.TokenData().Create(token);
                return GetMapper().Map<TokenDTO>(tk);
            }
            return null;
        }
        public static bool IsTokenValid(string tk) {
            var tok = DataAccessFactory.TokenData().Get(tk);
            if (tok != null && tok.ExpiredAt == null) {
                return true;
            }
            return false;


        }
        public static bool IsAdmin(string tk) {
            var tok = DataAccessFactory.TokenData().Get(tk);
            if (tok != null && tok.ExpiredAt == null && tok.User.Type.Equals("Admin"))
            {
                return true;
            }
            return false;
        }
    }
}
