using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System.IO;
using DAL;

namespace TideChart
{
	[Activity (Label = "Tillamook Bay Tide Chart", LaunchMode = Android.Content.PM.LaunchMode.SingleInstance)]			
	public class tideListView : Activity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			SetContentView (Resource.Layout.tideListView);



		}

		protected override void OnResume ()
		{
			base.OnResume ();

			string dbPath = "";
			SQLiteConnection db = null;

			// Get the path to the database that was deployed in Assets
			dbPath = Path.Combine (
				System.Environment.GetFolderPath (System.Environment.SpecialFolder.Personal), "tides.db3");

			//copy the DB file to a read/write location
			using (Stream inStream = Assets.Open ("tides.db3"))
			using (Stream outStream = File.Create (dbPath))
				inStream.CopyTo(outStream);

			// Open the database
			db = new SQLiteConnection (dbPath);

			//get the tideListView, station text box, station button, and get the date and selected station
			var tidesListView = FindViewById<ListView> (Resource.Id.tidesListView);
			var stationTextView = FindViewById<TextView> (Resource.Id.stationTextView);
			var backButton = FindViewById<Button> (Resource.Id.backButton);

			DateTime selectedDate = Convert.ToDateTime (Intent.GetStringExtra("dateIntent"));
			var selectedStation = Intent.GetStringExtra ("stationIntent");
			stationTextView.Text = "Station: " + selectedStation;
			DateTime startDate = selectedDate;
			DateTime endDate = selectedDate.AddDays(1);
			var tides = (from t in db.Table<Tides>() 
				where (t.stationName == selectedStation)
				&& (t.dateTime >= startDate.Ticks)
				&& (t.dateTime <= endDate.Ticks)
				select t).ToList ();

			int count = tides.Count;
			string[] tideInfoArray = new string[count];
			for(int i = 0; i < count; i++)
			{
				DateTime tideDate = new DateTime(tides[i].dateTime);
				tideInfoArray[i] = 
					tideDate.ToString("MMM ddd d yyy  hh:mm tt") + "\t\t" + tides[i].prediction + " " + tides[i].highLow;
			}

			tidesListView.Adapter = 
				new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, tideInfoArray);

			backButton.Click += delegate {
				var main = new Intent(this, typeof(MainActivity));
				StartActivity(main);
			};
		}
	}
}

