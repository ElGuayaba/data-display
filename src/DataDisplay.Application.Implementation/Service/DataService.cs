using DataDisplay.Application.Contract.Service;
using DataDisplay.Common.ErrorHandling;
using DataDisplay.Common.Models;
using DataDisplay.Infrastructure.Contract.Client;
using Microsoft.Extensions.Logging;
using OperationResult;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<Result<IEnumerable<string>, Error>> GetAddresses()
        {
            var data = DataRepository.GetAll().ToList();

            return Ok(data.Select(item => $"{item.Home_Street}, {item.Home_Building_Number}, {item.Home_City} ({item.Home_Postcode})").Distinct());
        }

        public async Task<Result<IEnumerable<string>, Error>> GetNames(string inputAddress)
        {
            var data = (await GetAll()).Value.ToList();

            var users = data.Where(item => $"{item.Home_Street}, {item.Home_Building_Number}, {item.Home_City} ({item.Home_Postcode})" == inputAddress.Trim());

            return Ok(users.Select(user => $"{user.Forename} {user.Middle_Names} {user.Surname}"));
        }
    }
}