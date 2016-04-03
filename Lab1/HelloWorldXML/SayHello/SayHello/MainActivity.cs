using Android.App;
using Android.Widget;
using Android.OS;


namespace SayHello
{
	[Activity (Label = "SayHello", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.Main);

			var helloButton = FindViewById<Button> (Resource.Id.aButton);
			var mainLabel = FindViewById<TextView> (Resource.Id.helloLabel);
			var resetButton = FindViewById<Button> (Resource.Id.bButton);
			//set bButtons enable to false
			resetButton.Enabled = false;
 
			helloButton.Click += (sender, e) => {
				mainLabel.SetText(Resource.String.sayHello);
				helloButton.Enabled = false;
				resetButton.Enabled = true;
			};

			resetButton.Click += (sender, e) => {
				mainLabel.SetText(Resource.String.androidHello);
				helloButton.Enabled = true;
				resetButton.Enabled = false;
			};
		}
	}
}


