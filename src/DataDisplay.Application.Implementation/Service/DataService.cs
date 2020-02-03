using DataDisplay.Application.Contract.Service;
using DataDisplay.Common.ErrorHandling;
using DataDisplay.Common.Models;
using DataDisplay.Infrastructure.Contract.Client;
using Microsoft.Extensions.Logging;
using OperationResult;
using System.Collections.Generic;
using System.Threading.Tasks;
using static OperationResult.Helpers;

namespace DataDisplay.Application.Implementation.Service
{
    public class DataService : IDataService
    {
        protected readonly ILogger<DataService> Logger;
        protected readonly IDataRepository DataRepository;

        public DataService(ILogger<DataService> logger, IDataRepository dataRepository)
        {
            Logger = logger;
            DataRepository = dataRepository;
        }

        public async Task<Result<IEnumerable<UserDataModel>, Error>> GetAll()
        {
            return Ok(DataRepository.GetAll());
        }
    }
}