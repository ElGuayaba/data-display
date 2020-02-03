using DataDisplay.Common.ErrorHandling;
using DataDisplay.Common.Models;
using OperationResult;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataDisplay.Application.Contract.Service
{
    public interface IDataService
    {
        Task<Result<IEnumerable<UserDataModel>, Error>> GetAll();
    }
}