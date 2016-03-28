using Android.App;
using Android.Widget;
using Android.OS;

namespace Hello_World
{
	[Activity (Label = "Hello_World", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			//create the user interface in code
			var layout = new LinearLayout (this);
			layout.Orientation = Orientation.Vertical;

			var aLabel = new TextView (this);

			aLabel.SetText(Resource.String.helloLabelText);

			var aButton = new Button (this);
			aButton.SetText(Resource.String.helloButtonText);
			aButton.Click += (sender, e) => {
				aLabel.Text = "Hello from the button";
			};
			layout.AddView (aLabel);
			layout.AddView (aButton);
			SetContentView (layout);
		}
	}
}


