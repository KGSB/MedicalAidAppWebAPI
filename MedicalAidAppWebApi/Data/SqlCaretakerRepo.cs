using MedicalAidAppWebApi.Data.Interfaces;
using MedicalAidAppWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalAidAppWebApi.Data
{
    public class SqlCaretakerRepo : ICaretakerRepo
    {
        private readonly MedicalDBContext _context;

        public SqlCaretakerRepo(MedicalDBContext context)
        {
            _context = context;
        }

        public void CreateCaretaker(Caretaker caretaker)
        {
            _context.Caretaker.Add(caretaker);
        }

        public Caretaker GetCaretakerInfo(string email) => _context.Caretaker.FirstOrDefault(c => c.Email == email);

        public bool SaveChanges() => _context.SaveChanges() >= 0;
    }
}
