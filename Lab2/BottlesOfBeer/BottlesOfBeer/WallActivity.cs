
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
	[Activity (Label = "Bottles Of Beer")]			
	public class WallActivity : Activity
	{

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// SHOW THE 2ND LAYOUT
			//USE UI CREATED IN MAIN.AXML
			SetContentView(Resource.Layout.Wall);
			var bottlesTaken = Intent.GetIntExtra("NumberOfBeers", 0);
			var beersOnWall = Intent.GetIntExtra ("BeersOnWall", 99);
			var showSecond = FindViewById<Button> (Resource.Id.showMain);

			beersOnWall -= bottlesTaken;

			showSecond.Click += (sender, e) => {
				var toMain = new Intent(this, typeof(MainActivity));
				toMain.PutExtra("BeersLeft", (beersOnWall.ToString() + " Bottles of Beer on the Wall ^^"));
				toMain.PutExtra("BeersOnWall", beersOnWall);
				StartActivity (toMain);
			};
		}
	}
}

