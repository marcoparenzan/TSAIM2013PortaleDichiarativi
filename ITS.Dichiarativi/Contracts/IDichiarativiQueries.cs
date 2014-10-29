using ITS.Dichiarativi.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.Dichiarativi.Contracts
{
    public interface IDichiarativiQueries
    {
        IEnumerable<DichiarativoDTO> GetAll();
    }
}
