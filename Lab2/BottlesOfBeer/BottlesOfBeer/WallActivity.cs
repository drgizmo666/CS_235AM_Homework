
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

namespace BottlesOfBeer
{
	[Activity (Label = "Bottles Of Beer", Icon = "@mipmap/icon", LaunchMode = Android.Content.PM.LaunchMode.SingleInstance)]			
	public class WallActivity : Activity
	{
		//on create set the beers on the wall to 99
		public int beersOnWall = 99;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// SHOW THE 2ND LAYOUT
			//USE UI CREATED IN MAIN.AXML
			SetContentView(Resource.Layout.Wall);
			//get the button from the UI
			var showMain = FindViewById<Button> (Resource.Id.showMain);

			showMain.Click += (sender, e) => {
				var toMain = new Intent(this, typeof(MainActivity));
				//send the updated text to the main page
				toMain.PutExtra("BeersLeft", (beersOnWall.ToString() + " Bottles of Beer on the Wall"));
				StartActivity (toMain);
			};
		}

		protected override void OnResume ()
		{
			base.OnResume ();
			//Get how many beers taken from the wall and get the two text view from the ui
			var bottlesTaken = Intent.GetIntExtra("NumberOfBeers", 0);
			var beersOnWallLabel = FindViewById<TextView> (Resource.Id.beerOnWallLabel);
			var takeItDown = FindViewById<TextView> (Resource.Id.takeItDownLabel);
			//set the text view so the show the right data and subtract the beers taken from the wall
			beersOnWallLabel.Text = beersOnWall.ToString () + " Bottles of Beer";
			takeItDown.Text = "Take " + bottlesTaken.ToString () + " Down";
			beersOnWall -= bottlesTaken;
		}

		protected override void OnNewIntent (Intent intent)
		{
			base.OnNewIntent (intent);

			Intent = intent;
		}
	}
}

