using Android.App;
using Android.Widget;
using Android.OS;

namespace RiddleMeThis
{
	[Activity (Label = "Riddle Me This", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			Riddles riddles = new Riddles ();
			var riddleTextView = FindViewById<TextView> (Resource.Id.riddleTextView);

			riddleTextView.Text = riddles.ShowRiddles (1);
			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.myButton);
			
			button.Click += delegate {
			//	button.Text = string.Format ("{0} clicks!", count++);
			};
		}
	}
}


