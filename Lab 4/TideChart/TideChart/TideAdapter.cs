using System;
using Android.Widget;
using System.Collections.Generic;
using Android.Content;
using Android.Views;
using Android.App;

namespace TideChart
{
	class TideAdapter : SimpleAdapter, ISectionIndexer
	{
		IList<IDictionary<string, object>> dataList;
		String[] sections;
		Java.Lang.Object[] sectionsObjects;
		Dictionary<string, int> alphaIndex;
		Activity c;

		public TideAdapter (Context context, 
			IList<IDictionary<string, object>> data, 
			Int32 resource, 
			String[] from,
			Int32[] to) : base(context, data, resource, from, to)
		{
			dataList = data;
			c = (Activity)context;
			BuildSectionIndex ();
		}

		public override View GetView (int position, View convertView, ViewGroup parent)
		{
			View view = convertView;
			if (view == null)
				view = c.LayoutInflater.Inflate (
					Android.Resource.Layout.TwoLineListItem,
					null);
			//display day and date
			view.FindViewById<TextView> (Android.Resource.Id.Text1).Text 
			= dataList [position] ["day"] + " " + dataList [position] ["date"];

			//display time and tide
			if ((string)dataList [position] ["highlow"] == "H") {
				view.FindViewById<TextView> (Android.Resource.Id.Text2).Text 
			= dataList [position] ["time"] + " - High Tide";
			} else {
				view.FindViewById<TextView> (Android.Resource.Id.Text2).Text 
				= dataList [position] ["time"] + " - Low Tide";
			}

			return view;
		}
		public int GetPositionForSection(int section)
		{
			return alphaIndex [sections [section]];
		}

		public int GetSectionForPosition(int position)
		{
			return 1;
		}

		public Java.Lang.Object[] GetSections()
		{
			return sectionsObjects;
		}

		private void BuildSectionIndex()
		{
			alphaIndex = new Dictionary<string, int>();		// Map sequential numbers
			for (var i = 0; i < Count; i++)
			{
				// Use the part of speech as a key
				var key = (string)dataList[i]["day"];
				if (!alphaIndex.ContainsKey(key))
				{
					alphaIndex.Add(key, i);
				} 
			}

			// Get the count of sections
			sections = new string[alphaIndex.Keys.Count];
			// Copy section names into the sections array
			alphaIndex.Keys.CopyTo(sections, 0);

			// Copy section names into a Java object array
			sectionsObjects = new Java.Lang.Object[sections.Length];
			for (var i = 0; i < sections.Length; i++)
			{
				sectionsObjects[i] = new Java.Lang.String(sections[i]);
			}
		} 
	}

}


