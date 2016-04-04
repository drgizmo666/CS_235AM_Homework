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

			takeOne.Click += delegate {
				//StartActivity (typeof(WallActivity));
				var tooTheWall = new Intent(this, typeof(WallActivity));
				tooTheWall.PutExtra("FirstData", 1);
				StartActivity (tooTheWall);
			};

			takeTwo.Click += (sender, e) => {
				StartActivity (typeof(WallActivity));
			};

		}
	}
}


