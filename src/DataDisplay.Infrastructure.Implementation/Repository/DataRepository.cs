using CsvHelper;
using DataDisplay.Common.Models;
using DataDisplay.Infrastructure.Contract.Client;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace DataDisplay.Infrastructure.Implementation.Client
{
	public class DataRepository : IDataRepository
	{
		private readonly CsvReader _reader;
		private IEnumerable<UserDataModel> records = new List<UserDataModel>();
		public DataRepository()
		{
			TextReader reader = new StreamReader("NameAddressData.csv");
			_reader = new CsvReader(reader, CultureInfo.InvariantCulture);
			_reader.Configuration.PrepareHeaderForMatch = (header, index) => header.ToLower();
		}

		public IEnumerable<UserDataModel> GetAll()
		{
			if (!records.Any())
			{
				records = _reader.GetRecords<UserDataModel>().ToList();
			}
			return records;
		}
	}
}
