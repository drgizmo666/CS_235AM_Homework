using System;
using SQLite;
using DAL;
using System.IO;

namespace TideChartConsole
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Fill the tide database");
			Console.WriteLine ();
			// We're using a file in Assets instead of the one defined above
			//string dbPath = Directory.GetCurrentDirectory ();
			string dbPath = @"../../../TideChart/Assets/tides.db3";
			var db = new SQLiteConnection (dbPath);
		
			// Create a Tides table
			//db.DropTable<Tides>();
			if (db.CreateTable<Tides>() == 0)
			{
				// A table already exixts, delete any data it contains
				db.DeleteAll<Tides> ();
			}

			AddTidesToDb (db, 9437381, "Dick Point", "DickPoint.xml");
			//Tides singleItem = db.Get<Tides> (x => x.stationID == 9437381);
			//Console.WriteLine ("Predicton for Dick Point: {0} {1}", singleItem.prediction, singleItem.highLow);


		
		}

		private static void AddTidesToDb(SQLiteConnection db, int statId, string name ,string file)
		{
			var reader = new XmlFileReader(File.Open(@"../../../TideChart-Console/DAL/" + file, FileMode.Open));
			var dataList = reader.TideList;
			int tideCount = dataList.Count;
			string tideDateString;
			DateTime tideDateTime;
			long tideTicks;

			int pk = 0;
			for (int i = 0; i < tideCount; i++) {
				//get the date and time from the xml file and than convert it to a datTime type
				//and finaly convert the dateTime to ticks type
				tideDateString = dataList [i] ["date"].ToString () + " " + dataList [i] ["time"].ToString ();
				tideDateTime = Convert.ToDateTime(tideDateString);
				tideTicks = tideDateTime.Ticks;

				//insert the new tides into the data base
				pk += db.Insert (new Tides{
					stationID = statId,
					stationName = name,
					dateTime = tideTicks,
					prediction = dataList[i]["predictions_in_ft"].ToString() + " FT",
					highLow = dataList[i]["highlow"].ToString()
				});

				if (pk % 100 == 0) {
					Console.WriteLine ("{0} {1} rows inserted", pk, name);
				}
			}
			// show the finale count
			Console.WriteLine ("{0} {1} rows inserted", pk, name);
		}
	}
}
