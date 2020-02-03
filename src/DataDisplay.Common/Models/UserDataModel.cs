using DataDisplay.Common.Enums;

namespace DataDisplay.Common.Models
{
	public class UserDataModel
	{
		public string Title { get; set; }
		public string Forename { get; set; }
		public string Middle_Names { get; set; }
		public string Surname { get; set; }
		public Genders Gender { get; set; }
		public string Date_Of_Birth { get; set; }
		public string Home_Building_Name { get; set; }
		public int? Home_Building_Number { get; set; }
		public string Home_Sub_Building { get; set; }
		public string Home_Street { get; set; }
		public string Home_City { get; set; }
		public string Home_County { get; set; }
		public string Home_Postcode { get; set; }
		public string Home_Phone_Number { get; set; }
		public string Mobile_Phone_Number { get; set; }
		public string Email_Address { get; set; }
	}
}
