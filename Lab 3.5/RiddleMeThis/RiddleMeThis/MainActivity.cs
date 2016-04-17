using Android.App;
using Android.Widget;
using Android.OS;
using System.IO;
using System.Xml.Serialization;

namespace RiddleMeThis
{
	[Activity (Label = "Riddle Me This", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		RiddleMaster riddleMaster;
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Create a new taskMaster, or restore a saved one
			if (savedInstanceState == null) {
				riddleMaster = new RiddleMaster ("testing");
			}
			else {
				// Deserialized the saved object state
				string xmlRiddles = savedInstanceState.GetString("Riddles");
				XmlSerializer x = new XmlSerializer(typeof(RiddleMaster));
				riddleMaster = (RiddleMaster)x.Deserialize(new StringReader(xmlRiddles));
			}

			// Get our button and testview from the layout resource
			Button riddleButton = FindViewById<Button> (Resource.Id.riddleButton);
			Button answerButton = FindViewById<Button> (Resource.Id.answerButton);
			Button resetButton = FindViewById<Button> (Resource.Id.resetButton);
			TextView riddleTextView = FindViewById<TextView> (Resource.Id.riddleTextView);
			TextView outputTextView = FindViewById<TextView> (Resource.Id.outputTextView);
			TextView scoreTextView = FindViewById<TextView> (Resource.Id.scoreTextView);
			EditText answerEditText = FindViewById<EditText> (Resource.Id.answerEditText);


			riddleButton.Click += delegate {
				riddleTextView.Text = riddleMaster.GetRiddle(riddleMaster.riddleNum);
				outputTextView.Text = "Riddle Me This";
				answerEditText.Text = "";
				riddleButton.Enabled = false;
				answerButton.Enabled = true;
			};

			answerButton.Click += delegate 
			{
				riddleTextView.Text = riddleMaster.GetAnswer(riddleMaster.riddleNum);

				if(riddleMaster.checkAnswer(answerEditText.Text) == "Correct")
				{
					outputTextView.Text = "Correct";
					scoreTextView.Text = riddleMaster.showScore();

				}
				else
				{
					outputTextView.Text = "Wrong";
					scoreTextView.Text = riddleMaster.showScore();
				}

				if(riddleMaster.riddleNum == 4)
				{
					riddleButton.Enabled = false;
					answerButton.Enabled = false;
					resetButton.Enabled = true;
				}
				else
				{
					riddleMaster.riddleNum += 1;
					riddleButton.Enabled = true;
					answerButton.Enabled = false;
				}


			};

			resetButton.Click += delegate {
				riddleMaster.riddleNum = 0;
				riddleTextView.Text = "Click show riddle to try a riddle";
				answerEditText.Text = "";
				riddleButton.Enabled = true;
				answerButton.Enabled = false;
				resetButton.Enabled = false;

			};
		}

		protected override void OnResume ()
		{
			base.OnResume ();


		}

		protected override void OnSaveInstanceState (Bundle outState)
		{
			// Use this to convert a stream to a string
			StringWriter writer = new StringWriter ();

			// Serialize the public state of taskMaster to XML
			XmlSerializer riddleMasterSerializer = new XmlSerializer(typeof(RiddleMaster));
			riddleMasterSerializer.Serialize(writer, riddleMaster);

			// Save the serialized state
			string xmlTasks = writer.ToString ();
			outState.PutString ("Riddles", xmlTasks );

			base.OnSaveInstanceState (outState);
		}
	}
}


