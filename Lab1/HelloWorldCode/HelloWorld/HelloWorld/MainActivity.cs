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

			var mainLabel = new TextView (this);
			//Old Code
			//aLabel.Text = "Hello, Xamarin.Android";
			//Set aLabel text using the xml string resources
			mainLabel.Text = "Hello Xamarin.Android";

			var helloButton = new Button (this);
			var resetButton = new Button (this);
			resetButton.Enabled = false;
			//old code
			//aButton.Text = "Say Hello";
			//Set aButton Text using the xml string resources
			helloButton.Text = "Say Hello";
			resetButton.Text = "Reset";

			helloButton.Click += (sender, e) => {
				mainLabel.SetText(Resource.String.helloText);
				helloButton.Enabled = false;
				resetButton.Enabled = true;
			};

			resetButton.Click += (sender, e) => {
				mainLabel.Text = "Hello Xamarin.Android";
				helloButton.Enabled = true;
				resetButton.Enabled = false;
			};

			layout.AddView (mainLabel);
			layout.AddView (helloButton);
			layout.AddView (resetButton);
			SetContentView (layout);
		}
	}
}


