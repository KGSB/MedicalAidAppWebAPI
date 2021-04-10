using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalAidAppWebApi.Data.Interfaces
{
    public interface IConnectionRequestRepo
    {
        ICollection<Tuple<string, string>> GetConnectionRequests(string email);
    }
}
