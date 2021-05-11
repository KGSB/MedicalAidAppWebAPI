using MedicalAidAppWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalAidAppWebApi.Data.Interfaces
{
    public interface IUserRepo
    {
        bool SaveChanges();
        void CreateUser(User user);
        void DeleteUser(string email);
        User GetUserInfo(string email);
    }
}