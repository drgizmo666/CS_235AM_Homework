using System;
using SQLite;
using DAL;

namespace TideChartDBTest
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Test the DB");

			string dbPath = @"../../../TideChart/Assets/tides.db3";
			var db = new SQLiteConnection (dbPath);

			//get the first item out of the database
			Console.WriteLine("Get the first line in the db");
			Tides singleItem = db.Get<Tides> (x => x.stationID == 9437381);
			DateTime tideTime = new DateTime(singleItem.dateTime);
			Console.WriteLine ("Predicton for Dick Point on {0}: {1} {2}",  tideTime.ToString("MMM ddd d yyy  hh:mm tt"), singleItem.prediction, singleItem.highLow);
			Console.WriteLine ();

			//see all predictions for Jan
			Console.WriteLine("Get all Predictions for Jan");
			foreach (Tides tide in db.Table<Tides>()) {
				tideTime = new DateTime (tide.dateTime);
				if (tideTime.Month == 1) {
					Console.WriteLine (tideTime.ToString ("MMM ddd d yyy  hh:mm tt") + " " + tide.prediction.ToString () + " " + tide.highLow.ToString ());
				}
			}
			Console.WriteLine ();

			//see all predictions for febuary the 14th
			Console.WriteLine("See Predictions for Febuary the 14th");
			foreach (Tides tide in db.Table<Tides>()) {
				tideTime = new DateTime (tide.dateTime);
				if (tideTime.Month == 2) {
					if (tideTime.Day == 14)
						Console.WriteLine (tideTime.ToString ("MMM ddd d yyy  hh:mm tt") + " " + tide.prediction.ToString () + " " + tide.highLow.ToString ());
				}
			}

		}
	}
}
