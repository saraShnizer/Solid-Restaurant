
using Restaurant.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Services
{
    public interface IDoseService
    {
         Dose AddDose(Dose Dose);
         void DeleteDose(int id);
         IEnumerable<Dose> GetDoses();
         Dose GetById(int id);
         Dose UpdateDose(int id, Dose Dose);
    }
}
