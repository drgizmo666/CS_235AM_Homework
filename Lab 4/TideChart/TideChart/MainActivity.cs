using Android.App;
using Android.Widget;
using Android.OS;
using Android.Runtime;
using Android.Views;

namespace TideChart
{
	[Activity (Label = "Tide Chart for Dick Point Station", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : ListActivity
	{

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			var reader = new XmlFileReader(Assets.Open(@"DickPointTideChart.xml"));
			var dataList = reader.TideList;
			ListAdapter = new TideAdapter (this, 
				dataList,
				Android.Resource.Layout.SimpleListItem2,
				new string[] {"date", "time"},
				new int[] {Android.Resource.Id.Text1, Android.Resource.Id.Text2}
			);
		}

		protected override void OnListItemClick(ListView l,
			View v,
			int position,
			long id)
		{
			string predictions = (string)((JavaDictionary<string,object>)ListView.GetItemAtPosition(position))["predictions_in_ft"];
			Android.Widget.Toast.MakeText(this,
				predictions + " ft",
				Android.Widget.ToastLength.Short).Show();
		}


	}
}


