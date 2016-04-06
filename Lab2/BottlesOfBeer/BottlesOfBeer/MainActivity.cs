using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace BottlesOfBeer
{
	[Activity (Label = "Bottles Of Beer", MainLauncher = true, Icon = "@mipmap/icon")]//, LaunchMode = Android.Content.PM.LaunchMode.SingleInstance )]
	public class MainActivity : Activity
	{		
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			//USE UI CREATED IN MAIN.AXML and set up vars to use the different parts of the layout
			SetContentView(Resource.Layout.Main);
			var takeOne = FindViewById<Button> (Resource.Id.takeOne);
			var takeTwo = FindViewById<Button> (Resource.Id.takeTwo);
			var beerLabel = FindViewById<TextView> (Resource.Id.beerLabel);
			var imgView = FindViewById<ImageView>(Resource.Id.poster);

			//Set the Image Resource
			imgView.SetImageResource (Resource.Drawable.beer);

			//when user clicks take one down send the wallActivity number of beers taken down, 1, and how many beers are on the wall
			takeOne.Click += delegate {
				//StartActivity (typeof(WallActivity));
				var tooTheWall = new Intent(this, typeof(WallActivity));
				tooTheWall.PutExtra("NumberOfBeers", 1);
				tooTheWall.PutExtra("BeersOnWall", (Intent.GetIntExtra("BeersOnWall", 99)));
				StartActivity (tooTheWall);
			};

			//when user clicks take two down send the wallActivity number of beers taken down, 2, and how many beers are on the wall
			takeTwo.Click += delegate {
				//StartActivity (typeof(WallActivity));
				var tooTheWall = new Intent(this, typeof(WallActivity));
				tooTheWall.PutExtra("NumberOfBeers", 2);
				tooTheWall.PutExtra("BeersOnWall", (Intent.GetIntExtra("BeersOnWall", 99)));
				StartActivity (tooTheWall);
			};

			//if the BeersLeft string is not null than use what ever is stored in it if it is null use the default
			//99 bottles of beer on the wall
			if (Intent.GetStringExtra ("BeersLeft") != null) {
				beerLabel.Text = Intent.GetStringExtra ("BeersLeft");
			} else {
				beerLabel.Text = "99 Bottles of Beer on the Wall";
			}
		}
	}
}


