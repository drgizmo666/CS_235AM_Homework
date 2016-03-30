using Android.App;
using Android.Widget;
using Android.OS;

namespace SayHello
{
	[Activity (Label = "SayHello", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		int count = 1;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			var layout = new LinearLayout (this);
			layout.Orientation = Orientation.Vertical;

			var aLabel = new TextView (this);
		}
	}
}


