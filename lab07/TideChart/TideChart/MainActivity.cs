using System;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Runtime;
using Android.Views;
using System.IO;
using SQLite;
using DAL;
using System.Linq;
using Android.Content;

namespace TideChart
{
	[Activity (Label = "Tillamook Bay Tide Chart", MainLauncher = true, Icon = "@mipmap/icon", LaunchMode = Android.Content.PM.LaunchMode.SingleInstance)]
	public class MainActivity : Activity
	{

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.tideMain);

			/* ------ copy and open the dB file using the SQLite-Net ORM ------ */

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

			/* ------ Spinner initialization ------ */

			// Initialize the adapter for the spinner with stock symbols
			var distinctStations = db.Table<Tides> ().GroupBy (s => s.stationName).Select (s => s.First ());
			var tillamookStations = distinctStations.Select (s => s.stationName).ToList ();
			var adapter = new ArrayAdapter (this, Android.Resource.Layout.SimpleSpinnerItem, tillamookStations);

			var tideSpinner = FindViewById <Spinner> (Resource.Id.tideSpinner);
			tideSpinner.Adapter = adapter;

			// Event handler for selected spinner item
			string selectedStation = "";
			tideSpinner.ItemSelected += delegate(object sender, AdapterView.ItemSelectedEventArgs e) {
				Spinner spinner = (Spinner)sender;
				selectedStation = (string)spinner.GetItemAtPosition(e.Position);
			};

			/* ------- DatePicker initialization ------- */

			var tideDatePicker = FindViewById<DatePicker> (Resource.Id.tideDatePicker);
			tideDatePicker.SpinnersShown = true;
			tideDatePicker.CalendarViewShown = false;

			Tides firstDateTide = 
				db.Get<Tides>((from s in db.Table<Tides>() select s).Min(s => s.ID));
			DateTime firstDate = new DateTime(firstDateTide.dateTime);
			tideDatePicker.DateTime = firstDate;


			Button listViewButton = FindViewById<Button> (Resource.Id.listViewButton);
			listViewButton.Click += delegate 
			{
				var tideListIntent = new Intent(this, typeof(tideListView));

				tideListIntent.PutExtra("dateIntent", tideDatePicker.DateTime.ToString());
				tideListIntent.PutExtra("stationIntent", selectedStation);

				StartActivity(tideListIntent);
			};
		}

		protected override void OnNewIntent (Intent intent)
		{
			base.OnNewIntent (intent);

			Intent = intent;
		}
	}
}


