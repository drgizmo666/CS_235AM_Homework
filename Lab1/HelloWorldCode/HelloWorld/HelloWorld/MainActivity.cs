using Android.App;
using Android.Widget;
using Android.OS;

namespace HelloWorld
{
	[Activity (Label = "HelloWorld", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			//create the user interface in code
			var layout = new LinearLayout(this);
			layout.Orientation = Orientation.Vertical;

			var aLabel = new TextView (this);
			//Old Code
			//aLabel.Text = "Hello, Xamarin.Android";
			//Set aLabel text using the xml string resources
			aLabel.Text = "Hello Xamarin.Android";

			var aButton = new Button (this);
			var bButton = new Button (this);
			bButton.Enabled = false;
			//old code
			//aButton.Text = "Say Hello";
			//Set aButton Text using the xml string resources
			aButton.Text = "Say Hello";
			bButton.Text = "Reset";

			aButton.Click += (sender, e) => {
				aLabel.Text = "Hello from button";
				aButton.Enabled = false;
				bButton.Enabled = true;
			};

			bButton.Click += (sender, e) => {
				aLabel.Text = "Hello Xamarin.Android";
				aButton.Enabled = true;
				bButton.Enabled = false;
			};

			layout.AddView (aLabel);
			layout.AddView (aButton);
			layout.AddView (bButton);
			SetContentView (layout);
		}
	}
}


