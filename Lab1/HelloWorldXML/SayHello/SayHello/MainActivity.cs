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

			var aButton = FindViewById<Button> (Resource.Id.aButton);
			var aLabel = FindViewById<TextView> (Resource.Id.helloLabel);
			var bButton = FindViewById<Button> (Resource.Id.bButton);
			//set bButtons enable to false
			bButton.Enabled = false;
 
			aButton.Click += (sender, e) => {
				aLabel.SetText(Resource.String.sayHello);
				aButton.Enabled = false;
				bButton.Enabled = true;
			};

			bButton.Click += (sender, e) => {
				aLabel.SetText(Resource.String.androidHello);
				aButton.Enabled = true;
				bButton.Enabled = false;
			};
		}
	}
}


