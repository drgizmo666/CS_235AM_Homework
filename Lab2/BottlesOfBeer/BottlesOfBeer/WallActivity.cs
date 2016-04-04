
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
			var bottlesTaken = Intent.GetIntExtra("FirstData", 0);
			var showSecond = FindViewById<Button> (Resource.Id.showMain);
			var wallLabel = FindViewById<TextView> (Resource.Id.Screen2Label);

			wallLabel.Text = bottlesTaken.ToString ();
			showSecond.Click += (sender, e) => {
				StartActivity (typeof(MainActivity));
			};
		}
	}
}

