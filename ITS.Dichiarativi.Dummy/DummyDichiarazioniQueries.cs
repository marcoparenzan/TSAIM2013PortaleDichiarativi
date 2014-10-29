using ITS.Dichiarativi.Contracts;
using ITS.Dichiarativi.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.Dichiarativi.Dummy
{
    public class DummyDichiarazioniQueries: IDichiarativiQueries
    {
        IEnumerable<DTOs.DichiarativoDTO> IDichiarativiQueries.GetAll()
        {
            return new[] { 
            
                new DichiarativoDTO{
                    CodiceFiscale = "PRNMRC"
                    , Anno = 2014
                    , Numero = 10
                }
            };
        }
    }
}
