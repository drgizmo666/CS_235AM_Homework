using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Android.Runtime;

namespace TideChart
{
	class XmlFileReader
	{
		List<IDictionary<string,object>> tideList;

		public List<IDictionary<string, object>> TideList { get { return tideList; } }

		public XmlFileReader (Stream xmlStream)
		{
			tideList = new List<IDictionary<string, object>>();

			// Parse the xml file and fill the list of JavaDictionary objects with vocabulary data
			using (XmlReader reader = XmlReader.Create (xmlStream)) {
				JavaDictionary<string, object> tideItem = null;

				while (reader.Read ()) {
					// Only detect start elements.
					if (reader.IsStartElement ()) {
						// Get element name and switch on it.
						switch (reader.Name) {
						case "item":
							// New word
							tideItem = new JavaDictionary<string, object> ();
							break;
						case "day":
							// Add the day
							if (reader.Read () && tideItem != null) {
								tideItem.Add ("day", reader.Value.Trim ());
							}
							break;
						case "date":
							// Add the date
							if (reader.Read () && tideItem != null)
								tideItem.Add ("date", reader.Value.Trim ());
							}
							break;
						case "time":
							// Add the time
							if (reader.Read () && tideItem != null) {
								tideItem.Add ("time", reader.Value.Trim ());
							}
							break;
						case "highlow":
							//Add high or low
							if(reader.Read () && tideItem != null) {
								tideItem.Add("highlow", reader.Value.Trim());
							}	
							break;
						case "predictions_in_ft":
							//Add predictions in feet
							if (reader.Read () && tideItem != null) {
								tideItem.Add ("predictions_in_ft", reader.Value.Trim ());
							}
							break;
						}
					} else if (reader.Name == "item") {  
						// reached </item>
						tideList.Add(tideItem);
						tideItem = null;
					}

				}
			}


		}
	}

}


