using MedicalAidAppWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalAidAppWebApi.Data.Interfaces
{
    public interface ICaretakerRepo
    {
        bool SaveChanges();
        void CreateCaretaker(Caretaker caretaker);
        Caretaker GetCaretakerInfo(string email);
    }
}
