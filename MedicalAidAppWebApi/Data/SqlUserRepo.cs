using MedicalAidAppWebApi.Data.Interfaces;
using MedicalAidAppWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalAidAppWebApi.Data
{
    public class SqlUserRepo : IUserRepo
    {
        private readonly MedicalDBContext _context;

        public SqlUserRepo(MedicalDBContext context)
        {
            _context = context;
        }

        public void CreateUser(User user)
        {
            _context.User.Add(user);
        }

        public User GetUserInfo(string email) => _context.User.FirstOrDefault(u => u.Email == email);       

        public bool SaveChanges() => _context.SaveChanges() >= 0;
    }
}
