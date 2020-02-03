using CsvHelper;
using DataDisplay.Common.Models;
using DataDisplay.Infrastructure.Contract.Client;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace DataDisplay.Infrastructure.Implementation.Client
{
	public class DataRepository : IDataRepository
	{
		private readonly CsvReader _reader;
		public DataRepository()
		{
			TextReader reader = new StreamReader("NameAddressData.csv");
			_reader = new CsvReader(reader, CultureInfo.InvariantCulture);
			_reader.Configuration.PrepareHeaderForMatch = (header, index) => header.ToLower();
		}

		public IEnumerable<UserDataModel> GetAll()
		{			
			return _reader.GetRecords<UserDataModel>();
		}
	}
}
