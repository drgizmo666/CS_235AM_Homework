using System;
using SQLite;


namespace DAL
{
	[Table("TidesTable")]
	public class Tides
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		public int stationID { get; set; }
		public string stationName { get; set;}
		public long dateTime {get; set;}
		public string prediction { get; set;}
		public string highLow { get; set;}
	}
}