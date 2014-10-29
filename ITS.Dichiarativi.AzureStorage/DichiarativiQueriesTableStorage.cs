using ITS.Dichiarativi.Contracts;
using ITS.Dichiarativi.DTOs;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.Dichiarativi.AzureStorage
{
    public class DichiarativiQueriesTableStorage:
        IDichiarativiQueries
    {
        private StorageCredentials _storageCredentials;

        public DichiarativiQueriesTableStorage(StorageCredentials storageCredentials)
        {
            _storageCredentials = storageCredentials;
        }

        IEnumerable<DTOs.DichiarativoDTO> IDichiarativiQueries.GetAll()
        {
            var cloudStorageAccount =
                new CloudStorageAccount(_storageCredentials, true);

            var tableClient = cloudStorageAccount.CreateCloudTableClient();

            var dichiarativi = tableClient.GetTableReference("marcoparenzandichiarativi");
            if (dichiarativi.CreateIfNotExists())
            {
                var newDto = new DichiarativoDTOTableEntity
                {
                    PartitionKey = "_2014"
                    ,
                    RowKey = "PRNMRC"
                    ,
                    CodiceFiscale = "PRMMRC"
                    ,
                    Anno = 2014
                    ,
                    Numero = 50
                };
                var insertDto = TableOperation.Insert(newDto);
                dichiarativi.Execute(insertDto);
            }

            var query = new TableQuery<DichiarativoDTOTableEntity>();
            var result = dichiarativi.ExecuteQuery(query).Select(xx => new DichiarativoDTO
            {
                CodiceFiscale = xx.CodiceFiscale
                ,
                Anno = xx.Anno
                ,
                Numero = xx.Numero
            }).ToArray();


            return result;
        }
    }
}
