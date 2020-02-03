using DataDisplay.Common.Models;
using System.Collections.Generic;

namespace DataDisplay.Infrastructure.Contract.Client
{
	public interface IDataRepository
	{
		IEnumerable<UserDataModel> GetAll();
	}
}
