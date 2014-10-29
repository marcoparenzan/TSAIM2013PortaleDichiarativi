using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.Dichiarativi.AzureStorage
{
    public class DichiarativoDTOTableEntity
        : TableEntity
    {
        public string CodiceFiscale { get; set; }
        public int Anno { get; set; }
        public int Numero { get; set; }
    }
}
