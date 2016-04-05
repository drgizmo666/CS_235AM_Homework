using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace BottlesOfBeer
{
	[Activity (Label = "Bottles Of Beer", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			//USE UI CREATED IN MAIN.AXML
			SetContentView(Resource.Layout.Main);
			var takeOne = FindViewById<Button> (Resource.Id.takeOne);
			var takeTwo = FindViewById<Button> (Resource.Id.takeTwo);
			var beerLabel = FindViewById<TextView> (Resource.Id.beerLabel);
			var imgView = FindViewById<ImageView>(Resource.Id.poster);

			imgView.SetImageResource (Resource.Drawable.beer);

			takeOne.Click += delegate {
				//StartActivity (typeof(WallActivity));
				var tooTheWall = new Intent(this, typeof(WallActivity));
				tooTheWall.PutExtra("NumberOfBeers", 1);
				tooTheWall.PutExtra("BeersOnWall", (Intent.GetIntExtra("BeersOnWall", 99)));
				StartActivity (tooTheWall);
			};

			takeTwo.Click += delegate {
				//StartActivity (typeof(WallActivity));
				var tooTheWall = new Intent(this, typeof(WallActivity));
				tooTheWall.PutExtra("NumberOfBeers", 2);
				tooTheWall.PutExtra("BeersOnWall", (Intent.GetIntExtra("BeersOnWall", 99)));
				StartActivity (tooTheWall);
			};

			if (Intent.GetStringExtra ("BeersLeft") != null) {
				beerLabel.Text = Intent.GetStringExtra ("BeersLeft");
			} else {
				beerLabel.Text = "99 Bottles of Beer on the Wall";
			}



		}
	}
}


