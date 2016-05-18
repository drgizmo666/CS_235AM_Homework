using System;
using SQLite;

namespace DAL
{
	[Table("Figures")]
	public class Figure
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		public string setName { get; set;}
		public string setNumber { get; set;}
		public string name { get; set;}
		public string rarity { get; set;}
		public string keywords { get; set;}
		public int points { get; set;}
		public int lifeClicks { get; set;}
		public string affiliation { get; set;}
		public string specialPowers{ get; set;}
	}
}

